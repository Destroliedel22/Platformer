using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Playables;
using Cinemachine;

public class StartLevel : MonoBehaviour
{
    private Actionmap myInteractButton;

    public bool CrownPickedUp = false;

    public GameObject coinsAndCrown;

    public float click;


    private void Awake()
    {
        myInteractButton = new Actionmap();
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
        if(click == 1)
        {
            begin();
        }
    }

    public void begin()
    {
        coinsAndCrown.SetActive(true);
        if (CrownPickedUp)
        {
            coinsAndCrown.SetActive(false);
        }
    }
}
