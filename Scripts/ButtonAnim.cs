using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnim : MonoBehaviour
{
    public AudioClip hoverSound;
    public AudioClip clickSound;

    private bool hasPlayed;
    private Vector3 startPos;
    private bool hover;

    private AudioSource audio;

    private void Start()
    {
        hasPlayed = false;
        hover = false;
        startPos = gameObject.transform.localPosition;
        audio = gameObject.GetComponent<AudioSource>();
    }


    public void PopOut()
    {
        gameObject.transform.localPosition = new Vector3(750f, startPos.y, startPos.z);
        audio.PlayOneShot(hoverSound);
    }

    public void SlideBack()
    {
        gameObject.transform.localPosition = new Vector3(startPos.x, startPos.y, startPos.z);
    }

    public void PlaySelectSound()
    {
        audio.PlayOneShot(clickSound);
    }



}
