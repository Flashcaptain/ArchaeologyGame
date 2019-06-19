using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UnlockManager : MonoBehaviour
{
    public static UnlockManager Instance;

    public List<Map> _maps = new List<Map>();

    public Map _currentMap;

    [SerializeField]
    private GameObject _loadingScreenObj;

    private int _highestCompletedLevel = 0;

    private string _mainSceneName = "MainScene";

    private AsyncOperation async;

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

    public void Reset()
    {
        for (int i = 0; i < _maps.Count; i++)
        {
            _maps[i]._locked = true;
            _maps[i]._completed = false;
            _maps[i]._highscore = 0;
        }
        _maps[0]._locked = false;
    }


    public void PressMapButton(int index)
    {
        Map pressedMap = _maps[index];
        if (!pressedMap._locked)
        {
            _currentMap = pressedMap;
            StartCoroutine(UnlockManager.Instance.LoadingScreen(_mainSceneName));
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

    public IEnumerator LoadingScreen(string lvlName)
    {
        GameObject go = Instantiate(_loadingScreenObj);
        go.SetActive(true);
        async = SceneManager.LoadSceneAsync(lvlName);
        async.allowSceneActivation = false;

        while (!async.isDone)
        {
            if (async.progress == 0.9f)
            {
                async.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
