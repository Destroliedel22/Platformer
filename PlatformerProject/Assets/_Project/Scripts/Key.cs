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

    public override void Activate()
    {
        KeyPickedUp = true;
        this.gameObject.SetActive(false);
        base.Activate();
    }
}
