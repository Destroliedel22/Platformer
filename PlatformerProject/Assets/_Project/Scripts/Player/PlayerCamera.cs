using Cinemachine;
using Unity.XR.CoreUtils;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float RotationSpeed = 5f;
    public Camera liveCam;

    private Rigidbody rigidBody;
    private XROrigin xROrigin;

    private void Awake()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody>();
        liveCam = Camera.main;
        xROrigin = FindObjectOfType<XROrigin>();
    }

    //returns the direction the players moves according to camera
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

    //rotates player according to camera
    public void RotatePlayer(Vector3 moveDirection)
    {
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);

        rigidBody.rotation = Quaternion.Slerp(rigidBody.rotation, targetRotation, RotationSpeed * Time.deltaTime);
    }
}
