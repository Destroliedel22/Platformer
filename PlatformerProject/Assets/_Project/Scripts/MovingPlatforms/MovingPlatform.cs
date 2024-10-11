using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] int speed;
    [SerializeField] bool switching;
    [SerializeField] AnimationClip clip;
    [SerializeField] Animation anim;

    public GameObject upperTarget;
    public GameObject lowerTarget;

    private bool coroutineActive;
    //private Animator anim;

    private void Awake()
    {
        //anim = GetComponentInChildren<Animator>();
    }

    private void FixedUpdate()
    {
        movePlatform();
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

        if(transform.position ==  upperTarget.transform.position || transform.position == lowerTarget.transform.position)
        {
            if (coroutineActive == false)
            {
                coroutineActive = true;
                StartCoroutine(WaitToSwitch());
            }
        }
    }

    IEnumerator WaitToSwitch()
    {
        anim.Play();
        yield return new WaitForSeconds(clip.length);
        switch (switching)
        {
            case true:
                switching = false;
                //anim.SetBool("UpperTarget", false);
                break;
            case false:
                switching = true;
                //anim.SetBool("UpperTarget", true);
                break;
        }
        anim.gameObject.SetActive(false);
        coroutineActive = false;
    }
}
