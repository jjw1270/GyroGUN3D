using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public GameObject[] spawnItemPointPrefab;

    private float time = 0.0f;
    private GameObject tmpItemSpawn;

    void Update()
    {
        time += Time.deltaTime;
        if(time > LevelCtrl.firstItemSpawnDelay)
        {
            float itemSpawnTime = Random.Range(LevelCtrl.itemSpawnTimeMin, LevelCtrl.itemSpawnTimeMax);
            if(time > itemSpawnTime)
            {
                if (!tmpItemSpawn)
                {
                    int spawnItemPoint = Random.Range(0, spawnItemPointPrefab.Length);
                    tmpItemSpawn = Instantiate(spawnItemPointPrefab[spawnItemPoint]);
                    time = LevelCtrl.firstItemSpawnDelay;
                }
            }
        }
    }
}
