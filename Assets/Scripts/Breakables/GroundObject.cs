using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObject : Breakable
{
    [SerializeField]
    private bool _isGrass;

    public override void RemoveDurability(int damage, Tools _equippedTools)
    {
        if ((_equippedTools == Tools.Brush && !_isGrass) || _equippedTools == Tools.Shovel)
        {
            base.RemoveDurability(damage, _equippedTools);
        }
    }

    protected override void Remove()
    {
        Destroy(this.gameObject);
    }
}
