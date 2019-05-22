using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockableObject : MonoBehaviour
{
    [SerializeField]
    protected Sprite _lockedSprite;

    [SerializeField]
    protected Sprite _unlockedSprite;

    [SerializeField]
    protected int _index;

    protected virtual void Start()
    {
        Map thisMap = UnlockManager.Instance.GetMap(_index);
        Text text = GetComponentInChildren<Text>();
        Image img = GetComponent<Image>();

        CheckLock(thisMap, text, img);
    }

    protected virtual void CheckLock(Map thisMap, Text text, Image img)
    { }
}
