using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : MonoBehaviour
{
    public Collider other;

    //abstract class for all pickups
    public virtual void Activate()
    {
        Destroy(gameObject);
    }
}
