using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleBlock : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
