using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Breather : MonoBehaviour
{
    public List<AudioClip> mp3s = new List<AudioClip>();
    public AudioSource audioSource;

    private void FixedUpdate()
    {
        if (!audioSource.isPlaying)
        {
            PlayRandomMp3();
        }
    }

    private void PlayRandomMp3()
    {
        audioSource.PlayOneShot(SelectRandomMp3());
        audioSource.volume = Random.Range(0, 2);
    }

    AudioClip SelectRandomMp3() 
    {
        var id = Random.Range(0, mp3s.Count);
        return mp3s[id];
    }
}
