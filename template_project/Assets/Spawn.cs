using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    private Transform target;
    private GameObject tmpEnemy;

    private float force;
    private bool isDelay = false;
    private float delayTime;
    private bool isSpawn;

    private float enemyDestroyTime = LevelCtrl.enemyShootDelayMax + 3.0f;

    private void Start()
    {
        isSpawn = false;
        target = GameObject.Find("Main Camera").transform;
    }

    // Update is called once per frame
    void Update()
    {
        int randomEnemy = Random.Range(0, enemyPrefab.Length);
        force = Random.Range(LevelCtrl.enemyMoveForceMin, LevelCtrl.enemyMoveForceMax);
        delayTime = Random.Range(LevelCtrl.enemyMoveStopMin, LevelCtrl.enemyMoveStopMax);  

        if (!isDelay)
        {
            if (!isSpawn) {
                isSpawn = true;
                isDelay = true;

                tmpEnemy = Instantiate(enemyPrefab[randomEnemy]);
                tmpEnemy.transform.SetParent(gameObject.transform, false);

                switch (gameObject.tag)
                {
                    case "SpLeft":
                        if(tmpEnemy.gameObject.tag != "Item")
                            tmpEnemy.transform.Rotate(new Vector3(0, 180, 0));
                        tmpEnemy.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * force);
                        break;
                    case "SpRight":
                        tmpEnemy.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0) * force);
                        break;
                    case "SpCenter":
                        int side = Random.Range(0, 3);
                        switch (side)
                        {
                            case 0:
                                tmpEnemy.transform.Rotate(new Vector3(0, 180, 0));
                                tmpEnemy.GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0) * force);
                                break;
                            case 1:
                                tmpEnemy.GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0) * force);
                                break;
                            case 2:
                                tmpEnemy.transform.LookAt(target);
                                tmpEnemy.GetComponent<Rigidbody>().AddForce(new Vector3(0, 1, 0) * (force / 2));
                                break;
                        }
                        break;
                }
            }
            StartCoroutine(stopDelay());
        }
        if (tmpEnemy)
        {
            if (tmpEnemy.gameObject.tag == "Item")
                Destroy(gameObject, enemyDestroyTime + 2.0f);
            else
                Destroy(gameObject, enemyDestroyTime);
        }
    }
    IEnumerator stopDelay()
    {
        yield return new WaitForSecondsRealtime(delayTime);
        if (tmpEnemy)
        {
            if(tmpEnemy.gameObject.tag != "Item")
            {
                tmpEnemy.GetComponent<Rigidbody>().velocity = Vector3.zero;
                tmpEnemy.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                tmpEnemy.transform.LookAt(target);
            }
        }
        isDelay = false;
    }
}