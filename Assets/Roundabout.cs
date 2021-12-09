using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Roundabout_car_status
{
    GO,
    STOP

}
public class Roundabout : MonoBehaviour
{

    public roundaboutIntersection roundabout;
    public Roundabout_car_status car_state = Roundabout_car_status.GO;

    void Update()
    {
        if (roundabout.check_car == CheckRoundabout.GO)
        {
            car_state = Roundabout_car_status.GO;
        }
        else if (roundabout.check_car == CheckRoundabout.STOP)
        {
            car_state = Roundabout_car_status.STOP;
        }
    }
}
