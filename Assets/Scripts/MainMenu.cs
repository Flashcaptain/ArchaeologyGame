using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PressMenuButton(string sceneName)
    {
        StartCoroutine(UnlockManager.Instance.LoadingScreen(sceneName));
    }

    public void PressQuitButton()
    {
        Application.Quit();
    }
}
