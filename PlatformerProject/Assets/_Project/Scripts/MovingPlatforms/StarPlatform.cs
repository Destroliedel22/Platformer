using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPlatform : MonoBehaviour
{
    public GameObject upperTarget;

    public GameObject lowerTarget;

    [SerializeField]
    int speed;

    bool switching;
    public bool touched = false;

    private void FixedUpdate()
    {
        if (touched)
        {
            movePlatform();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            touched = true;
        }
    }

    private void movePlatform()
    {
        if (!switching)
        {
            transform.position = Vector3.MoveTowards(transform.position, upperTarget.transform.position, speed * Time.deltaTime);
        }

        else if (switching)
        {
            transform.position = Vector3.MoveTowards(transform.position, lowerTarget.transform.position, speed * Time.deltaTime);
        }

        if (transform.position == upperTarget.transform.position)
        {
            switching = true;
        }

        else if (transform.position == lowerTarget.transform.position)
        {
            switching = false;
        }
    }
}
