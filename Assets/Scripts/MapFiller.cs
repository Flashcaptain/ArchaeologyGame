using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFiller : MonoBehaviour
{
    [SerializeField]
    private float _sizeX;

    [SerializeField]
    private float _sizeY;

    [SerializeField]
    private float _offSet;

    [SerializeField]
    private List<GroundObject> _grass;

    [SerializeField]
    private List<GroundObject> _dirt;

    private MainObject _mainObject;
    private Vector2 _centerPos;

    private void Start()
    {
        _mainObject = UnlockManager.Instance._currentMap._mainObject;

        float spawnSizeX = _sizeX - _offSet;
        float spawnSizeY = _sizeY - _offSet;
        _centerPos = new Vector2(Random.Range(-spawnSizeX, spawnSizeX), Random.Range(-spawnSizeY, spawnSizeY));

        SpawnMainObject();
        SpawnGrass();
        SpawnDirt();
    }

    private void SpawnMainObject()
    {
        if (_mainObject == null)
        {
            return;
        }
        Instantiate(_mainObject.gameObject, new Vector3(_centerPos.x, _centerPos.y, 3), _mainObject.gameObject.transform.rotation);
    }

    private void SpawnGrass()
    {
        for (float x = -_sizeX; x <= _sizeX; x++)
        {
            for (float y = -_sizeY; y <= _sizeY; y++)
            {
                float floatDistance = Vector2.Distance(_centerPos, new Vector2(x, y));
                floatDistance = floatDistance / 2;
                int intDistance = Mathf.RoundToInt(floatDistance);

                if (intDistance >= _grass.Count)
                {
                    intDistance = _grass.Count - 1;
                }
                GroundObject grass = Instantiate(_grass[intDistance], new Vector3(x, y, 0), transform.rotation = Quaternion.Euler(0, 0, Random.RandomRange(0, 360)));
            }
        }
    }

    private void SpawnDirt()
    {
        for (float x = -_sizeX; x <= _sizeX; x += 0.5f)
        {
            for (float y = -_sizeY; y <= _sizeY; y += 0.2f)
            {
                Instantiate(_dirt[Random.Range(0,_dirt.Count)], new Vector3(x, y, 1), transform.rotation = Quaternion.Euler(0, 0, Random.RandomRange(0, 360)));
            }
        }
    }
}
