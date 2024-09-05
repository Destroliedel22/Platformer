using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public TextMeshProUGUI StarText;
    public TextMeshProUGUI StarCollected;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(StarCollectedText());
            StarText.text = "1/1";
            Destroy(this.gameObject);
        }
    }

    IEnumerator StarCollectedText()
    {
        StarCollected.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        StarCollected.gameObject.SetActive(false);
    }
}
