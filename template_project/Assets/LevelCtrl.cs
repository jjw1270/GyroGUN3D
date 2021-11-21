using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCtrl : MonoBehaviour
{
    //적 스폰 난이도
    public static int enemyNumLim;
    public static float enemySpawnMin;
    public static float enemySpawnMax;
    public static float enemyShootDelayMin;
    public static float enemyShootDelayMax;

    //적 데미지
    public static int enemyCannonDamage;
    public static int enemyMachineGunDamage;

    //아이템 난이도
    public static float firstItemSpawnDelay = 50.0f;
    public static float itemSpawnTimeMin;
    public static float itemSpawnTimeMax;

    //이동속도, 멈추는시간 난이도
    public static float enemyMoveForceMin;
    public static float enemyMoveForceMax;
    public static float enemyMoveStopMin;
    public static float enemyMoveStopMax;

    private float timer = 0.0f;

    void Start()
    {
        enemySpawnLevel(2, 4.0f, 6.0f, 5.0f, 7.0f);
        enemyDamageLevel(15, 8);
        itemLevel(15.0f, 30.0f);
        moveStopLevel(30f, 60f, 3.0f, 5.0f);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if(Mathf.RoundToInt(timer) == 30)
        {
            enemySpawnLevel(2, 3.0f, 5.0f, 5.0f, 7.0f);
        }
        if (Mathf.RoundToInt(timer) == 60)
        {
            enemySpawnLevel(3, 4.0f, 6.0f, 5.0f, 7.0f);
            moveStopLevel(40f, 80f, 2.5f, 4.5f);
        }
        if(Mathf.RoundToInt(timer) == 90)
        {
            enemySpawnLevel(4, 3.0f, 5.0f, 4.0f, 6.0f);
            moveStopLevel(50f, 100f, 2.0f, 4.0f);
        }
        if(Mathf.RoundToInt(timer) == 120)
        {
            moveStopLevel(70f, 120f, 1.5f, 3.0f);
            enemyDamageLevel(30, 15);
        }
        if(Mathf.RoundToInt(timer) == 150)
        {
            enemySpawnLevel(5, 4.0f, 6.0f, 4.0f, 6.0f);
            itemLevel(10.0f, 20.0f);
        }
        if(Mathf.RoundToInt(timer) == 180)
        {
            enemySpawnLevel(5, 3.0f, 5.0f, 4.0f, 5.0f);
            enemyDamageLevel(40, 20);
            moveStopLevel(100f, 150f, 0.5f, 2.0f);
        }
        if(Mathf.RoundToInt(timer) == 210)
        {
            enemySpawnLevel(6, 3.0f, 5.0f, 4.0f, 6.0f);
        }
        if(Mathf.RoundToInt(timer) == 240)
        {
            enemySpawnLevel(7, 2.0f, 4.0f, 3.0f, 5.0f);
        }
        if(Mathf.RoundToInt(timer) > 270)
        {
            timer = 60.0f;
        }
    }

    public void enemySpawnLevel(int enl, float esmin, float esmax, float esdmin, float esdmax)
    {
        enemyNumLim = enl;
        enemySpawnMin = esmin;
        enemySpawnMax = esmax;
        enemyShootDelayMin = esdmin;
        enemyShootDelayMax = esdmax;
    }
    public void enemyDamageLevel(int ecd, int emd)
    {
        enemyCannonDamage = ecd;
        enemyMachineGunDamage = emd;
    }
    public void itemLevel(float istmin, float istmax)
    {
        itemSpawnTimeMin = istmin;
        itemSpawnTimeMax = istmax;
    }
    public void moveStopLevel(float emfmin, float emfmax, float emsmin, float emsMax)
    {
        enemyMoveForceMin = emfmin;
        enemyMoveForceMax = emfmax;
        enemyMoveStopMin = emsmin;
        enemyMoveStopMax = emsMax;
    }
}
