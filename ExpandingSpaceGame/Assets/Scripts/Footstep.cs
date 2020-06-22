using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footstep : MonoBehaviour
{
    public AudioClip[] clips;
    public AudioSource audioSource;

    // Start is called before the first frame update
    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    public AudioClip GetRandomClip()
    {
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }
}