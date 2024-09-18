using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CastleAccess : MonoBehaviour
{
    public TextMeshProUGUI CrownsNeeded;

    private void FixedUpdate()
    {
        CrownsNeeded.text = ScoreManager.Instance.crownAmount + "/3";
    }
}
