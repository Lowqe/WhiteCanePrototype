using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialButtonPress : MonoBehaviour

    
{
     AudioSource source;
    
    
    // Start is called before the first frame update
    void Start()
    {
    source = GetComponent<AudioSource>();
}

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1) && !source.isPlaying)
        {
            source.Play();
        }
    }
}
