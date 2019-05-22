using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockManager : MonoBehaviour
{
    public static UnlockManager Instance;

    public List<Map> _maps = new List<Map>();

    private Map _currentMap;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PressMapButton(int index)
    {
        Map pressedMap = _maps[index];
        if (!pressedMap._locked)
        {
            _currentMap = pressedMap;
            SceneManager.LoadScene(_currentMap._name);
        }
    }

    public void CompleteCurrentLevel(int highscore)
    {
        int index = _maps.IndexOf(_currentMap);

        _maps[index]._completed = true;
        if (highscore > _maps[index]._highscore)
        {
            _maps[index]._highscore = highscore;
        }
        _maps[index + 1]._locked = false;
    }
}
