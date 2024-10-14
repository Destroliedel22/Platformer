using Cinemachine;
using Unity.XR.CoreUtils;
using UnityEngine;

public class GoToFreeLook : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook freeLookCamera;
    [SerializeField] CinemachineVirtualCamera virtualCamera;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponentInParent<XROrigin>().enabled == false)
        {
            virtualCamera.gameObject.SetActive(false);
            freeLookCamera.gameObject.SetActive(true);
        }
    }
}
