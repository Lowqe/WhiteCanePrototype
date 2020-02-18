using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollision : MonoBehaviour
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
        
        if (other.gameObject.CompareTag("CollisionObject"))
        {
            source.PlayOneShot(clip);


        }
    }
}
