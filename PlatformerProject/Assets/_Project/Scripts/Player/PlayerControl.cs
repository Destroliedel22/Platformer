using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float Speed;
    public float MaxSpeed;

    private Rigidbody rigidBody;
    private Actionmap myPlayerMovement;
    private Animator anim;
    private PlayerCamera playerCamera;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        playerCamera = GetComponent<PlayerCamera>();
    }

    private void FixedUpdate()
    {
        anim.SetFloat("Speed", Speed);
        Movement();
        Sprinting();
        rigidBody.angularVelocity = Vector3.zero;
        if(Speed > MaxSpeed)
        {
            Speed = MaxSpeed;
        }
    }

    //moves and rotates the player according to input and camera
    private void Movement()
    {
        if (WalkInput.Instance.walking)
        {
            if (Speed < MaxSpeed)
            {
                StartCoroutine(Accelerate());
            }
        }
        else
        {
            Speed = 0;
        }

        Vector3 moveDirection = playerCamera.GetCameraMoveDirection(WalkInput.Instance.WalkDirection);

        if (moveDirection.magnitude > 0.1f)
        {
            rigidBody.AddForce(moveDirection * Speed + new Vector3(0, rigidBody.velocity.y, 0));

            playerCamera.RotatePlayer(moveDirection);
            
        }
        else
        {
            rigidBody.AddForce(new Vector3(0, rigidBody.velocity.y, 0));
        }
    }

    //sprinting when button is held
    private void Sprinting()
    {
        if(WalkInput.Instance.Sprinting == 1)
        {
            MaxSpeed = 40;
            anim.SetBool("Sprinting", true);
        }
        else
        {
            MaxSpeed = 20;
            anim.SetBool("Sprinting", false);
        }
    }

    //speed accelerates over time
    IEnumerator Accelerate()
    {
        Speed++;
        yield return new WaitForSeconds(10f);
    }
}
