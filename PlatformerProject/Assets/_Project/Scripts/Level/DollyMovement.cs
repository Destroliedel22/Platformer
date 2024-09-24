using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class DollyMovement : MonoBehaviour
{
    private Actionmap myPlayerMovement;

    public Vector2 direction;

    CinemachineDollyCart CinemachineDollyCart;

    private void Awake()
    {
        myPlayerMovement = new Actionmap();
        CinemachineDollyCart = this.gameObject.GetComponent<CinemachineDollyCart>();
    }

    private void OnEnable()
    {
        myPlayerMovement.Enable();
        myPlayerMovement.Controls.Enable();
        myPlayerMovement.Controls.move.performed += Move;
        myPlayerMovement.Controls.move.canceled += StopMove;
    }

    private void Move(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>().normalized;
    }

    private void StopMove(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>().normalized;
    }


    private void FixedUpdate()
    {
        if (this.gameObject.activeSelf)
        {
            if(direction.y == 1)
            {
                CinemachineDollyCart.m_Speed = 1;
            }
            else if(direction.y == -1)
            {
                CinemachineDollyCart.m_Speed = -1;
            }
            else
            {
                CinemachineDollyCart.m_Speed = 0;
            }
        }
    }
}
