using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class control : MonoBehaviour
{
    private Actionmap myPlayerMovement;

    public Vector2 direction;

    public Animator anim;

    public float speed;
    public float maxSpeed;

    public float rotationSpeed = 5f;

    bool walking = false;

    public Rigidbody rigidBody;

    [SerializeField] private Camera cam;

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

    private Vector3 cameraRight(Camera cam)
    {
        Vector3 right = cam.transform.right;
        right.y = 0f;
        return right.normalized;
    }

    private Vector3 cameraForward(Camera cam)
    {
        Vector3 forward = cam.transform.forward;
        forward.y = 0f;
        return forward.normalized;
    }

    private void StopMove(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>().normalized;
        walking = false;
    }

    private void FixedUpdate()
    {
        anim.SetFloat("Speed", speed);
        Movement();
    }

    private void Movement()
    {
        if (walking)
        {
            if (speed < maxSpeed)
            {
                StartCoroutine(Accelerate());
            }
        }
        else
        {
            speed = 0;
        }

        Vector3 moveDirection = GetCameraMoveDirection(direction);

        if (moveDirection.magnitude > 0.1f)
        {
            rigidBody.AddForce(moveDirection * speed + new Vector3(0, rigidBody.velocity.y, 0));

            RotatePlayer(moveDirection);
        }
        else
        {
            rigidBody.AddForce(new Vector3(0, rigidBody.velocity.y, 0));
        }
    }

    private Vector3 GetCameraMoveDirection(Vector2 input)
    {
        Vector3 cameraForward = cam.transform.forward;
        Vector3 cameraRight = cam.transform.right;

        cameraForward.y = 0;
        cameraRight.y = 0;

        cameraForward.Normalize();
        cameraRight.Normalize();

        Vector3 moveDirection = (cameraRight * input.x + cameraForward * input.y);
        return moveDirection;
    }

    private void RotatePlayer(Vector3 moveDirection)
    {
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

        rigidBody.rotation = Quaternion.Slerp(rigidBody.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    IEnumerator Accelerate()
    {
        speed++;
        yield return new WaitForSeconds(10f);
    }
}
