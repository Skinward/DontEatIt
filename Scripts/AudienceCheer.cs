using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceCheer : MonoBehaviour
{
    public static AudienceCheer Instance;
    public AudioClip intro;
    public AudioClip finish;

    private void Awake()
    {
        //if(Instance == null)
        //{
           // DontDestroyOnLoad(gameObject);
            Instance = this;
        //}
        //else
        //{
         //   Destroy(gameObject);
       // }
    }

    private void Start()
    {
        //testing need to swap to intro cutscene
        IntroCheer();
    }

    public void IntroCheer()
    {
        gameObject.GetComponent<AudioSource>().volume = 0.1f;
        gameObject.GetComponent<AudioSource>().PlayOneShot(intro);
    }

    public void FinishCheer()
    {
        gameObject.GetComponent<AudioSource>().volume = 0.5f;
        gameObject.GetComponent<AudioSource>().PlayOneShot(finish);
    }

}
