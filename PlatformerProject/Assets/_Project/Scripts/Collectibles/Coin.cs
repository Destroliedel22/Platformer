using System.Collections;
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
        Coins.text = "Coins:" + ScoreManager.Instance.coinAmount;
        base.Activate();
    }
}
