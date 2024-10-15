using System.Collections;
using UnityEngine;
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
