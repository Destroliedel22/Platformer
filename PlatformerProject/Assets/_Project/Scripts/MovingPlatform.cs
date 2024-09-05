using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public GameObject upperTarget;

    public GameObject lowerTarget;

    [SerializeField]
    int speed;

    bool switching;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
        }
    }

    private void movePlatform()
    {
        if(!switching)
        {
            transform.position = Vector3.MoveTowards(transform.position, upperTarget.transform.position, speed * Time.deltaTime);
        }

        else if(switching)
        {
            transform.position = Vector3.MoveTowards(transform.position, lowerTarget.transform.position, speed * Time.deltaTime);
        }

        if(transform.position ==  upperTarget.transform.position)
        {
            switching = true;
        }

        else if (transform.position == lowerTarget.transform.position)
        {
            switching = false;
        }
    }
}
