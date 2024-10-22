using Cinemachine;
using Unity.XR.CoreUtils;
using UnityEngine;

public class GoToFreeLook : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook freeLookCamera;
    [SerializeField] CinemachineFreeLook MobileCam;
    [SerializeField] CinemachineVirtualCamera virtualCamera;

    //activates 3d camera if not in level 3
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(freeLookCamera == null)
            {
                MobileCam.gameObject.SetActive(true);
            }
            else
            {
                freeLookCamera.gameObject.SetActive(true);
            }
            virtualCamera.gameObject.SetActive(false);
        }
    }
}
