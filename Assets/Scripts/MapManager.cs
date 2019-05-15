using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public List<Map> _maps = new List<Map>();

    public void PressLevelButton(int levelIndex)
    {
        Map pressedMap = _maps[levelIndex - 1];
        if (!pressedMap._locked)
        {
            SceneManager.LoadScene(pressedMap._name);
        }
    }
}
