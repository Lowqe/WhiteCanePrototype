using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollision : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {
            source.PlayOneShot(clip);
        }
    }
}
