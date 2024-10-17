using TMPro;
using UnityEngine;

public class Crown : PickUp
{
    public TextMeshProUGUI Crowns;
    public GameObject startRing;

    private bool crownPickedUp;

    private void Start()
    {
        crownPickedUp = false;
    }

    //you get 1 crown and destroys the crown
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
