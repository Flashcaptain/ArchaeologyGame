using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Breakable : MonoBehaviour
{
    [SerializeField]
    protected int _durability;

    public virtual void RemoveDurability(int damage, Tools _equippedTools)
    {
        Debug.Log("damage: " + damage);
        _durability -= damage;
        Debug.Log("durability: " + _durability);
        if (_durability <= 0)
        {
            Remove();
            Debug.Log("remove");
        }
    }

    protected abstract void Remove();
}
