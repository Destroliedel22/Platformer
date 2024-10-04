using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class WalkInput : MonoBehaviour
{
    public Vector2 Direction;
    public bool walking = false;

    private static WalkInput instance;

    public static WalkInput Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(WalkInput)) as WalkInput;
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

    private void OnEnable()
    {
        myPlayerMovement.Enable();
        myPlayerMovement.Controls.Enable();
        myPlayerMovement.Controls.move.performed += Move;
        myPlayerMovement.Controls.move.canceled += StopMove;
    }

    private void Move(InputAction.CallbackContext value)
    {
        Direction = value.ReadValue<Vector2>().normalized;
        walking = true;
    }

    private void StopMove(InputAction.CallbackContext value)
    {
        Direction = value.ReadValue<Vector2>().normalized;
        walking = false;
    }
}
