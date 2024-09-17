using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public TextMeshProUGUI Coins;

    private ParticleSystem particleSystem;

    private void Awake()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            ScoreManager.Instance.coinAmount++;
            particleSystem.Play();
            Coins.text = "Coins:" + ScoreManager.Instance.coinAmount;
            StartCoroutine(WaitToDestroy());
        }
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(particleSystem.main.duration);
        Destroy(this.gameObject);
    }
}
