using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollided : MonoBehaviour
{
    public GameObject destroyEffect;
    public GameObject nuclearEffect;
    public GameObject healEffect;
    public static bool isEnemyHit;

    public static bool nuclear = false;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            if (gameObject.tag == "Item")
            {
                if (gameObject.name == "FirstAidKit_Biohazard(Clone)")
                {
                    Instantiate(nuclearEffect);
                    nuclear = true;
                }
                else if (gameObject.name == "FirstAidKit_White(Clone)")
                {
                    GameObject tmpHealEffect;
                    tmpHealEffect = Instantiate(healEffect, transform.position, Quaternion.identity);
                    Destroy(tmpHealEffect, 1.5f);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHP>().addDamage(-25);
                }
            }
            else
            {
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
                isEnemyHit = true;
                if (gameObject.name == "MachineGunRobot(Clone)")
                    GameOver.score += 100;
                else if (gameObject.name == "CannonMachine(Clone)")
                    GameOver.score += 250;
            }
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            Debug.Log("HIT");
        }
    }
}
