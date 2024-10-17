using System.Collections;
using TMPro;
using UnityEngine;

public class CastleAccess : MonoBehaviour
{
    public TextMeshProUGUI CrownsNeeded;

    //when having 3 crowns the door opens
    private void FixedUpdate()
    {
        CrownsNeeded.text = ScoreManager.Instance.crownAmount + "/3";
        if(ScoreManager.Instance.crownAmount == 3)
        {
            StartCoroutine(WaitToDestroy());
        }
    }

    //waits 5 seconds to destroy object
    IEnumerator WaitToDestroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
