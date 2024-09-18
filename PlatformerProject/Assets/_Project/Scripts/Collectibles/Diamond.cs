using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Diamond : PickUp
{
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
