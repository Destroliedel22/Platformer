using Cinemachine;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Camera XRcam;
    [SerializeField] CinemachineFreeLook CmFLCam;
    [SerializeField] GameObject XROrigin;
    [SerializeField] CinemachineClearShot CmCSCam;

    public float RotationSpeed = 5f;
    public Camera liveCam;

    private Rigidbody rigidBody;

    private void Awake()
    {
        rigidBody = this.gameObject.GetComponent<Rigidbody>();

        if (UnityEngine.XR.XRSettings.enabled)
        {
            XROrigin.gameObject.SetActive(true);
            CmCSCam.gameObject.SetActive(true);
            liveCam = XROrigin.GetComponentInChildren<Camera>();
        }
        else
        {
            cam.gameObject.SetActive(true);
            CmFLCam.gameObject.SetActive(true);
            liveCam = cam;
        }
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
