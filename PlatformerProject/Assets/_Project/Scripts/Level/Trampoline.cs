using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] float force;

    private Rigidbody rb;

    //pushes player up when touching gameobject
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            rb = other.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * force);
        }
    }
}
