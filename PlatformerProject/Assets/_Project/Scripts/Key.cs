using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : PickUp
{
    public bool KeyPickedUp;

    private void Start()
    {
        KeyPickedUp = false;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.CompareTag("Player"))
    //    {
    //        KeyPickedUp = true;
    //        this.gameObject.SetActive(false);
    //    }
    //}

    public override void Activate()
    {
        KeyPickedUp = true;
        this.gameObject.SetActive(false);
        base.Activate();
    }
}
