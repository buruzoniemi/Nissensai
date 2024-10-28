using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nisse_Audio : MonoBehaviour
{

    public AudioClip sound1;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)){

            audioSource.PlayOneShot(sound1);
        }
    }
}
