using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum T_status
{
    GO,
    STOP
}
public class T_Intersection_Status : MonoBehaviour
{
    public T_status t_status = T_status.GO;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            t_status = T_status.STOP;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            t_status = T_status.GO;
        }

    }
}
