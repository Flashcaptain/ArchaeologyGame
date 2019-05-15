using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObject : Breakable
{
    private string _name;
    private int _outlines = 0;

    public override void RemoveDurability(int damage, Tools _equippedTools)
    {
        if (_equippedTools == Tools.Trowel || _equippedTools == Tools.Shovel)
        {
            base.RemoveDurability(damage, _equippedTools);
        }
    }

    protected override void Remove()
    {
        Debug.Log("Defeat"); 
    }

    public void AddChild()
    {
        _outlines++;
    }

    public void RemoveChild()
    {
        _outlines--;
        if (_outlines == 0)
        {
            Debug.Log("Victory");
        }
    }
}
