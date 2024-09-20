using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using UnityEngine.Playables;

public class StartLevel : MonoBehaviour
{
    private Actionmap myInteractButton;

    public int timer = 12;
    public bool timerGoing = false;
    public bool CoroutineStarted = false;

    public bool CrownPickedUp = false;

    //public GameObject Spawnpoint;

    public GameObject coinsAndCrown;

    public GameObject player;

    public TextMeshProUGUI timerText;

    public float click;

    private PlayableDirector director;

    private void Awake()
    {
        myInteractButton = new Actionmap();
        director = FindObjectOfType<PlayableDirector>();
    }

    private void OnEnable()
    {
        myInteractButton.Enable();
        myInteractButton.Interact.Enable();
        myInteractButton.Interact.Interact.performed += interact;
        myInteractButton.Interact.Interact.canceled += Stopinteract;
    }

    private void interact(InputAction.CallbackContext value)
    {
        click = value.ReadValue<float>();
    }

    private void Stopinteract(InputAction.CallbackContext value)
    {
        click = value.ReadValue<float>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(click == 1)
        {
            Timer();
            timerGoing = true;
            director.Play();
        }
    }

    private void FixedUpdate()
    {
        if (timerGoing)
        {
            timerText.text = "time left:" + timer.ToString();
        }
    }

    public void Timer()
    {
        if(CoroutineStarted == false)
        {
            StartCoroutine(timerCountDown());
            CoroutineStarted = true;
        }
        coinsAndCrown.SetActive(true);

        if (timer <= 0)
        {
            timer = 16;
            timerGoing = false;
            timerText.text = null;
            coinsAndCrown.SetActive(false);
            CoroutineStarted = false;
        }

        else if (CrownPickedUp)
        {
            StopCoroutine(timerCountDown());
            timer = 12;
            timerText.text = null;
            timerGoing = false;
            CoroutineStarted = false;
            if (coinsAndCrown != null)
            {
                coinsAndCrown.SetActive(false);
            }
            //you got the crown
        }
    }

    IEnumerator timerCountDown()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1);
            timer--;
        }
    }


}
