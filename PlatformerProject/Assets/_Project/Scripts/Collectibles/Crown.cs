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
            ScoreManager.Instance.crownAmount++;
            Crowns.text = "Crowns:" + ScoreManager.Instance.crownAmount;
            startRing.GetComponent<StartLevel>().CrownPickedUp = true;
            Destroy(this.gameObject);
        }
    }
}
