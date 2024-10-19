using UnityEngine;

public class Void : MonoBehaviour
{
    //if player touches water they die
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Player>().playerHealth = 0;
        }
    }
}
