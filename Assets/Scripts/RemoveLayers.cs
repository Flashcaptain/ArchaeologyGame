using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RemoveLayers : MonoBehaviour
{
    [SerializeField]
    private Tools _equippedTools;

    [SerializeField]
    private List<int> _toolDamage;

    [SerializeField]
    private GameObject _levelEndUI;

    [SerializeField]
    private float _defaultCameraSize = 5f;

    [SerializeField]
    private float _zoomMultiplier = 2f;

    [SerializeField]
    private Text _timeText;

    [SerializeField]
    private Text _timeTextPauseMenu;

    [SerializeField]
    private AudioClip _zoomSound;

    [SerializeField]
    private AudioClip _zoomOutSound;

    [SerializeField]
    private AudioClip _victorySound;

    [SerializeField]
    private AudioClip _defeatSound;

    [SerializeField]
    private AudioClip _fastSoundTrack;

    [SerializeField]
    private AudioSource _audioSource;

    [SerializeField]
    private Sprite _hourGlass;

    private int _timeMinutes = 10;

    private int _timeSeconds = 30;

    private bool _gameInProgress = true;

    private bool _zoomedIn = false;

    private AudioManager _audioManager;

    public void SelectTool(int tool)
    {
        _equippedTools = (Tools)tool;
    }

    private void Awake()
    {
        _timeMinutes = UnlockManager.Instance._currentMap._timeInMinutes;
        _timeSeconds = UnlockManager.Instance._currentMap._timeInSeconds;
    }

    private void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        Camera.main.orthographicSize = _defaultCameraSize;
        StartCoroutine(Timer());
    }

    private void Update()
    {
        if (_gameInProgress)
        {
            if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
            {                
                Vector3 _touchPos = TouchManager.Instance.GetTouchPosition();
                
                RaycastHit2D hit = Physics2D.Raycast(_touchPos, Vector2.zero);
                if (hit.collider == null)
                {
                    return;
                }

                if (_equippedTools == Tools.Shovel && (Input.GetMouseButtonDown(0) || Input.GetTouch(0).phase == TouchPhase.Began))
                {
                }
                else if (_equippedTools == Tools.Brush && (Input.GetMouseButton(0) || Input.GetTouch(0).phase == TouchPhase.Moved))
                {
                }
                else if (_equippedTools == Tools.Trowel && (Input.GetMouseButton(0) || Input.GetTouch(0).phase == TouchPhase.Moved))
                {
                }else if (_equippedTools == Tools.MagnifyingGlass && (Input.GetMouseButtonDown(0) || Input.GetTouch(0).phase == TouchPhase.Began))
                {
                    if (!EventSystem.current.IsPointerOverGameObject(0))
                    {
                        Camera cam = Camera.main;
                        if (_zoomedIn)
                        {
                            _audioManager.PlayAudio(_zoomOutSound ,true);
                            cam.orthographicSize = _defaultCameraSize;
                            cam.transform.position = new Vector3(0, 0, cam.transform.position.z);
                            _zoomedIn = false;
                        }
                        else
                        {
                            _audioManager.PlayAudio(_zoomSound , true);
                            _touchPos = new Vector3(Mathf.Clamp(_touchPos.x, -3.5f, 3.5f), Mathf.Clamp(_touchPos.x, -2f, 2f), cam.transform.position.z);
                            cam.orthographicSize /= _zoomMultiplier;
                            cam.transform.position = _touchPos;
                            _zoomedIn = true;
                        }
                        return;
                    }
                }

                else return;
                if (!EventSystem.current.IsPointerOverGameObject(0))
                {
                    RemoveLayer(hit, _toolDamage[(int)_equippedTools]);
                }
            }
        }
    }

    public void TriggerLevelEnd(bool victory, int percentage, string name, Sprite image)
    {
        _gameInProgress = false;
        _levelEndUI.SetActive(true);
        LevelEndUI ui = _levelEndUI.GetComponent<LevelEndUI>();

        if (victory)
        {
            ui._titleVictory.SetActive(true);
            ui._durabilityText.text = percentage + "%";
            ui._nameText.text = name;
            ui._backToMapButton.SetActive(true);
            UnlockManager.Instance.CompleteCurrentLevel(percentage);
            _audioManager.PlayAudio(_victorySound , true);
        }
        else
        {
            ui._titleDefeat.SetActive(true);
            ui._retryButton.SetActive(true);
            _audioManager.PlayAudio(_defeatSound, true);
        }

        ui._objectImage.sprite = image;
    }

    public void PressEndSceneButton(string sceneName)
    {
        StartCoroutine(UnlockManager.Instance.LoadingScreen(sceneName));
    }

    private void RemoveLayer(RaycastHit2D hit, int damage)
    {
        Breakable breakable = hit.collider.gameObject.GetComponent<Breakable>();

        if (breakable != null)
        {
            breakable.RemoveDurability(damage, _equippedTools);
        }
    }

    private IEnumerator Timer()
    {
        if (_timeSeconds == 0 && _timeMinutes == 0)
        {
            TriggerLevelEnd(false, 0, "", _hourGlass);
            LevelEndUI ui = _levelEndUI.GetComponent<LevelEndUI>();
            ui._nameText.text = "times up!";
        }
        else if (_gameInProgress)
        {
            _timeSeconds--;
            if (_timeSeconds == 0 && _timeMinutes != 0)
            {
                _timeMinutes--;
                _timeSeconds = 60;
            }

            if (_timeMinutes < 10 && _timeSeconds < 10)
            {
                _timeText.text = "0" + _timeMinutes + ":0" + _timeSeconds;
            }
            else if (_timeMinutes < 10)
            {
                _timeText.text = "0" + _timeMinutes + ":" + _timeSeconds;
            }
            else if (_timeSeconds < 10)
            {
                _timeText.text = _timeMinutes + ":0" + _timeSeconds;
            }
            else
            {
                _timeText.text = _timeMinutes + ":" + _timeSeconds;
            }
            if (_timeMinutes == 0)
            {
                _timeText.color = Color.red;
                _audioSource.clip = _fastSoundTrack;
                _audioSource.Play();
            }
            _timeTextPauseMenu.text = _timeText.text;
            yield return new WaitForSeconds(1);
            StartCoroutine(Timer());
        }
    }
}
