using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcreteCollided : MonoBehaviour
{
    public GameObject concreteImpact;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            //gameObject.GetComponent<AudioSource>().Play();
            Instantiate(concreteImpact, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            //Debug.Log("Concrete");
        }
    }
}
