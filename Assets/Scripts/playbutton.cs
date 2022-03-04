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

    public void OptionsButton()
    {
        SceneManager.LoadScene("Options");
    }

    public void ExitButton()
    {
        SceneManager.LoadScene("MainScreen");
    }

    public void GameOverExit()
    {
        SceneManager.LoadScene("MainScreen");
    }
}
