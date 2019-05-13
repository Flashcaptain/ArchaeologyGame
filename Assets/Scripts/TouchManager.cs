using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{
    public static TouchManager Instance;

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

    public Vector3 GetTouchPosition()
    {
        if (Input.touchCount > 0)
        {
            Vector3 pos = new Vector3((Input.GetTouch(0).position.x - 960) / 100, (Input.GetTouch(0).position.y - 540) / 100, 0);
            return pos;
        }
        return Vector3.zero;
    }
}
