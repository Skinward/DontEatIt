using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingLog : MonoBehaviour
{
    public GameObject pivotPoint;
    public float speed;
    

    void Update()
    {
        transform.RotateAround(pivotPoint.transform.position, Vector3.forward, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(speed > 0)
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * speed);
                Debug.Log("right force added");
            }
            else if(speed < 0)
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.left * -speed);
                Debug.Log("left force added");
            }
        }
    }
}
