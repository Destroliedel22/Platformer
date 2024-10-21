using UnityEngine;

public class Apple : PickUp
{
    //heals player for 25 when touching
    public override void Activate()
    {
        other.gameObject.GetComponent<Player>().playerHealth += 25;
        base.Activate();
    }
}
