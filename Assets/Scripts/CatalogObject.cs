using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatalogObject : LockableObject
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void CheckLock(Map thisMap, Text text, Image img)
    {
        base.CheckLock(thisMap, text, img);

        if (!thisMap._completed)
        {
            img.sprite = _lockedSprite;
            text.text = "Locked";
        }
        else
        {
            img.sprite = _unlockedSprite;
            text.text = thisMap._objectName;
        }
    }
}
