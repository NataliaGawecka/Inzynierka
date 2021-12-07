using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public Intersection_Lights Light_nr1;
    public Intersection_Lights Light_nr2;
    public Intersection_Lights Light_nr3;
    public Intersection_Lights Light_nr4;

    public float time = 100.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (time < 25 && time > 0)
        {
            time -= Time.deltaTime;
            Light_nr1.LightStatus = Status_Light.GO;
            Light_nr2.LightStatus = Status_Light.STOP;
            Light_nr3.LightStatus = Status_Light.STOP;
            Light_nr4.LightStatus = Status_Light.STOP;
        }
        else if (time > 25 && time < 50)
        {
            time -= Time.deltaTime;
            Light_nr1.LightStatus = Status_Light.STOP;
            Light_nr2.LightStatus = Status_Light.GO;
            Light_nr3.LightStatus = Status_Light.STOP;
            Light_nr4.LightStatus = Status_Light.STOP;
        }
        else if (time > 50 && time < 75)
        {
            time -= Time.deltaTime;
            Light_nr1.LightStatus = Status_Light.STOP;
            Light_nr2.LightStatus = Status_Light.STOP;
            Light_nr3.LightStatus = Status_Light.GO;
            Light_nr4.LightStatus = Status_Light.STOP;
        }
        else if (time > 75 && time <= 100)
        {
            time -= Time.deltaTime;
            Light_nr1.LightStatus = Status_Light.STOP;
            Light_nr2.LightStatus = Status_Light.STOP;
            Light_nr3.LightStatus = Status_Light.STOP;
            Light_nr4.LightStatus = Status_Light.GO;
        }
        else if (time == 0 || time < 0)
        {
            Debug.Log("Time has run out!");
            time = 100.0f;

        }
    }
}
