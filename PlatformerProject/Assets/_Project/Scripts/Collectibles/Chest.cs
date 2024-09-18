using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : MonoBehaviour
{
    private Actionmap myInteractButton;
    public float click;

    public GameObject Lid;
    Key key;

    private void Awake()
    {
        myInteractButton = new Actionmap();
        key = GetComponentInChildren<Key>();
    }

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

    private void OnTriggerStay(Collider other)
    {
        if (click == 1)
        {
            if (key.KeyPickedUp)
            {
                Lid.transform.rotation = Quaternion.Euler(-90, 0, 0);
            }
            else
            {
                Debug.Log("Need Key");
            }
        }
    }
}
