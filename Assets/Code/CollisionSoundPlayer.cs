using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionSoundPlayer : MonoBehaviour
{
    AudioSource audioSource;

    bool isUsed = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "SoundActivator" && !isUsed)
        {
            audioSource.Play();
            isUsed = true;
        }
    }
}
