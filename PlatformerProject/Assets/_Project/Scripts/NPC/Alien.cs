using System.Collections;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Alien : NPC
{
    private enum AlienState
    {
        idle,
        roaming,
        following,
        running,
        attacking,
        death
    }

    [SerializeField] AnimationClip clip;
    [SerializeField] int damage;
    [SerializeField] bool attackCoroutineActive;
    [SerializeField] float destinationReachedThreshold;
    [SerializeField] Transform underground;
    [SerializeField] float deathSpeed;

    public RectTransform AlienHealthBar;
    public GameObject PlayerObject;
    public DmgImg DmgImg;
    public Image Image;

    private bool isDead;
    private bool coroutineActive;
    private int rngDeath;
    private Rigidbody rb;
    private Animator anim;
    private Player player;
    private Vector3 randomDestination;
    private AlienState state;

    [Header("timers")]
    public float IdleTimer;
    public float RoamingTimer;

    [Header("Detecting Range")]
    [SerializeField] public float Distance;
    [SerializeField] float followReachedThreshold;
    [SerializeField] float runReachedThreshold;
    [SerializeField] float attackReachedThreshold;

    private void Awake()
    {
        //all the references i can get with GetComponent
        anim = this.gameObject.GetComponent<Animator>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        player = PlayerObject.gameObject.GetComponent<Player>();
    }

    private void Start()
    {
        state = AlienState.idle;
        health = 200;
        isDead = false;
        rngDeath = Random.Range(1, 3);
        attackCoroutineActive = false;
    }

    private void Update()
    {
        SwitchCase();
        AlienHealth();
    }

    private void FixedUpdate()
    {
        if (state == AlienState.roaming)
        {
            SetDestination();
        }
    }

    //deals dmg to the player
    public void DealDmg()
    {
        if (Distance < 1)
        {
            player.playerHealth -= damage;
            PlayerObject.GetComponentInChildren<Animator>().SetTrigger("TakenDmg");
            StartCoroutine(DmgImg.FadeIn(Image));
        }
    }

    //sets a destination to where the alien goes when roaming 
    private void SetDestination()
    {
        if (!agent.pathPending && agent.remainingDistance <= destinationReachedThreshold)
        {
            randomDestination = new Vector3(transform.position.x + Random.Range(-10, 10), 0, transform.position.z + Random.Range(-10, 10));
        }
    }

    //a switch that checks which state the alien is in to run a function
    private void SwitchCase()
    {
        switch (state)
        {
            case AlienState.idle:
                Idle();
                break;
            case AlienState.roaming:
                Roaming();
                break;
            case AlienState.following:
                Follow();
                break;
            case AlienState.running:
                Running();
                break;
            case AlienState.attacking:
                Attack();
                break;
            case AlienState.death:
                Death();
                break;
        }
    }

    //updates the health bar to how many hp and when it reaches 0 state is death
    private void AlienHealth()
    {
        AlienHealthBar.sizeDelta = new Vector2(health / 400, AlienHealthBar.rect.height);
        Camera cam = FindObjectOfType<Camera>();
        AlienHealthBar.parent.LookAt(cam.transform);

        if (health <= 0 && isDead == false)
        {
            state = AlienState.death;
        }
        if (isDead)
        {
            state = AlienState.death;
        }

        if (isDead == false)
        {
            DistanceToPlayer();
        }
    }

    //calculates the distance between the player and the alien and changes the state according to how far
    private void DistanceToPlayer()
    {
        if(health > 0)
        {
            Distance = Vector3.Distance(this.transform.position, PlayerObject.transform.position);
            if (Distance < attackReachedThreshold)
            {
                state = AlienState.attacking;
            }
            else if (Distance < runReachedThreshold)
            {
                state = AlienState.running;
            }
            else if (Distance < followReachedThreshold)
            {
                state = AlienState.following;
            }
            if (Distance > followReachedThreshold)
            {
                state = AlienState.roaming;
            }
            else if (Distance > runReachedThreshold)
            {
                state = AlienState.following;
            }
            else if (Distance > attackReachedThreshold)
            {
                anim.SetLayerWeight(anim.GetLayerIndex("Attacking"), 0f);
                state = AlienState.running;
            }
        }
    }

    //does his idle animation and does nothing else
    private void Idle()
    {
        anim.SetFloat("Blend", 0);
        agent.speed = 0;
        rb.velocity = Vector3.zero;
        StartCoroutine(SwitchToRoaming());
    }

    //goes to a destination he gets
    private void Roaming()
    {
        anim.SetFloat("Blend", 2);
        agent.SetDestination(randomDestination);
        agent.speed = 2;
        StartCoroutine(SwitchToIdle());
    }

    //follow the player
    private void Follow()
    {
        anim.SetFloat("Blend", 2);
        agent.SetDestination(PlayerObject.transform.position);
        agent.speed = 2;
    }

    //runs towards the player
    private void Running()
    {
        anim.SetFloat("Blend", 5);
        agent.SetDestination(PlayerObject.transform.position);
        agent.speed = 3.5f;
    }

    //attacks the player
    private void Attack()
    {
        anim.SetLayerWeight(anim.GetLayerIndex("Attacking"), 1f);
        agent.speed = 0;
        if(!attackCoroutineActive)
        {
            attackCoroutineActive = true;
            StartCoroutine(WaitToAttack());
        }
        this.gameObject.transform.LookAt(PlayerObject.transform.position);
    }

    //plays death animation
    private void Death()
    {
        agent.enabled = false;
        if (isDead == false)
        {
            anim.SetTrigger("Dead");
            anim.SetInteger("RngDeath", rngDeath);
            StartCoroutine(WaitToDissolve());
        }
        isDead = true;
        rb.constraints = RigidbodyConstraints.None;
        anim.SetLayerWeight(anim.GetLayerIndex("Attacking"), 0f);
    }

    //switches to roaming after a couple seconds
    IEnumerator SwitchToRoaming()
    {
        yield return new WaitForSeconds(IdleTimer);
        state = AlienState.roaming;
    }
    
    //switches to idle after a random amount of seconds between 5 and 20
    IEnumerator SwitchToIdle()
    {
        RoamingTimer = Random.Range(5, 20);
        yield return new WaitForSeconds(RoamingTimer);
        StopCoroutine(SwitchToIdle());
    }

    //attack cooldown
    IEnumerator WaitToAttack()
    {
        yield return new WaitForSeconds(clip.length + 2);
        anim.SetTrigger("Attacking");
        attackCoroutineActive = false;
    }

    //pulls alien in ground and destroys when fully under ground
    IEnumerator WaitToDissolve()
    {
        yield return new WaitForSeconds(5f);
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
