using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCollision : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    int collisions = 0;

    public Text collisionCounter;
    

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        collisionCounter = GameObject.Find("CollisionCounter").GetComponent<Text>();

    }


    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("CollisionObject"))
        {
            if (!source.isPlaying)
            {
                source.PlayOneShot(clip);
                collisions++;
                
                
                collisionCounter.text = collisions.ToString() + " kollissioner";
            }
        }
    }
}
