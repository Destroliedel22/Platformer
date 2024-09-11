using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZoneController : MonoBehaviour
{
    public Vector3 windDirection;
    public float windForce = 5f;


    private void OnTriggerStay(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if(rb != null )
        {
            rb.AddForce(windDirection * windForce);
        }
    }
}
