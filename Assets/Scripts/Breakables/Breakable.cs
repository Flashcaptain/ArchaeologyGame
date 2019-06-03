using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Breakable : MonoBehaviour
{
    [SerializeField]
    protected int _durability;

    protected int _currentDurability;

    protected virtual void Start()
    {
        _currentDurability = _durability;
    }

    public virtual void RemoveDurability(int damage, Tools _equippedTools)
    {
        _currentDurability -= damage;
        if (_currentDurability <= 0)
        {
            _currentDurability = 0;
            Remove();
        }
    }

    protected abstract void Remove();
}
