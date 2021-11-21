using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairHit : MonoBehaviour
{
    public GameObject crossHairHitPrefab;

    void Update()
    {
        if (BulletCollided.isEnemyHit)
        {
            GameObject tmpCrossHairHit;
            tmpCrossHairHit = Instantiate(crossHairHitPrefab);
            tmpCrossHairHit.transform.SetParent(gameObject.transform, false);
            Destroy(tmpCrossHairHit, 0.5f);
            BulletCollided.isEnemyHit = false;
        }

    }
}
