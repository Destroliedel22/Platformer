using System.Collections;
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
    private AlienState state;

    [SerializeField] AnimationClip clip;
    [SerializeField] int damage;
    private bool IsDead;

    private Rigidbody rb;
    private Animator anim;
    public GameObject playerObject;
    public DamageCanvas Dc;
    private Player player;

    Vector3 RandomDestination;
    [SerializeField] float destinationReachedThreshold;

    [Header("timers")]
    public float idleTimer;
    public float roamingTimer;

    [Header("Detecting Range")]
    [SerializeField] public float distance;
    [SerializeField] float followReachedThreshold;
    [SerializeField] float runReachedThreshold;
    [SerializeField] float attackReachedThreshold;

    bool noStamina;
    bool coroutineActive;
    [SerializeField] bool attackCoroutineActive;

    public Image image;

    private void Awake()
    {
        anim = this.gameObject.GetComponent<Animator>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        agent = this.gameObject.GetComponent<NavMeshAgent>();
        player = playerObject.gameObject.GetComponent<Player>();
    }

    private void Start()
    {
        state = AlienState.idle;
        Stamina = 100;
        health = 200;
        IsDead = false;
    }

    private void Update()
    {
        switch(state)
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

        if(health <= 0 && IsDead == false)
        {
            state = AlienState.death;
        }
    }

    private void FixedUpdate()
    {
        if (!agent.pathPending && agent.remainingDistance <= destinationReachedThreshold && state == AlienState.roaming)
        {
            RandomDestination = new Vector3(transform.position.x + Random.Range(-10, 10), 0, transform.position.z + Random.Range(-10, 10));
        }

        if(IsDead == false)
        {
            distanceToPlayer();
        }
    }

    private void distanceToPlayer()
    {
        distance = Vector3.Distance(this.transform.position, playerObject.transform.position);
        if (distance < attackReachedThreshold)
        {
            state = AlienState.attacking;
        }
        else if (distance < runReachedThreshold && !noStamina)
        {
            state = AlienState.running;
        }
        else if(distance < followReachedThreshold && !noStamina)
        {
            state= AlienState.following;
        }
        else if(distance > followReachedThreshold)
        {
             state = AlienState.roaming;
        }
        else if(distance > attackReachedThreshold)
        {
            anim.SetLayerWeight(anim.GetLayerIndex("Attacking"), 0f);
        }
    }

    private void Idle()
    {
        anim.SetFloat("Blend", 0);
        rb.velocity = Vector3.zero;
        StartCoroutine(SwitchToRoaming());
        Stamina = 100;
    }

    private void Roaming()
    {
        anim.SetFloat("Blend", 2);
        agent.SetDestination(RandomDestination);
        agent.speed = 2;
        StartCoroutine(SwitchToIdle());
    }

    private void Follow()
    {
        anim.SetFloat("Blend", 2);
        agent.SetDestination(playerObject.transform.position);
        agent.speed = 2;
    }

    private void Running()
    {
        anim.SetFloat("Blend", 5);
        agent.SetDestination(playerObject.transform.position);
        agent.speed = 3.5f;
        if(!coroutineActive)
        {
            StartCoroutine(StaminaLosing());
            coroutineActive = true;
        }
        if(Stamina <= 0)
        {
            StartCoroutine(OutOfStamina());
            noStamina = true;
            StopCoroutine(StaminaLosing());
            coroutineActive = false;
        }
    }

    private void Attack()
    {
        anim.SetLayerWeight(anim.GetLayerIndex("Attacking"), 1f);
        agent.speed = 0;
        if(!attackCoroutineActive && Stamina > 0)
        {
            attackCoroutineActive = true;
            StartCoroutine(WaitToAttack());
            //Stamina -= 20;
        }
        else if(Stamina <= 0)
        {
            StartCoroutine(OutOfStamina());
        }
        this.gameObject.transform.LookAt(playerObject.transform.position);
    }

    private void Death()
    {
        agent.speed = 0;
        IsDead = true;
        anim.SetInteger("RngDeath", Random.Range(1, 3));
        anim.SetTrigger("Dead");
    }

    IEnumerator SwitchToRoaming()
    {
        yield return new WaitForSeconds(idleTimer);
        state = AlienState.roaming;
    }

    IEnumerator SwitchToIdle()
    {
        roamingTimer = Random.Range(5, 20);
        yield return new WaitForSeconds(roamingTimer);
        StopCoroutine(SwitchToIdle());
    }

    IEnumerator StaminaLosing()
    {
        yield return new WaitForSeconds(1f);
        //Stamina -= 10;
        coroutineActive = false;
    }

    IEnumerator OutOfStamina()
    {
        yield return new WaitForSeconds(5f);
        state = AlienState.idle;
    }

    IEnumerator WaitToAttack()
    {
        yield return new WaitForSeconds(clip.length + 1);
        anim.SetTrigger("Attacking");
        attackCoroutineActive = false;
    }

    public void DealDmg()
    {
        if(distance < 1)
        {
            player.playerHealth -= damage;
            playerObject.GetComponentInChildren<Animator>().SetTrigger("TakenDmg");
            StartCoroutine(Dc.FadeIn(image));
        }
    }
}
