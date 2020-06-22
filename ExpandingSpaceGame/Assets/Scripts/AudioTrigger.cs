using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTrigger : MonoBehaviour
{
    public AudioClip Dialogue;
    AudioSource audio;
    public float volumeScale;


    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            audio.PlayOneShot(Dialogue, volumeScale);
        }
    }
}
