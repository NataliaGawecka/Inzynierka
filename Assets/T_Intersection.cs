using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Car_status
{
    GO,
    STOP
}

public class T_Intersection : MonoBehaviour
{
   
    public T_Intersection_Status t_intersection_status;
    public T_Intersection_Status t_intersection_status_two;

    public Car_status car_status = Car_status.GO;

    public Waypoint freeToRideWaypoint;
    public Waypoint WaypointWhereYouCheckJustOneSide;
    public Waypoint WaypointWhereYouCheckJustTwoSide;
    // Start is called before the first frame update
  
    // Update is called once per frame
 /*   void Update()
    {
        if (t_intersection_status != null && t_intersection_status_two == null)
        {

            if (t_intersection_status.t_status == T_status.STOP)
            {
                car_status = Car_status.STOP;
            }
            else
            {

                car_status = Car_status.GO;
            }
        }
    }
 */
}
