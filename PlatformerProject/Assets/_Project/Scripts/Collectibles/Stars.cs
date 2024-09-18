using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stars : PickUp
{
    public TextMeshProUGUI StarText;
    public TextMeshProUGUI StarCollected;

    IEnumerator StarCollectedText()
    {
        StarCollected.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        StarCollected.gameObject.SetActive(false);
    }

    public override void Activate()
    {
        StartCoroutine(StarCollectedText());
        StarText.text = "1/1";
        base.Activate();
    }
}
