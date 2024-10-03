using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] float force;

    Rigidbody rb;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            rb = other.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * force);
        }
    }
}
