using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip walking;

    // Start is called before the first frame update
    private void Start()
    {
        audioSource.Play(0);
    }

    public void playWalking()
    {
        audioSource.PlayOneShot(walking);
    }
}