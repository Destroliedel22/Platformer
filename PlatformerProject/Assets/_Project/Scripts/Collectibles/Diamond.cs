using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Diamond : PickUp
{
    public override void Activate()
    {
        StartCoroutine(WaitToLoadScene());
    }

    //loads main menu scene
    IEnumerator WaitToLoadScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }
}
