using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public InputAction moveAction;

    public Vector2 direction;

    [SerializeField] private float speed;

    public Rigidbody rigidBody;

    private void Start()
    {
        moveAction.performed += Move;
        moveAction.canceled += StopMove;
        moveAction.Enable();
    }

    private void OnDisable()
    {
        moveAction.performed -= Move;
        moveAction.canceled -= StopMove;
        moveAction.Disable();
    }

    private void Move(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>().normalized;
    }

    private void StopMove(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>().normalized;
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = new Vector3(direction.x * speed, 0, direction.y * speed);
    }
}
