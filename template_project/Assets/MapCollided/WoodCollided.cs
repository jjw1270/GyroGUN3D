using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCollided : MonoBehaviour
{
    public GameObject woodImpact;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //gameObject.GetComponent<AudioSource>().Play();
            Instantiate(woodImpact, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            //Debug.Log("Wood");
        }
    }
}
