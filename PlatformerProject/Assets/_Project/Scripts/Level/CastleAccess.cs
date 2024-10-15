using System.Collections;
using TMPro;
using UnityEngine;

public class CastleAccess : MonoBehaviour
{
    public TextMeshProUGUI CrownsNeeded;

    private void FixedUpdate()
    {
        CrownsNeeded.text = ScoreManager.Instance.crownAmount + "/3";
        if(ScoreManager.Instance.crownAmount == 3)
        {
            StartCoroutine(WaitToDestroy());
        }
    }

    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
