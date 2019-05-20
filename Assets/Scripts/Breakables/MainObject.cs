using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObject : Breakable
{
    [SerializeField]
    private RemoveLayers _manager;

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
        _manager.TriggerLevelEnd(false, _currentDurability);
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
            _manager.TriggerLevelEnd(true, _currentDurability);
        }
    }

    private int GetDurabilityPercent(int currentDurability, int totalDurability)
    {
        float val = currentDurability / totalDurability * 100;
        int intVal = Mathf.RoundToInt(val);
        return intVal;
    }
}
