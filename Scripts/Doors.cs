using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject door1;
    public GameObject door2;
    public GameObject door3;

    public GameObject regularDoor;
    public GameObject falseDoor1;
    public GameObject falseDoor2;

    private int regDoorLocation;

    private void Start()
    {
        regDoorLocation = Random.Range(1, 4);
        Debug.Log("doorLocation Is: " + regDoorLocation);
        SetDoor();
    }

    private void SetDoor()
    {
        if(regDoorLocation == 1)
        {
            regularDoor.transform.localPosition = door1.transform.localPosition;
            falseDoor1.transform.localPosition = door2.transform.localPosition;
            falseDoor2.transform.localPosition = door3.transform.localPosition;
        }
        else if( regDoorLocation == 2)
        {
            regularDoor.transform.localPosition = door2.transform.localPosition;
            falseDoor1.transform.localPosition = door1.transform.localPosition;
            falseDoor2.transform.localPosition = door3.transform.localPosition;
        }
        else
        {
            regularDoor.transform.localPosition = door3.transform.localPosition;
            falseDoor1.transform.localPosition = door1.transform.localPosition;
            falseDoor2.transform.localPosition = door2.transform.localPosition;
        }
    }

    
}
