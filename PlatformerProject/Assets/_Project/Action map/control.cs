using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class control : MonoBehaviour
{
    private Actionmap myPlayerMovement;

    public Vector2 direction;

    [SerializeField] private float speed;

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
        //myPlayerMovement.Controls.move.ReadValue<Vector2>();
        direction = value.ReadValue<Vector2>().normalized;
    }

    private void StopMove(InputAction.CallbackContext value)
    {
        //myPlayerMovement.Controls.move.ReadValue<Vector2>();
        direction = value.ReadValue<Vector2>().normalized;
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector3(direction.x * speed, 0, direction.y * speed);
    }
}
