using Cinemachine;
using UnityEngine;

public class GoToFreeLook : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook freeLookCamera;
    [SerializeField] CinemachineVirtualCamera virtualCamera;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            virtualCamera.gameObject.SetActive(false);
            freeLookCamera.gameObject.SetActive(true);
        }
    }
}
