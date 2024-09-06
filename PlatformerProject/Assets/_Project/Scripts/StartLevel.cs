using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class StartLevel : MonoBehaviour
{
    private Actionmap myInteractButton;

    public int timer = 12;
    public bool timerGoing = false;

    public bool CrownPickedUp = false;

    public GameObject Spawnpoint;

    public GameObject coinsAndCrown;
    public GameObject Fences;

    public GameObject player;

    public TextMeshProUGUI timerText;

    public float click;

    private void Awake()
    {
        myInteractButton = new Actionmap();
    }

    private void OnEnable()
    {
        myInteractButton.Enable();
        myInteractButton.Controls.Enable();
        myInteractButton.Controls.Interact.performed += interact;
        myInteractButton.Controls.Interact.performed += Stopinteract;
    }

    private void interact(InputAction.CallbackContext value)
    {
        click = value.ReadValue<float>();
    }

    private void Stopinteract(InputAction.CallbackContext value)
    {
        click = value.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        Timer();
    }

    public void Timer()
    {
        if (timerGoing)
        {
            timerText.text = "time left:" + timer.ToString();
        }

        if (timer < 0)
        {
            timer = 12;
            player.transform.localPosition = Spawnpoint.transform.localPosition;
            timerGoing = false;
            timerText.text = null;
            coinsAndCrown.SetActive(false);
        }

        if (CrownPickedUp)
        {
            StopCoroutine(timerCountDown());
            timer = 12;
            timerText.text = null;
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
