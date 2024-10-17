using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] bool switching;

    public GameObject upperTarget;
    public GameObject lowerTarget;

    private bool coroutineActive;

    private void FixedUpdate()
    {
        movePlatform();
    }

    //moves platform forward and backwards and switches when a destination is reached
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

        if(transform.position ==  upperTarget.transform.position || transform.position == lowerTarget.transform.position)
        {
            if (coroutineActive == false)
            {
                coroutineActive = true;
                StartCoroutine(WaitToSwitch());
            }
        }
    }

    //switches the bool
    IEnumerator WaitToSwitch()
    {
        yield return new WaitForSeconds(1f);
        switch (switching)
        {
            case true:
                switching = false;
                break;
            case false:
                switching = true;
                break;
        }
        coroutineActive = false;
    }
}
