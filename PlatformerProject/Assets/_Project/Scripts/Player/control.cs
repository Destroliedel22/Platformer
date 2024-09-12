using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.InputSystem;

public class control : MonoBehaviour
{
    private Actionmap myPlayerMovement;

    public Vector2 direction;

    public Animator anim;

    public float speed;
    public float maxSpeed = 5f;

    bool walking = false;

    public Rigidbody rigidBody;

    private void Awake()
    {
        myPlayerMovement = new Actionmap();
    }

    private void OnEnable()
    {
        myPlayerMovement.Enable();
        myPlayerMovement.Controls.Enable();
        myPlayerMovement.Controls.move.performed += Move;
        myPlayerMovement.Controls.move.canceled += StopMove;
    }

    private void Move(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>().normalized;
        walking = true;
    }

    private void StopMove(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>().normalized;
        walking = false;
    }

    private void FixedUpdate()
    {
        anim.SetFloat("Speed", speed);
        if (walking)
        {
            rigidBody.AddForce(direction.x * speed, 0, direction.y * speed);
            if (speed < maxSpeed)
            {
                StartCoroutine(Accelerate());
            }
        }
        else
        {
            speed = 0;
        }
    }

    IEnumerator Accelerate()
    {
        speed++;
        yield return new WaitForSeconds(10f);
    }
}
