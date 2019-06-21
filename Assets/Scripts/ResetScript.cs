using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _menu;

    public void OpenMenu()
    {
        _menu.SetActive(true);
    }

    public void CloseMenu()
    {
        _menu.SetActive(false);
    }

    public void ResetProgress()
    {
        PlayerPrefs.DeleteAll();
        UnlockManager.Instance.Reset();
    }
}
