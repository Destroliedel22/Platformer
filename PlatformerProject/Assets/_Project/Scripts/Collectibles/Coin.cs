using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : PickUp
{
    public TextMeshProUGUI Coins;

    private ParticleSystem ParticleSystem;

    private void Awake()
    {
        ParticleSystem = GetComponentInChildren<ParticleSystem>();
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(ParticleSystem.main.duration);
        base.Activate();
    }

    public override void Activate()
    {
        ScoreManager.Instance.coinAmount++;
        ParticleSystem.Play();
        Coins.text = "Coins:" + ScoreManager.Instance.coinAmount;
        //StartCoroutine(WaitToDestroy());
        base.Activate();
    }
}
