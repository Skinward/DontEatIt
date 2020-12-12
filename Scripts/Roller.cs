using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roller : MonoBehaviour
{
    public static Roller Instance;
    private Vector3 startPos;
    private Quaternion startRotation;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        startPos = gameObject.transform.position;
        startRotation = gameObject.transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            
            if (gameObject.GetComponent<AudioSource>().isPlaying)
            {
                return;
            }
            else
            {
                gameObject.GetComponent<Rigidbody>().AddForce(Vector3.forward * 5f);
                gameObject.GetComponent<AudioSource>().PlayOneShot(gameObject.GetComponent<AudioSource>().clip);
            }
        }
    }

    public void ResetPosition()
    {
        if (gameObject.GetComponent<AudioSource>().isPlaying)
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }
        gameObject.transform.rotation = startRotation;
        gameObject.transform.position = startPos;
        gameObject.GetComponent<Rigidbody>().isKinematic = true; ;

    }

}
