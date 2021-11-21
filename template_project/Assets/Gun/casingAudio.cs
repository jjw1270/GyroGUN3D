using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class casingAudio : MonoBehaviour
{
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Floor")
        {
            this.GetComponent<AudioSource>().Play();
            //Debug.Log("Casing");
        }
    }
}