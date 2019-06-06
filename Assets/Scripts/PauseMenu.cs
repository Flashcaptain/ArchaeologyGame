using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private Text _durability;

    public void SetPause()
    {
        Time.timeScale = 0;
        _durability.text = FindObjectOfType<MainObject>().GetDurabilityPercent() + "%";
    }

    public void SetResume()
    {
        Time.timeScale = 1;
    }
}
