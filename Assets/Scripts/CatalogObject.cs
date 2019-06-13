using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatalogObject : MonoBehaviour
{
    public Sprite _sprite;

    public string _objectName;

    public string _catalogEntry;

    public int _index;

    protected void Start()
    {
        Map thisMap = UnlockManager.Instance.GetMap(_index);
        CheckLock(thisMap);
    }

    protected void CheckLock(Map thisMap)
    {
        if (!thisMap._completed)
        {
            gameObject.SetActive(false);
        }
    }
}
