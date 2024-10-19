using UnityEngine;

public class Apple : PickUp
{
    public override void Activate()
    {
        other.gameObject.GetComponent<Player>().playerHealth += 25;
        base.Activate();
    }
}
