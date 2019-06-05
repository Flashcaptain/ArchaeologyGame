using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void SetPause()
    {
        Time.timeScale = 0;
    }

    public void SetResume()
    {
        Time.timeScale = 1;
    }
}
