using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJump : MonoBehaviour
{
    public InputAction jumpAction;

    public float direction;

    public Rigidbody rigidBody;

    public bool isGrounded;

    public float force;
    public float downForce;
    private float beginDownForce;

    public Animator anim;

    private void Start()
    {
        jumpAction.performed += Jump;
        jumpAction.canceled += StopJump;
        jumpAction.Enable();

        beginDownForce = downForce;
    }

    private void OnDisable()
    {
        jumpAction.performed -= Jump;
        jumpAction.canceled -= StopJump;
        jumpAction.Disable();
    }

    private void Jump(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<float>();
    }

    private void StopJump(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        if (direction == 1 && isGrounded)
        {
            anim.SetBool("Jumping", true);
            rigidBody.AddForce(Vector3.up * force);
            isGrounded = false;
            downForce = beginDownForce;
        }
        else if(direction == 0)
        {
            anim.SetBool("Jumping", false);
        }

        if (isGrounded == false)
        {
            rigidBody.AddForce(Vector3.down * downForce);
            if(downForce < 100)
            {
                downForce += 5;
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if(collision.gameObject.CompareTag("MovingPlatform"))
        {
            isGrounded = true;
            this.gameObject.transform.SetParent(collision.transform, true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            isGrounded = false;
            this.gameObject.transform.SetParent(null, true);
        }
    }
}
