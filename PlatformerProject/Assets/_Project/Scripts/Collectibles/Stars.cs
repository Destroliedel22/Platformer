using TMPro;

public class Stars : PickUp
{
    public TextMeshProUGUI StarText;

    public override void Activate()
    {
        StarText.text = "1/1";
        base.Activate();
    }
}
