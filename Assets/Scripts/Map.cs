using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Map
{
    public string _name = "Default";

    public string _objectName = "Default Object";

    public bool _locked = false;

    public bool _completed = false;

    public float _highscore = 0f;
}
