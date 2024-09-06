using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Crown : MonoBehaviour
{
    public GameObject playerScript;
    public TextMeshProUGUI Crowns;

    public GameObject startRing;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerScript.GetComponent<Player>().crownAmount++;
            Crowns.text = "Crowns:" + playerScript.GetComponent<Player>().crownAmount;
            startRing.GetComponent<StartLevel>().CrownPickedUp = true;
            Destroy(this.gameObject);
        }
    }
}
