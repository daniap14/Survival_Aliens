using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class playbutton : MonoBehaviour
{
   public void PlayButton()
    {
        SceneManager.LoadScene("Ville");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainScreen");
    }

    public void GameOverExit()
    {
        SceneManager.LoadScene("MainScreen");
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
