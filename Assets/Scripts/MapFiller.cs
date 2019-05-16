using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFiller : MonoBehaviour
{
    [SerializeField]
    private int _sizeX;

    [SerializeField]
    private int _sizeY;

    [SerializeField]
    private List<GroundObject> _grass;

    [SerializeField]
    private List<GroundObject> _dirt;

    private void Start()
    {
        SpawnGrass();
        SpawnDirt();
    }

    private void SpawnGrass()
    {
        int spawnSizeX = _sizeX - 1;
        int spawnSizeY = _sizeY - 1;
        Vector2 centerPos = new Vector2(Random.Range(-spawnSizeX, spawnSizeX), Random.Range(-spawnSizeY, spawnSizeY));

        for (int x = -_sizeX; x <= _sizeX; x++)
        {
            for (int y = -_sizeY; y <= _sizeY; y++)
            {
                float floatDistance = Vector2.Distance(centerPos, new Vector2(x, y));
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
        for (int x = -_sizeX; x <= _sizeX; x++)
        {
            for (int y = -_sizeY; y <= _sizeY; y++)
            {
                Instantiate(_dirt[Random.Range(0,_dirt.Count)], new Vector3(x, y, 1), transform.rotation = Quaternion.Euler(0, 0, Random.RandomRange(0, 360)));
            }
        }
    }
}
