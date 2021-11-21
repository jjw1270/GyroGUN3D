using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalCollided : MonoBehaviour
{
    public GameObject metalImpact;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //gameObject.GetComponent<AudioSource>().Play();
            Instantiate(metalImpact, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            //Debug.Log("Metal");
        }
    }
}
