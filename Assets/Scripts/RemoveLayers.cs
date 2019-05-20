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

    private bool _gameInProgress = true;

    private bool _zoomedIn = false;

    public void SelectTool(int tool)
    {
        _equippedTools = (Tools)tool;
    }

    private void Start()
    {
        Camera.main.orthographicSize = _defaultCameraSize;
    }

    private void Update()
    {
        if (_gameInProgress)
        {
            if ((Input.GetMouseButtonDown(0) || Input.touchCount > 0))
            {                
                //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);
                Vector3 _touchPos = TouchManager.Instance.GetTouchPosition();
                
                RaycastHit2D hit = Physics2D.Raycast(_touchPos, Vector2.zero);
                if (hit.collider == null)
                {
                    return;
                }

                if (_equippedTools == Tools.Shovel && (Input.GetMouseButtonDown(0) || Input.GetTouch(0).phase == TouchPhase.Began))
                {
                    Debug.Log("Shovel");
                }
                else if (_equippedTools == Tools.Brush && (Input.GetMouseButton(0) || Input.GetTouch(0).phase == TouchPhase.Moved))
                {
                    Debug.Log("Brush");
                }
                else if (_equippedTools == Tools.Trowel && (Input.GetMouseButton(0) || Input.GetTouch(0).phase == TouchPhase.Moved))
                {
                    Debug.Log("Trowel");
                }else if (_equippedTools == Tools.MagnifyingGlass && (Input.GetMouseButtonDown(0) || Input.GetTouch(0).phase == TouchPhase.Began))
                {
                    if (!EventSystem.current.IsPointerOverGameObject(0))
                    {
                        Camera cam = Camera.main;
                        if (_zoomedIn)
                        {
                            cam.orthographicSize = _defaultCameraSize;
                            cam.transform.position = new Vector3(0, 0, cam.transform.position.z);
                            _zoomedIn = false;
                        }
                        else
                        {
                            _touchPos = new Vector3(Mathf.Clamp(_touchPos.x, -3.5f, 3.5f), Mathf.Clamp(_touchPos.x, -2f, 2f), cam.transform.position.z);
                            cam.orthographicSize /= _zoomMultiplier;
                            cam.transform.position = _touchPos;
                            _zoomedIn = true;
                        }
                        return;
                    }
                }

                else return;
                RemoveLayer(hit, _toolDamage[(int)_equippedTools]);
                Debug.Log("RemoveLayer");
            }
        }
    }

    public void TriggerLevelEnd(bool victory, int durability)
    {
        _gameInProgress = false;
        _levelEndUI.SetActive(true);
        LevelEndUI ui = _levelEndUI.GetComponent<LevelEndUI>();

        if (victory)
        {
            ui._titleText.text = "Victory";
            ui._durabilityText.text = "The value remaining value is " + durability;
            ui._backToMapButton.SetActive(true);
        }
        else
        {
            ui._titleText.text = "Defeat";
            ui._retryButton.SetActive(true);
        }
    }

    public void PressEndSceneButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void RemoveLayer(RaycastHit2D hit, int damage)
    {
        Breakable breakable = hit.collider.gameObject.GetComponent<Breakable>();

        if (breakable != null)
        {
            Debug.Log("hit breakable");
            breakable.RemoveDurability(damage , _equippedTools);
        }
    }
}
