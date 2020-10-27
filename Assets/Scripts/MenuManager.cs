﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToGameSelect()
    {
        SceneManager.LoadScene("GameSelect");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
