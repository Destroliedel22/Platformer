using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    public Rigidbody rigidBody;
    public bool isGrounded;
    public float force;
    public float downForce;

    private float beginDownForce;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        Jump();
        DownForce();
    }

    //checks if touching ground
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if(other.gameObject.CompareTag("MovingPlatform"))
        {
            isGrounded = true;
            this.gameObject.transform.SetParent(other.transform, true);
        }
    }

    //checks if exiting ground
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        if (other.gameObject.CompareTag("MovingPlatform"))
        {
            isGrounded = false;
            this.gameObject.transform.SetParent(null, true);
        }
    }

    //if button clicked player jumps with animation
    private void Jump()
    {
        if (JumpInput.Instance.JumpClick == 1 && isGrounded)
        {
            anim.SetBool("Jumping", true);
            isGrounded = false;
            downForce = beginDownForce;
            rigidBody.AddForce(Vector3.up * force);
        }
        else if (JumpInput.Instance.JumpClick == 0)
        {
            anim.SetBool("Jumping", false);
        }
    }

    //pushes player down when in the air
    private void DownForce()
    {
        if (isGrounded == false)
        {
            rigidBody.AddForce(Vector3.down * downForce);
            if (downForce < 100)
            {
                downForce += 5;
            }
        }
    }
}
