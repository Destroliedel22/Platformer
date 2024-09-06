using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotate : MonoBehaviour
{
    public InputAction rotateAction;

    public Vector2 direction;

    [SerializeField] float speed;

    private void Start()
    {
        rotateAction.performed += Rotate;
        //rotateAction.canceled += StopRotate;
        rotateAction.Enable();
    }

    private void OnDisable()
    {
        rotateAction.performed -= Rotate;
        //rotateAction.canceled -= StopRotate;
        rotateAction.Disable();
    }

    private void Rotate(InputAction.CallbackContext value)
    {
        direction = value.ReadValue<Vector2>().normalized;
    }

    private void FixedUpdate()
    {
        //this.gameObject.transform.rotation = new Quaternion(0, direction.y * speed, 0, 0);
    }
}
