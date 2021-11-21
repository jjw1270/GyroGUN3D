using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCtrl : MonoBehaviour
{
    public GameObject[] spawnPointPrefab;

    private GameObject tmpSpawn;
    private float time = 0.0f;
    private bool isOverlap = false;
    private float spawnTime;
    public static int[] dontOverlap;
    private int enemyNum = 0;
    private int randomEnemy = 0;
    //private float tickTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (!tmpSpawn)
        {
            spawnTime = Random.Range(LevelCtrl.enemySpawnMin, LevelCtrl.enemySpawnMax);

            if (time > spawnTime)
            {
                enemyNum = Random.Range(1, LevelCtrl.enemyNumLim + 1);
                dontOverlap = new int[enemyNum];
                Debug.Log(dontOverlap.Length);
                for (int i = 0; i < enemyNum; i++)    //적 한번에 나오는 수만큼 반복
                {
                    randomEnemy = Random.Range(0, spawnPointPrefab.Length);
                    //Debug.Log("FirstFOR");
                    dontOverlap[i] = randomEnemy;
                    for (int j = 0; j < dontOverlap.Length - 1; j++)  //중복체크
                    {
                        if (j == i)
                            continue;
                        if (dontOverlap[j] == dontOverlap[i])
                        {
                            isOverlap = true;
                            break;
                        }
                    }
                    if (!isOverlap)
                    {
                        tmpSpawn = Instantiate(spawnPointPrefab[randomEnemy]);
                    }
                    else   //버그버그버그버그벅브겁급거븍벅븍벅브겁그벅ㅂ그벅브겁급겁그버그벅ㅂ거
                    {
                        isOverlap = false;
                    }
                }
                time = 0;
            }
        }
    }
}