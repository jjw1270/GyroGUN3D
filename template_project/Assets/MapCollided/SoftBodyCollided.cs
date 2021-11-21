using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoftBodyCollided : MonoBehaviour
{
    public GameObject softBodyImpact;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //gameObject.GetComponent<AudioSource>().Play();
            Instantiate(softBodyImpact, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            //Debug.Log("softBody");
        }
    }
}
