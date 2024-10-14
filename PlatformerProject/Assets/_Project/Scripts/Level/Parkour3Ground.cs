using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Parkour3Ground : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook freeLookCam;
    [SerializeField] CinemachineVirtualCamera virtualCam;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponentInParent<XROrigin>().enabled == false)
        {
            freeLookCam.gameObject.SetActive(false);
            virtualCam.gameObject.SetActive(true);
        }
    }
}
