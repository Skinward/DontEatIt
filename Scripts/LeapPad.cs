using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeapPad : MonoBehaviour
{
    public AudioClip clip;
    private AudioSource audio;

    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        audio.clip = clip;
    }

    private void OnCollisionEnter(Collision collision)
    {

        audio.PlayOneShot(clip);
    }
}
