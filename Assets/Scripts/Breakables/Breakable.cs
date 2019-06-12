using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Breakable : MonoBehaviour
{
    [SerializeField]
    protected int _durability;

    [SerializeField]
    private AudioClip _interactSound;

    private AudioManager _audioManager;

    protected int _currentDurability;

    protected virtual void Start()
    {
        _currentDurability = _durability;
        _audioManager = FindObjectOfType<AudioManager>();
    }

    public virtual void RemoveDurability(int damage, Tools _equippedTools)
    {
        _audioManager.PlayAudio(_interactSound);
        _currentDurability -= damage;
        if (_currentDurability <= 0)
        {
            _currentDurability = 0;
            Remove();
        }
    }

    protected abstract void Remove();
}
