using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string _mapScene;

    public void PressStartButton()
    {
        SceneManager.LoadScene(_mapScene);
    }

    public void PressQuitButton()
    {
        Application.Quit();
    }
}
