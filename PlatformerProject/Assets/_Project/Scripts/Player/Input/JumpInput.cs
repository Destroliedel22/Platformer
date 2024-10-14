using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpInput : MonoBehaviour
{
    private static JumpInput instance;

    public static JumpInput Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(JumpInput)) as JumpInput;
            }
            return instance;
        }
    }

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        myJumpButton = new Actionmap();
    }
    private Actionmap myJumpButton;

    public float JumpClick;

    private void OnEnable()
    {
        myJumpButton.Enable();
        myJumpButton.Jump.Enable();
        myJumpButton.Jump.Jump.performed += Jump;
        myJumpButton.Jump.Jump.canceled += StopJump;
    }

    private void Jump(InputAction.CallbackContext value)
    {
        JumpClick = value.ReadValue<float>();
    }

    private void StopJump(InputAction.CallbackContext value)
    {
        JumpClick = value.ReadValue<float>();
    }
}
