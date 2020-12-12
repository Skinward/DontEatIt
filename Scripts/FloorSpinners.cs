using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpinners : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Vector3.right * speed * Time.deltaTime);
    }
}
