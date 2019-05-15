using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : Breakable
{
    [SerializeField]
    private MainObject _mainObject;

    private void Start()
    {
        _mainObject.AddChild();
    }

    public override void RemoveDurability(int damage, Tools _equippedTools)
    {
        if (_equippedTools == Tools.Trowel)
        {
            Remove();
        }
    }

    protected override void Remove()
    {
        _mainObject.RemoveChild();
        Destroy(this.gameObject);
    }
}
