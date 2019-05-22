using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    public void PressLevelButton(int mapIndex)
    {
        UnlockManager.Instance.PressMapButton(mapIndex);
    }
}
