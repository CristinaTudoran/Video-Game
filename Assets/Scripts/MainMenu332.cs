using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

// Loads the intro scene when the play button is pressed in the main menu.
public class MainMenu332 : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("intro_19_11_2020");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}