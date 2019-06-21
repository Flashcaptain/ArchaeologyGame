using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchButton : MonoBehaviour
{
    public void SwitchScene(string sceneName)
    {
        StartCoroutine(UnlockManager.Instance.LoadingScreen(sceneName));
    }
}
