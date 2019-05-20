using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Breakable : MonoBehaviour
{
    [SerializeField]
    protected int _durability;

    protected int _currentDurability;

    private void Start()
    {
        _currentDurability = _durability;
    }

    public virtual void RemoveDurability(int damage, Tools _equippedTools)
    {
        Debug.Log("damage: " + damage);
        _currentDurability -= damage;
        Debug.Log("durability: " + _currentDurability);
        if (_currentDurability <= 0)
        {
            Remove();
            Debug.Log("remove");
        }
    }

    protected abstract void Remove();
}
