using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StartRing : MonoBehaviour
{
    public int timer = 12;
    public bool timerGoing = false;

    public bool CrownPickedUp = false;

    public GameObject Spawnpoint;

    public GameObject player;

    public TextMeshProUGUI timerText;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && timerGoing == false)
        {
            StartCoroutine(timerCountDown());
            timerGoing = true;
        }
    }

    private void Update()
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
        }

        if(CrownPickedUp)
        {
            StopCoroutine(timerCountDown());
            timer = 12;
            timerText.text = null;
            //you got the crown
        }
    }

    IEnumerator timerCountDown()
    {
        while(timer > 0)
        {
            yield return new WaitForSeconds(1);
            timer--;
        }
    }
}
