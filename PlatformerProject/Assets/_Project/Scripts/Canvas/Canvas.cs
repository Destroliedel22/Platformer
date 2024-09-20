using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    public GameObject target;

    private void FixedUpdate()
    {
        gameObject.transform.LookAt(target.transform);
    }
}
