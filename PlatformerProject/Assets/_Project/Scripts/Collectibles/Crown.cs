using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Crown : PickUp
{
    public TextMeshProUGUI Crowns;

    public GameObject startRing;

    bool crownPickedUp;

    private void Start()
    {
        crownPickedUp = false;
    }

    public override void Activate()
    {
        if(!crownPickedUp)
        {
            ScoreManager.Instance.crownAmount++;
            crownPickedUp = true;
        }
        Crowns.text = "Crowns:" + ScoreManager.Instance.crownAmount;
        base.Activate();
    }
}
