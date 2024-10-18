using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class DollyMovement : MonoBehaviour
{
    private Actionmap myPlayerMovement;

    public Vector2 direction;

    CinemachineDollyCart CinemachineDollyCart;
    PlayableDirector director;

    public StartLevel startLevel;

    private void Awake()
    {
        myPlayerMovement = new Actionmap();
        CinemachineDollyCart = this.gameObject.GetComponent<CinemachineDollyCart>();
        director = FindObjectOfType<PlayableDirector>();
    }

    private void OnEnable()
    {
        myPlayerMovement.Enable();
        myPlayerMovement.Movement.Enable();
        myPlayerMovement.Movement.move.performed += Move;
        myPlayerMovement.Movement.move.canceled += StopMove;
    }

    private void Move(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>().normalized;
    }

    private void StopMove(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>().normalized;
    }
}
