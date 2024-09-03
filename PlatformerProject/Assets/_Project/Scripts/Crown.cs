using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Crown : MonoBehaviour
{
    public GameObject playerScript;
    public TextMeshProUGUI Crowns;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerScript.GetComponent<Player>().crownAmount++;
            Crowns.text = "Coins:" + playerScript.GetComponent<Player>().crownAmount;
            Destroy(this.gameObject);
        }
    }
}
