using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class control : MonoBehaviour
{
    private Actionmap myPlayerMovement;

    public Vector2 direction;

    public float speed;

    bool walking = false;

    [SerializeField] private Rigidbody rigidBody;

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
        rigidBody.velocity = new Vector3(direction.x * speed, 0, direction.y * speed);
        if(walking)
        {
            if(speed < 5)
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
