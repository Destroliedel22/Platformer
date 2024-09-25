using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCanvas : MonoBehaviour
{
    public void respawn()
    {
        SceneManager.LoadScene(1);
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
