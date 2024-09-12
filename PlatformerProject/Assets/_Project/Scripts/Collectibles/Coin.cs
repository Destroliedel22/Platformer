using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public TextMeshProUGUI Coins;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ScoreManager.Instance.coinAmount++;
            Coins.text = "Coins:" + ScoreManager.Instance.coinAmount;
            Destroy(this.gameObject);
        }
    }
}
