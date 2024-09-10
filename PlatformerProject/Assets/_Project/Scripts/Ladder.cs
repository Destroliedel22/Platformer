using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ladder : MonoBehaviour
{
    private Actionmap myPlayerMovement;
    private Actionmap myInteractButton;

    public float direction;
    public float downDirection;
    public float click;

    public float speed;

    private bool up;
    private bool down;

    private bool onLadder = false;

    private Rigidbody rb;

    private void Awake()
    {
        myPlayerMovement = new Actionmap();
        myInteractButton = new Actionmap();
    }

    private void OnEnable()
    {
        myPlayerMovement.Enable();
        myPlayerMovement.Ladder.Enable();
        myPlayerMovement.Ladder.ClimbingUp.performed += ClimbingUp;
        myPlayerMovement.Ladder.ClimbingUp.canceled += StopClimbingUp;
        myPlayerMovement.Ladder.ClimbingDown.performed += ClimbingDown;
        myPlayerMovement.Ladder.ClimbingDown.canceled += StopClimbingDown;
        myInteractButton.Enable();
        myInteractButton.Interact.Enable();
        myInteractButton.Interact.Interact.performed += interact;
        myInteractButton.Interact.Interact.canceled += Stopinteract;
    }

    private void ClimbingUp(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<float>();
    }

    private void StopClimbingUp(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<float>();
    }

    private void ClimbingDown(InputAction.CallbackContext value)
    {
        downDirection = value.ReadValue<float>();
    }

    private void StopClimbingDown(InputAction.CallbackContext value)
    {
        downDirection = value.ReadValue<float>();
    }

    private void interact(InputAction.CallbackContext value)
    {
        click = value.ReadValue<float>();
    }

    private void Stopinteract(InputAction.CallbackContext value)
    {
        click = value.ReadValue<float>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (click == 1 && onLadder == false)
        {
            onLadder = true;
        }
        else if (click == 1 && onLadder == true)
        {
            onLadder = false;
        }

        rb = other.gameObject.GetComponent<Rigidbody>();
        other.gameObject.GetComponent<PlayerJump>().downForce = 0;
        rb.useGravity = false;

        if (onLadder)
        {
            other.gameObject.GetComponent<control>().enabled = false;
            if (direction > 0)
            {
                rb.velocity = new Vector3(0, direction * speed, 0);
            }
            else
            {
                //rb.velocity = new Vector3();
            }

            if (downDirection > 0)
            {
                rb.velocity = new Vector3(0, downDirection * -speed, 0);
            }
            else
            {
                //rb.velocity = new Vector3();
            }
        }
        else
        {
            other.gameObject.GetComponent<control>().enabled = true;
        }
    }
}
