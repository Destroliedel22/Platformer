using UnityEngine;

public class Apple : MonoBehaviour
{
    //when picking up gives player hp
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().playerHealth += 25;
            Destroy(this.gameObject);
        }
    }
}
