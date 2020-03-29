using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionAudio : MonoBehaviour
{
    public AudioSource source;
    public AudioClip[] clips;

    void Start()
    {
        source = GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Cane"))
        {
            RandomSound();
        }
    }
    void RandomSound()
    {
        source.clip=clips[Random.Range(0, clips.Length)];
        source.PlayOneShot(source.clip);
    }
}
