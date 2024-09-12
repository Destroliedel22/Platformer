using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void StartGame()
    {
        StartCoroutine(WaitToLoadScene());
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator WaitToLoadScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}
