using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Diamond : PickUp
{
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.CompareTag("Player"))
    //    {
    //        StartCoroutine(WaitToLoadScene());
    //    }
    //}

    IEnumerator WaitToLoadScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }

    public override void Activate()
    {
        StartCoroutine(WaitToLoadScene());
    }
}
