using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lastEnd : MonoBehaviour
{
    public void PlayGame()
    {
        STATIC.health = 100;
        STATIC.count = 5;
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
