using UnityEngine;

public class Water : MonoBehaviour
{
    public Player player;

    //if player touches water they die
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player.playerHealth = 0;
        }
    }
}
