using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Parkour3Ground : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook freeLookCam;
    [SerializeField] CinemachineFreeLook MobileCam;
    [SerializeField] CinemachineVirtualCamera virtualCam;

    //switches camera to 2d camera for 3rd level when touching the ground
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(freeLookCam == null)
            {
                MobileCam.gameObject.SetActive(false);
            }
            else
            {
                freeLookCam.gameObject.SetActive(false);
            }
            virtualCam.gameObject.SetActive(true);
        }
    }
}
