using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackInput : MonoBehaviour
{
    private static AttackInput instance;

    public static AttackInput Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(AttackInput)) as AttackInput;
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

        myAttackButton = new Actionmap();
    }
    private Actionmap myAttackButton;

    public float AttackClick;

    private void OnEnable()
    {
        myAttackButton.Enable();
        myAttackButton.Attacking.Enable();
        myAttackButton.Attacking.Punch.performed += Punch;
        myAttackButton.Attacking.Punch.canceled += StopPunch;
    }

    private void Punch(InputAction.CallbackContext value)
    {
        AttackClick = value.ReadValue<float>();
    }

    private void StopPunch(InputAction.CallbackContext value)
    {
        AttackClick = value.ReadValue<float>();
    }
}
