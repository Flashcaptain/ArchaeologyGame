using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainObject : Breakable
{
    [SerializeField]
    private RemoveLayers _manager;

    [SerializeField]
    private Slider _slider;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [SerializeField]
    private List<Sprite> _sprites;

    [SerializeField]
    private Sprite _destroySprite;

    private string _name;
    private int _outlines = 0;

    public override void RemoveDurability(int damage, Tools _equippedTools)
    {
        if (_equippedTools == Tools.Trowel || _equippedTools == Tools.Shovel)
        {
            base.RemoveDurability(damage, _equippedTools);
            _slider.maxValue = _durability;
            _slider.value = _durability - _currentDurability;
            if (_currentDurability != 0)
            {
                _spriteRenderer.sprite = _sprites[Mathf.Clamp(Mathf.RoundToInt(GetDurabilityPercent() / 100f * _sprites.Count), 0, _sprites.Count - 1)];
            }
        }
    }

    protected override void Remove()
    {
        _spriteRenderer.sprite = _destroySprite;
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

    private int GetDurabilityPercent()
    {
        float val = (float)_currentDurability / (float)_durability * 100f;
        int intVal = Mathf.RoundToInt(val);
        return intVal;
    }
}
