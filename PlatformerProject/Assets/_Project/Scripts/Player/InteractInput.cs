using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractInput : MonoBehaviour
{
    private static InteractInput instance;

    public static InteractInput Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(InteractInput)) as InteractInput;
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

        myInteractButton = new Actionmap();
    }

    private Actionmap myInteractButton;

    public float click;

    private void OnEnable()
    {
        myInteractButton.Enable();
        myInteractButton.Interact.Enable();
        myInteractButton.Interact.Interact.performed += interact;
        myInteractButton.Interact.Interact.canceled += Stopinteract;
    }

    private void interact(InputAction.CallbackContext value)
    {
        click = value.ReadValue<float>();
    }

    private void Stopinteract(InputAction.CallbackContext value)
    {
        click = value.ReadValue<float>();
    }
}
