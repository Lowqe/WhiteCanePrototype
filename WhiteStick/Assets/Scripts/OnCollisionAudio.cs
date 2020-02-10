﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionAudio : MonoBehaviour
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
        Debug.Log("Körs");
        if (other.gameObject.CompareTag("Cane"))
        {
            source.PlayOneShot(clip);
            Debug.Log("ljud spelas på kuben");

        }
    }
}
