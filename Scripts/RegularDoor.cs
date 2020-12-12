using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularDoor : MonoBehaviour
{
    private AudioSource audio;

    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (audio.isPlaying)
            {
                return;
            }
            else
            {
                audio.PlayOneShot(audio.clip);
            }
        }
    }

   



}
