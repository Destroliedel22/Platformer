using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    public InputAction jumpAction;

    private void Start()
    {
        jumpAction.performed += Jump;
        //jumpAction.canceled += StopJump;
        jumpAction.Enable();
    }

    private void OnDisable()
    {
        jumpAction.performed -= Jump;
        //jumpAction.canceled -= StopJump;
        jumpAction.Disable();
    }

    private void Jump(InputAction.CallbackContext value)
    {
        Debug.Log("Jump");
    }







    private void Update()
    {
        Keyboard mKeyboard = Keyboard.current;

        if(mKeyboard != null )
        {
            if(mKeyboard.spaceKey.wasPressedThisFrame)
            {
                //Debug.Log("SpaceKey was pressed");
            }

            if(mKeyboard.spaceKey.isPressed)
            {
                //Debug.Log("SpaceKey is being pressed");
            }

            if (mKeyboard.spaceKey.wasReleasedThisFrame)
            {
                //Debug.Log("SpaceKey was released");
            }
        }
    }
}
