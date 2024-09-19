using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
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

    private Animator anim;
    private Rigidbody rb;

    public float health;

    public float switchRoaming;

    [SerializeField] private float speed;
    [SerializeField] private float Stamina;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        state = AlienState.idle;
        health = 200;
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
            case AlienState.death:
                Death();
                break;
        }
    }

    private void Idle()
    {
        anim.SetFloat("Blend", 0);
        rb.velocity = new Vector3(0, 0, 0);
        StartCoroutine(SwitchToRoaming());
    }

    private void Roaming()
    {
        anim.SetFloat("Blend", 2);
        //walk
        StartCoroutine(SwitchToIdle());
    }

    private void Follow()
    {
        anim.SetFloat("Blend", 2);
        //on detecting player follow him on roaming speed
        //switch to running when near player
    }

    private void Running()
    {
        anim.SetFloat("Blend", 5);
        //follow player with higher speed
        //switch to attack when really near player
        //if stamina > 0 keep running otherwise switch to walking
    }

    private void Attack()
    {
        anim.SetLayerWeight(anim.GetLayerIndex("Attacking"), 1f);
        //attack animation while still running or standing still
        //deal dmg to player when hit
        //switch between attack animation and fighting stance
        //switch to running or following depending on range to player
        //if stamina is 0 fighting stance
    }

    private void Death()
    {
        //everytime enemy takes dmg check if health > 0
        //death animation
        //all other layers off
    }

    IEnumerator SwitchToRoaming()
    {
        yield return new WaitForSeconds(switchRoaming);
        state = AlienState.roaming;
    }

    IEnumerator SwitchToIdle()
    {
        yield return new WaitForSeconds(switchRoaming);
        state = AlienState.idle;
    }
}
