using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Alien : NPC
{
    public ScriptableObject AlienStats;

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

    private Rigidbody rb;
    private Animator anim;
    public GameObject playerObject;
    private Player player;

    Vector3 RandomDestination;
    [SerializeField] float destinationReachedThreshold;

    [Header("timers")]
    public float idleTimer;
    public float roamingTimer;
    public float attackTimer;

    [Header("Detecting Range")]
    [SerializeField] float distance;
    [SerializeField] float followReachedThreshold;
    [SerializeField] float runReachedThreshold;
    [SerializeField] float attackReachedThreshold;

    bool noStamina;
    bool coroutineActive;
    [SerializeField] bool attackCoroutineActive;

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
        }
    }

    private void FixedUpdate()
    {
        if (!agent.pathPending && agent.remainingDistance <= destinationReachedThreshold && state == AlienState.roaming)
        {
            RandomDestination = new Vector3(transform.position.x + Random.Range(-10, 10), 0, transform.position.z + Random.Range(-10, 10));
        }
        distanceToPlayer();
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
        rb.velocity = new Vector3(0, 0, 0);
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
        anim.speed = 1f;
        agent.speed = 0;
        if(!attackCoroutineActive && Stamina > 0)
        {
            Debug.Log("attack");
            anim.SetBool("Attacking", true);
            attackCoroutineActive = true;
            StartCoroutine(WaitToAttack());
            Stamina -= 20;
        }
        if(Stamina <= 0)
        {
            anim.SetBool("Attacking", false);
            StartCoroutine(OutOfStamina());
        }
        this.gameObject.transform.LookAt(playerObject.transform.position);
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
    }

    IEnumerator StaminaLosing()
    {
        yield return new WaitForSeconds(1f);
        Stamina -= 10;
        coroutineActive = false;
    }

    IEnumerator OutOfStamina()
    {
        yield return new WaitForSeconds(5f);
        state = AlienState.idle;
    }

    IEnumerator WaitToAttack()
    {
        yield return new WaitForSeconds(attackTimer);
        anim.SetBool("Attacking", false);
        attackCoroutineActive = false;
        player.playerHealth -= 40;
    }
}
