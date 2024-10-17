using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCanvas : MonoBehaviour
{
    //loads game scene
    public void respawn()
    {
        SceneManager.LoadScene(1);
    }

    //loads main menu scene
    public void backToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
