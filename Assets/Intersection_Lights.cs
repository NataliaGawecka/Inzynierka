using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Status_Light
{
    GO,
    STOP
}
public class Intersection_Lights : MonoBehaviour
{
    // Start is called before the first frame update
    public Status_Light LightStatus = Status_Light.STOP;
 
}
