using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LadderInput : MonoBehaviour
{
    private static LadderInput instance;

    public static LadderInput Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(LadderInput)) as LadderInput;
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

        myPlayerMovement = new Actionmap();
    }
    private Actionmap myPlayerMovement;

    public float direction;
    public float downDirection;

    private void OnEnable()
    {
        myPlayerMovement.Enable();
        myPlayerMovement.Ladder.Enable();
        myPlayerMovement.Ladder.ClimbingUp.performed += ClimbingUp;
        myPlayerMovement.Ladder.ClimbingUp.canceled += StopClimbingUp;
        myPlayerMovement.Ladder.ClimbingDown.performed += ClimbingDown;
        myPlayerMovement.Ladder.ClimbingDown.canceled += StopClimbingDown;
    }

    private void ClimbingUp(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<float>();
    }

    private void StopClimbingUp(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<float>();
    }

    private void ClimbingDown(InputAction.CallbackContext value)
    {
        downDirection = value.ReadValue<float>();
    }

    private void StopClimbingDown(InputAction.CallbackContext value)
    {
        downDirection = value.ReadValue<float>();
    }
}
