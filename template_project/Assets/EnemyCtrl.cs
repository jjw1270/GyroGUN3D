using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : MonoBehaviour
{
    public GameObject enemyEye;
    public GameObject fireEffectPrefab;
    public GameObject gun;

    Renderer eyeColor;
    private float time = 0.0f;
    private float enemyShootDelay;

    public static bool isHit = false;

    // Start is called before the first frame update
    void Start()
    {
        eyeColor = enemyEye.gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BulletCollided.nuclear)
        {
            GameObject[] tmpSpawn = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < tmpSpawn.Length; i++)
            {
                if (tmpSpawn[i].gameObject.name == "MachineGunRobot(Clone)")
                    GameOver.score += 100;
                else if (tmpSpawn[i].gameObject.name == "CannonMachine(Clone)")
                    GameOver.score += 250;
                Destroy(tmpSpawn[i]);
            }
            BulletCollided.nuclear = false;
        }
        else
        {
            time += Time.deltaTime;
            enemyShootDelay = Random.Range(LevelCtrl.enemyShootDelayMin, LevelCtrl.enemyShootDelayMax);

            if (time >= enemyShootDelay)
            {
                eyeColor.material.color = Color.red;
            }
            if (gameObject.name == "MachineGunRobot(Clone)")
            {
                enemyFire(1.0f);
            }
            else if (gameObject.name == "CannonMachine(Clone)")
            {
                enemyFire(2.0f);
            }
        }
    }

    void enemyFire(float destroyTime)
    {
        if (time >= enemyShootDelay + destroyTime)
        {
            GameObject tmpFire;
            tmpFire = Instantiate(fireEffectPrefab);
            tmpFire.transform.SetParent(gun.transform, false);
            tmpFire.gameObject.GetComponent<ParticleSystem>().Play();
            tmpFire.GetComponent<AudioSource>().Play();
            isHit = true;
            HitEffect._trauma = 1;
            if(destroyTime == 1.0f)
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHP>().addDamage(LevelCtrl.enemyMachineGunDamage);
            else if(destroyTime == 2.0f)
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHP>().addDamage(LevelCtrl.enemyCannonDamage);

            Destroy(tmpFire, destroyTime);
            time = 0;
        }
    }
}
