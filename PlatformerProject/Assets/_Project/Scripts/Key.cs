using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool KeyPickedUp;

    private void Start()
    {
        KeyPickedUp = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            KeyPickedUp = true;
            this.gameObject.SetActive(false);
        }
    }
}
