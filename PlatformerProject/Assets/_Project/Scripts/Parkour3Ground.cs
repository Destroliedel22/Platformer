using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parkour3Ground : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook freeLookCam;
    [SerializeField] CinemachineVirtualCamera virtualCam;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            freeLookCam.gameObject.SetActive(false);
            virtualCam.gameObject.SetActive(true);
        }
    }
}
