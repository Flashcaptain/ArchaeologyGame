using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainObject : Breakable
{
    public Sprite _currentSprite;

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

    [Range(0, 99)]
    [SerializeField]
    private float _camShakeIntensity = 55;

    [Range(0, 1)]
    [SerializeField]
    private float _camShakeDuration = 0.2f;

    [SerializeField]
    private string _name;

    private int _outlines = 0;

    private void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            while (_outlines != 0)
            {
                RemoveChild();
            }
        }
    }

    protected void Start()
    {
        base.Start();
        _manager = FindObjectOfType<RemoveLayers>();
        _slider = FindObjectOfType<Slider>();
    }

    public override void RemoveDurability(int damage, Tools _equippedTools)
    {
        Debug.Log(_currentDurability);

        if (_equippedTools == Tools.Trowel || _equippedTools == Tools.Shovel)
        {
            base.RemoveDurability(damage, _equippedTools);

            StartCoroutine(Shake(Camera.main.gameObject, _camShakeDuration, damage));

            _slider.maxValue = _durability;
            _slider.value = _durability - _currentDurability;
            if (_currentDurability != 0)
            {
                _currentSprite = _sprites[Mathf.Clamp(Mathf.RoundToInt(GetDurabilityPercent() / 100f * _sprites.Count), 0, _sprites.Count - 1)];
                _spriteRenderer.sprite = _currentSprite;
            }
        }
    }

protected override void Remove()
    {
        _spriteRenderer.sprite = _destroySprite;
        _manager.TriggerLevelEnd(false, GetDurabilityPercent(), _name, _currentSprite);
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
            _manager.TriggerLevelEnd(true, GetDurabilityPercent(), _name, _currentSprite);
        }
    }

    public int GetDurabilityPercent()
    {
        float val = (float)_currentDurability / (float)_durability * 100f;
        int intVal = Mathf.RoundToInt(val);
        return intVal;
    }

    private IEnumerator Shake(GameObject camera, float duration, int damage)
    {
        Vector3 originalPos = camera.transform.localPosition;

        float elapsed = 0.0f;

            Handheld.Vibrate();

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * ((float)damage / (100 - _camShakeIntensity));
            float y = Random.Range(-1f, 1f) * ((float)damage / (100 - _camShakeIntensity));

            camera.transform.localPosition = new Vector3(originalPos.x + x,originalPos.y + y, originalPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        camera.transform.localPosition = originalPos;
    }
}
