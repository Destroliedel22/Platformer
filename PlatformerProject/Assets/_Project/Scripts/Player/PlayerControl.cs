using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] Image sprintImg;
    [SerializeField] Sprite sprintOn;
    [SerializeField] Sprite sprintOff;

    public float Speed;
    public float MaxSpeed;

    private bool sprintToggleCooldown;
    private Rigidbody rigidBody;
    private Actionmap myPlayerMovement;
    private Animator anim;
    private PlayerCamera playerCamera;
    private bool sprinting;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rigidBody = GetComponent<Rigidbody>();
        playerCamera = GetComponent<PlayerCamera>();
    }

    private void FixedUpdate()
    {
        anim.SetFloat("Speed", Speed);
        Movement();
        Sprint();
        SprintImg();
        rigidBody.angularVelocity = Vector3.zero;
        if(Speed > MaxSpeed)
        {
            Speed = MaxSpeed;
        }
    }

    //moves and rotates the player according to input and camera
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

        Vector3 moveDirection = playerCamera.GetCameraMoveDirection(WalkInput.Instance.WalkDirection);

        if (moveDirection.magnitude > 0.1f)
        {
            rigidBody.AddForce(moveDirection * Speed + new Vector3(0, rigidBody.velocity.y, 0));

            playerCamera.RotatePlayer(moveDirection);
            
        }
        else
        {
            rigidBody.AddForce(new Vector3(0, rigidBody.velocity.y, 0));
        }
    }

    //sprinting when button is pressed
    private void Sprint()
    {
        if(WalkInput.Instance.Sprinting == 1 && sprintToggleCooldown == false)
        {
            sprintToggleCooldown = true;
            switch(sprinting)
            {
                case true:
                    sprinting = false;
                    MaxSpeed = 20;
                    anim.SetBool("Sprinting", false);
                break;
                case false:
                    MaxSpeed = 40;
                    sprinting = true;
                    anim.SetBool("Sprinting", true);
                    break;
            }
        }
        else if(WalkInput.Instance.Sprinting == 0)
        {
            sprintToggleCooldown = false;
        }
    }

    private void SprintImg()
    {
        if(sprintImg != null)
        {
            if (sprinting)
            {
                sprintImg.sprite = sprintOn;
            }
            else
            {
                sprintImg.sprite = sprintOff;
            }
        }
    }

    //speed accelerates over time
    IEnumerator Accelerate()
    {
        Speed++;
        yield return new WaitForSeconds(10f);
    }
}
