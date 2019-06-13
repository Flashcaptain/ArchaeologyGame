using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockManager : MonoBehaviour
{
    public static UnlockManager Instance;

    public List<Map> _maps = new List<Map>();

    public Map _currentMap;

    private int _highestCompletedLevel = 0;

    private string _mainSceneName = "MainScene";

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
            return;
        }
        _highestCompletedLevel = PlayerPrefs.GetInt("LevelsCompleted");

        for (int i = 0; i < _highestCompletedLevel; i++)
        {
            _maps[i]._completed = true;
        }
        for (int i = 0; i < _highestCompletedLevel + 1; i++)
        {
            _maps[i]._locked = false;
        }

        for (int i = 0; i < _maps.Count; i++)
        {
            _maps[i]._highscore = PlayerPrefs.GetInt("highScoresList_" + i);
            Debug.Log(_maps[i]._highscore);
        }
    }


    public void PressMapButton(int index)
    {
        Map pressedMap = _maps[index];
        if (!pressedMap._locked)
        {
            _currentMap = pressedMap;
            SceneManager.LoadScene(_mainSceneName);
        }
    }

    public void CompleteCurrentLevel(int highscore)
    {
        int index = _maps.IndexOf(_currentMap);

        if (index > _highestCompletedLevel)
        {
            _highestCompletedLevel = index;
            PlayerPrefs.SetInt("LevelsCompleted", _highestCompletedLevel + 1);
        }

        _maps[index]._completed = true;
        if (highscore > _maps[index]._highscore)
        {
            _maps[index]._highscore = highscore;
        }
        _maps[index + 1]._locked = false;

        for (int i = 0; i < _maps.Count; i++)
        {
            PlayerPrefs.SetInt("highScoresList_" + i, _maps[i]._highscore);
        }
    }

    public Map GetMap(int index)
    {
        Map currentMap = _maps[index];
        return currentMap;
    }
}
