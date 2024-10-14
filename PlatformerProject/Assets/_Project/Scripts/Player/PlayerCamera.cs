using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] public Camera cam;
    [SerializeField] public Camera XRcam;

    public float RotationSpeed = 5f;
    public Camera liveCam;

    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
        if (XRcam.gameObject.activeSelf == true)
        {
            liveCam = XRcam;
        }
        else
        {
            liveCam = cam;
        }
    }

    public Vector3 GetCameraMoveDirection(Vector2 input)
    {
        Vector3 cameraForward = liveCam.gameObject.transform.forward;
        Vector3 cameraRight = liveCam.gameObject.transform.right;

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
}
