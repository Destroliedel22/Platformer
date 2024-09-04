using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject playerScript;
    public TextMeshProUGUI Coins;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerScript.GetComponent<Player>().coinAmount++;
            Coins.text = "Coins:" + playerScript.GetComponent<Player>().coinAmount;
            Destroy(this.gameObject);
        }
    }
}
