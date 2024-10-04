using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class control : MonoBehaviour
{
    [SerializeField] private Camera cam;

    public float Speed;
    public float MaxSpeed;
    public float RotationSpeed = 5f;

    private Rigidbody rigidBody;
    private Actionmap myPlayerMovement;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        anim.SetFloat("Speed", Speed);
        Movement();
        rigidBody.angularVelocity = Vector3.zero;
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

    private void Movement()
    {
        if (WalkInput.Instance.walking)
        {
            if (Speed < MaxSpeed)
            {
                StartCoroutine(Accelerate());
            }
        }
        else
        {
            Speed = 0;
        }

        Vector3 moveDirection = GetCameraMoveDirection(WalkInput.Instance.Direction);

        if (moveDirection.magnitude > 0.1f)
        {
            rigidBody.AddForce(moveDirection * Speed + new Vector3(0, rigidBody.velocity.y, 0));

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

        rigidBody.rotation = Quaternion.Slerp(rigidBody.rotation, targetRotation, RotationSpeed * Time.deltaTime);
    }

    IEnumerator Accelerate()
    {
        Speed++;
        yield return new WaitForSeconds(10f);
    }
}
