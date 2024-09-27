using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stars : PickUp
{
    public TextMeshProUGUI StarText;

    public override void Activate()
    {
        StarText.text = "1/1";
        base.Activate();
    }
}
