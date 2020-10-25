using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    float xSpawnMin = -2.2f;
    float xSpawnMax = 2.2f;

    float ySpawnMin = 3f;
    float ySpawnMax = 6f;

    public Pool coinPool;

    public void CoinSpawn(float y)
    {

        Vector3 pos = Vector3.zero;
        pos.x = Random.Range(xSpawnMin, xSpawnMax);
        pos.y = y;
        GameObject coin = coinPool.Instantiat(pos);
        pos.x = Random.Range(xSpawnMin, xSpawnMax);
        pos.y = y + Random.Range(ySpawnMin, ySpawnMax);
        GameObject coin1 = coinPool.Instantiat(pos);

    }

    public void FreeCoins()
    {
        coinPool.FreePool();
    }

}
