using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canvas : MonoBehaviour
{
    public GameObject playerHead;

    private void FixedUpdate()
    {
        gameObject.transform.LookAt(playerHead.transform);
    }
}
