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
        anim.SetBool("Jumping", true);
    }

    private void StopJump(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<float>();
        anim.SetBool("Jumping", false);
    }

    private void FixedUpdate()
    {
        if (direction == 1 && isGrounded)
        {
            rigidBody.AddForce(Vector3.up * force);
            isGrounded = false;
            downForce = beginDownForce;
        }

        if (isGrounded == false)
        {
            rigidBody.AddForce(Vector3.down * downForce);
            if(downForce < 1000)
            {
                downForce += 10;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
