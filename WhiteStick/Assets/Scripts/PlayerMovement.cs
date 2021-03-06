﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    public AudioSource source;
    public AudioClip clip;


    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        
     if(controller.velocity.x != 0 && !source.isPlaying)
        {
            source.PlayOneShot(clip);
            Debug.Log("fotsteg");
        }

        if (controller.velocity.z != 0 && !source.isPlaying)
        {
            source.PlayOneShot(clip);
            Debug.Log("fotsteg");
        }
    }


}
