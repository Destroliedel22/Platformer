using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Crown : PickUp
{
    public GameObject playerScript;
    public TextMeshProUGUI Crowns;

    public GameObject startRing;

    public override void Activate()
    {
        ScoreManager.Instance.crownAmount++;
        Crowns.text = "Crowns:" + ScoreManager.Instance.crownAmount;
        base.Activate();
    }
}
