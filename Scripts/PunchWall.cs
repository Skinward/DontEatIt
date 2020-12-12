using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchWall : MonoBehaviour
{
    public float speed;
    public float delayMin;
    public float delayMax;
    public float pushForce;

    public float stopPointX;
    public AudioClip[] sounds;

    private float currentTime;
    private Vector3 startPoint;
    private Vector3 stopPoint;
    private AudioSource audio;


    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        currentTime = Time.time;
        startPoint = transform.localPosition;
        stopPoint = new Vector3(stopPointX, transform.localPosition.y, transform.localPosition.z);
    }

    private void Update()
    {
        if(Time.time - currentTime >= Random.Range(delayMin, delayMax))
        {
            currentTime = Time.time;
            transform.localPosition = Vector3.MoveTowards(startPoint, stopPoint, speed * Time.deltaTime);
        }
        if(transform.localPosition == stopPoint && Time.time - currentTime >= 1f)
        {
            transform.localPosition = startPoint;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * pushForce);
            AudioClip sound = sounds[Random.Range(0, sounds.Length)];
            audio.PlayOneShot(sound);
        }
    }

}
