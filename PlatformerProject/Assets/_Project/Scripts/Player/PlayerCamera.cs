using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Camera cam;

    public float RotationSpeed = 5f;

    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
    }

    public Vector3 GetCameraMoveDirection(Vector2 input)
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

    public void RotatePlayer(Vector3 moveDirection)
    {
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

        rigidBody.rotation = Quaternion.Slerp(rigidBody.rotation, targetRotation, RotationSpeed * Time.deltaTime);
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
}
