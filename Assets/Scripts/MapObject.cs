using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapObject : MonoBehaviour
{
    [SerializeField]
    private Sprite _lockedSprite;

    [SerializeField]
    private Sprite _unlockedSprite;

    [SerializeField]
    private int _index;

    private void Start()
    {
        Map thisMap = UnlockManager.Instance.GetMap(_index);
        Text text = GetComponentInChildren<Text>();

        if (thisMap._locked)
        {
            GetComponent<Image>().sprite = _lockedSprite;
            text.text = "Locked";
        }
        else
        {
            GetComponent<Image>().sprite = _unlockedSprite;
            text.text = thisMap._name;

            if (thisMap._completed)
            {
                text.text += " " + thisMap._highscore;
            }
        }
    }
}
