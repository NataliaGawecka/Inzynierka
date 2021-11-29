using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roads_waypoint : MonoBehaviour
{
    public int id;
    public int x;
    public int y;
    public Waypoint waypoint_nr1;
    public Waypoint waypoint_nr2;

    public Waypoint waypoint_nr3;
    public Waypoint waypoint_nr4;

    public Waypoint waypoint_nr5;
    public Waypoint waypoint_nr6;

    public Waypoint waypoint_nr7;
    public Waypoint waypoint_nr8;
    //public MapGenerator Map;

    /*  void Start()
      {
          for (int i = 0; i < Map.roads.Count; i++)
          {
              if (Map.roads[i].GetComponent<Roads_waypoint>().waypoint_nr1 != null && Map.roads[i + 1].GetComponent<Roads_waypoint>().waypoint_nr1 != null)
                  Map.roads[i].GetComponent<Roads_waypoint>().waypoint_nr1.nextWaypoint = Map.roads[i + 1].GetComponent<Roads_waypoint>().waypoint_nr1;
          }
      }
    */

}