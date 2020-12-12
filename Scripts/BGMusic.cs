using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    public AudioClip[] songs;

    private AudioSource audio;

    public static BGMusic Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        audio.loop = true;
        StartCoroutine(playBGMusic());
    }

    IEnumerator playBGMusic()
    {
        int song = Random.Range(0, songs.Length);

        for (int i = song; i < songs.Length; i++)
        {
            audio.clip = songs[i];

            if(i == songs.Length - 1)
            {
                i = 0;
            }

            audio.Play();
            yield return new WaitForSeconds(audio.clip.length);
        }
        
    }


}

