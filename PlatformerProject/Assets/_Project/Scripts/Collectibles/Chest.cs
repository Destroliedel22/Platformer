using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : MonoBehaviour
{
    public GameObject Lid;
    Key key;

    private void Awake()
    {
        key = GetComponentInChildren<Key>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (InteractInput.Instance.click == 1)
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
