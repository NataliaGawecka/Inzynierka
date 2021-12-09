using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CheckRoundabout
{
    GO,
    STOP
}
public class roundaboutIntersection : MonoBehaviour
{
    public CheckRoundabout check_car = CheckRoundabout.GO;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {

            check_car = CheckRoundabout.STOP;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {

            check_car = CheckRoundabout.GO;
        }

    }
}
