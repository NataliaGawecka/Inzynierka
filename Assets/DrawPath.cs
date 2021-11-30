using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPath : MonoBehaviour
{

   public Path path;
   
    private void DrawWaypointInCircle(List<List<Roads_waypoint>> AllRoads, int x , int i)
    {
        if (path.AllRoads[x][i].waypoint_nr1 != null && path.AllRoads[x][i].waypoint_nr1.nextWaypoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr1.transform.position, path.AllRoads[x][i].waypoint_nr1.nextWaypoint.transform.position);
        }
        if (path.AllRoads[x][i].waypoint_nr2 != null && path.AllRoads[x][i].waypoint_nr2.nextWaypoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr2.transform.position, path.AllRoads[x][i].waypoint_nr2.nextWaypoint.transform.position);
        }
        if (path.AllRoads[x][i].waypoint_nr3 != null && path.AllRoads[x][i].waypoint_nr3.nextWaypoint != null && path.AllRoads[x][i].waypoint_nr3.link != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr3.transform.position, path.AllRoads[x][i].waypoint_nr3.nextWaypoint.transform.position);
            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr3.transform.position, path.AllRoads[x][i].waypoint_nr3.link.transform.position);
        }
        if (path.AllRoads[x][i].waypoint_nr4 != null && path.AllRoads[x][i].waypoint_nr4.nextWaypoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr4.transform.position, path.AllRoads[x][i].waypoint_nr4.nextWaypoint.transform.position);
        }
        if (path.AllRoads[x][i].waypoint_nr5 != null && path.AllRoads[x][i].waypoint_nr5.nextWaypoint != null && path.AllRoads[x][i].waypoint_nr5.link != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr5.transform.position, path.AllRoads[x][i].waypoint_nr5.nextWaypoint.transform.position);
            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr5.transform.position, path.AllRoads[x][i].waypoint_nr5.link.transform.position);
        }
        if (path.AllRoads[x][i].waypoint_nr6 != null && path.AllRoads[x][i].waypoint_nr6.nextWaypoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr6.transform.position, path.AllRoads[x][i].waypoint_nr6.nextWaypoint.transform.position);
        }
        if (path.AllRoads[x][i].waypoint_nr7 != null && path.AllRoads[x][i].waypoint_nr7.nextWaypoint != null && path.AllRoads[x][i].waypoint_nr7.link != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr7.transform.position, path.AllRoads[x][i].waypoint_nr7.nextWaypoint.transform.position);
            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr7.transform.position, path.AllRoads[x][i].waypoint_nr7.link.transform.position);
        }
        if (path.AllRoads[x][i].waypoint_nr8 != null && path.AllRoads[x][i].waypoint_nr8.nextWaypoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr8.transform.position, path.AllRoads[x][i].waypoint_nr8.nextWaypoint.transform.position);
        }
        if (path.AllRoads[x][i].waypoint_nr9 != null && path.AllRoads[x][i].waypoint_nr9.nextWaypoint != null && path.AllRoads[x][i].waypoint_nr9.link != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr9.transform.position, path.AllRoads[x][i].waypoint_nr9.nextWaypoint.transform.position);
            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr9.transform.position, path.AllRoads[x][i].waypoint_nr9.link.transform.position);
        }
        if (path.AllRoads[x][i].waypoint_nr11 != null && path.AllRoads[x][i].waypoint_nr11.nextWaypoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr11.transform.position, path.AllRoads[x][i].waypoint_nr11.nextWaypoint.transform.position);
        }
        if (path.AllRoads[x][i].waypoint_nr14 != null && path.AllRoads[x][i].waypoint_nr14.nextWaypoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr14.transform.position, path.AllRoads[x][i].waypoint_nr14.nextWaypoint.transform.position);
        }
        if (path.AllRoads[x][i].waypoint_nr16 != null && path.AllRoads[x][i].waypoint_nr16.nextWaypoint != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr16.transform.position, path.AllRoads[x][i].waypoint_nr16.nextWaypoint.transform.position);
        }
    }
    private void OnDrawGizmos()
    {
         if (!Application.isPlaying) return;


        for (int x = 0; x < path.AllRoads.Count; x++)
            {
                for (int i = 0; i < path.AllRoads[x].Count; i++)
                {
                    Gizmos.color = Color.red;
                    if (path.AllRoads[x][i].tag == "Road_1_line" && path.AllRoads[x][i + 1].tag == "Road_1_line")
                    {
                        if (path.AllRoads[x][i].y < path.AllRoads[x][i + 1].y)
                        {
                            if (path.AllRoads[x][i].waypoint_nr1 != null && path.AllRoads[x][i].waypoint_nr1.nextWaypoint != null)
                            {
                                Gizmos.color = Color.red;
                                Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr1.transform.position, path.AllRoads[x][i].waypoint_nr1.nextWaypoint.transform.position);


                            }
                            if (path.AllRoads[x][i + 1].waypoint_nr2 != null && path.AllRoads[x][i + 1].waypoint_nr2.nextWaypoint != null)
                            {
                                Gizmos.color = Color.blue;
                                Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr2.transform.position, path.AllRoads[x][i + 1].waypoint_nr2.nextWaypoint.transform.position);

                            }
                        }
                        if (path.AllRoads[x][i].y > path.AllRoads[x][i + 1].y)
                        {
                            if (path.AllRoads[x][i + 1].waypoint_nr1 != null && path.AllRoads[x][i + 1].waypoint_nr1.nextWaypoint != null)
                            {
                                Gizmos.color = Color.blue;
                                Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr1.transform.position, path.AllRoads[x][i + 1].waypoint_nr1.nextWaypoint.transform.position);
                            }
                            if (path.AllRoads[x][i].waypoint_nr2 != null && path.AllRoads[x][i].waypoint_nr2.nextWaypoint != null)
                            {
                                Gizmos.color = Color.red;
                                Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr2.transform.position, path.AllRoads[x][i].waypoint_nr2.nextWaypoint.transform.position);


                            }

                        }
                    }
                    if (path.AllRoads[x][i].tag == "Road_1_line" && path.AllRoads[x][i + 1].tag == "Road_1_line_turn_90")
                    {
                        if (path.AllRoads[x][i].waypoint_nr1 != null && path.AllRoads[x][i].waypoint_nr1.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr1.transform.position, path.AllRoads[x][i].waypoint_nr1.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr8 != null && path.AllRoads[x][i + 1].waypoint_nr8.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr8.transform.position, path.AllRoads[x][i + 1].waypoint_nr8.nextWaypoint.transform.position);
                        }

                    }
                    if (path.AllRoads[x][i].tag == "Road_1_line_turn_90" && path.AllRoads[x][i + 1].tag == "Road_1_line_90")
                    {
                        Gizmos.color = Color.red;
                        if (path.AllRoads[x][i].waypoint_nr1.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr1.transform.position, path.AllRoads[x][i].waypoint_nr1.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr2.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr2.transform.position, path.AllRoads[x][i].waypoint_nr2.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr3.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr3.transform.position, path.AllRoads[x][i].waypoint_nr3.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr4.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr4.transform.position, path.AllRoads[x][i].waypoint_nr4.nextWaypoint.transform.position);
                        Gizmos.color = Color.blue;
                        if (path.AllRoads[x][i].waypoint_nr5.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr5.transform.position, path.AllRoads[x][i].waypoint_nr5.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr6.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr6.transform.position, path.AllRoads[x][i].waypoint_nr6.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr7.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr7.transform.position, path.AllRoads[x][i].waypoint_nr7.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i + 1].waypoint_nr2.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr2.transform.position, path.AllRoads[x][i + 1].waypoint_nr2.nextWaypoint.transform.position);

                    }
                    if (path.AllRoads[x][i].tag == "Road_1_line_90" && path.AllRoads[x][i + 1].tag == "Road_1_line_90")
                    {
                        if (path.AllRoads[x][i].x > path.AllRoads[x][i + 1].x)
                        {
                            if (path.AllRoads[x][i].waypoint_nr1 != null && path.AllRoads[x][i].waypoint_nr1.nextWaypoint != null)
                            {
                                Gizmos.color = Color.red;
                                Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr1.transform.position, path.AllRoads[x][i].waypoint_nr1.nextWaypoint.transform.position);


                            }
                            if (path.AllRoads[x][i + 1].waypoint_nr2 != null && path.AllRoads[x][i + 1].waypoint_nr2.nextWaypoint != null)
                            {
                                Gizmos.color = Color.blue;
                                Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr2.transform.position, path.AllRoads[x][i + 1].waypoint_nr2.nextWaypoint.transform.position);

                            }
                        }
                        if (path.AllRoads[x][i].x < path.AllRoads[x][i + 1].x)
                        {
                            if (path.AllRoads[x][i].waypoint_nr2 != null && path.AllRoads[x][i].waypoint_nr2.nextWaypoint != null)
                            {
                                Gizmos.color = Color.red;
                                Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr2.transform.position, path.AllRoads[x][i].waypoint_nr2.nextWaypoint.transform.position);
                            }
                            if (path.AllRoads[x][i + 1].waypoint_nr1 != null && path.AllRoads[x][i + 1].waypoint_nr1.nextWaypoint != null)
                            {
                                Gizmos.color = Color.blue;
                                Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr1.transform.position, path.AllRoads[x][i + 1].waypoint_nr1.nextWaypoint.transform.position);
                            }

                        }
                    }
                    if (path.AllRoads[x][i].tag == "Road_1_line_90" && path.AllRoads[x][i + 1].tag == "Road_1_line_turn_90")
                    {

                        if (path.AllRoads[x][i].waypoint_nr2 != null && path.AllRoads[x][i].waypoint_nr2.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr2.transform.position, path.AllRoads[x][i].waypoint_nr2.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr4 != null && path.AllRoads[x][i + 1].waypoint_nr4.nextWaypoint != null)
                        {

                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr4.transform.position, path.AllRoads[x][i + 1].waypoint_nr4.nextWaypoint.transform.position);
                        }
                    }
                    if (path.AllRoads[x][i].tag == "Road_1_line_turn_90" && path.AllRoads[x][i + 1].tag == "Road_1_line")
                    {
                        if (path.AllRoads[x][i].waypoint_nr8 != null && path.AllRoads[x][i].waypoint_nr8.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr8.transform.position, path.AllRoads[x][i].waypoint_nr8.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr1 != null && path.AllRoads[x][i + 1].waypoint_nr1.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr1.transform.position, path.AllRoads[x][i + 1].waypoint_nr1.nextWaypoint.transform.position);
                        }
                        Gizmos.color = Color.red;
                        if (path.AllRoads[x][i].waypoint_nr5.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr5.transform.position, path.AllRoads[x][i].waypoint_nr5.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr6.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr6.transform.position, path.AllRoads[x][i].waypoint_nr6.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr7.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr7.transform.position, path.AllRoads[x][i].waypoint_nr7.nextWaypoint.transform.position);
                        Gizmos.color = Color.blue;
                        if (path.AllRoads[x][i].waypoint_nr1.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr1.transform.position, path.AllRoads[x][i].waypoint_nr1.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr2.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr2.transform.position, path.AllRoads[x][i].waypoint_nr2.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr3.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr3.transform.position, path.AllRoads[x][i].waypoint_nr3.nextWaypoint.transform.position);

                    }
                    if (path.AllRoads[x][i].tag == "Road_1_line" && path.AllRoads[x][i + 1].tag == "Road_1_line_turn_180")
                    {
                        if (path.AllRoads[x][i + 1].waypoint_nr8 != null && path.AllRoads[x][i + 1].waypoint_nr8.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr8.transform.position, path.AllRoads[x][i + 1].waypoint_nr8.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i].waypoint_nr2 != null && path.AllRoads[x][i].waypoint_nr2.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr2.transform.position, path.AllRoads[x][i].waypoint_nr2.nextWaypoint.transform.position);
                        }
                    }
                    if (path.AllRoads[x][i].tag == "Road_1_line_turn_180" && path.AllRoads[x][i + 1].tag == "Road_1_line_90")
                    {
                        if (path.AllRoads[x][i].waypoint_nr4 != null && path.AllRoads[x][i].waypoint_nr4.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr4.transform.position, path.AllRoads[x][i].waypoint_nr4.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr2 != null && path.AllRoads[x][i + 1].waypoint_nr2.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr2.transform.position, path.AllRoads[x][i + 1].waypoint_nr2.nextWaypoint.transform.position);
                        }
                        Gizmos.color = Color.red;
                        if (path.AllRoads[x][i].waypoint_nr1.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr1.transform.position, path.AllRoads[x][i].waypoint_nr1.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr2.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr2.transform.position, path.AllRoads[x][i].waypoint_nr2.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr3.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr3.transform.position, path.AllRoads[x][i].waypoint_nr3.nextWaypoint.transform.position);
                        Gizmos.color = Color.blue;
                        if (path.AllRoads[x][i].waypoint_nr5.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr5.transform.position, path.AllRoads[x][i].waypoint_nr5.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr6.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr6.transform.position, path.AllRoads[x][i].waypoint_nr6.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr7.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr7.transform.position, path.AllRoads[x][i].waypoint_nr7.nextWaypoint.transform.position);
                    }
                    if (path.AllRoads[x][i].tag == "Road_1_line_90" && path.AllRoads[x][i + 1].tag == "Road_1_line_turn")
                    {
                        if (path.AllRoads[x][i].waypoint_nr1 != null && path.AllRoads[x][i].waypoint_nr1.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr1.transform.position, path.AllRoads[x][i].waypoint_nr1.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr8 != null && path.AllRoads[x][i + 1].waypoint_nr8.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr8.transform.position, path.AllRoads[x][i + 1].waypoint_nr8.nextWaypoint.transform.position);
                        }

                    }
                    if (path.AllRoads[x][i].tag == "Road_1_line_turn" && path.AllRoads[x][i + 1].tag == "Road_1_line")
                    {
                        if (path.AllRoads[x][i].waypoint_nr4 != null && path.AllRoads[x][i].waypoint_nr4.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr4.transform.position, path.AllRoads[x][i].waypoint_nr4.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr1 != null && path.AllRoads[x][i + 1].waypoint_nr1.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr1.transform.position, path.AllRoads[x][i + 1].waypoint_nr1.nextWaypoint.transform.position);
                        }
                        Gizmos.color = Color.red;
                        if (path.AllRoads[x][i].waypoint_nr1.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr1.transform.position, path.AllRoads[x][i].waypoint_nr1.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr2.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr2.transform.position, path.AllRoads[x][i].waypoint_nr2.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr3.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr3.transform.position, path.AllRoads[x][i].waypoint_nr3.nextWaypoint.transform.position);
                        Gizmos.color = Color.blue;
                        if (path.AllRoads[x][i].waypoint_nr5.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr5.transform.position, path.AllRoads[x][i].waypoint_nr5.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr6.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr6.transform.position, path.AllRoads[x][i].waypoint_nr6.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr7.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr7.transform.position, path.AllRoads[x][i].waypoint_nr7.nextWaypoint.transform.position);
                    }
                    if (path.AllRoads[x][i].tag == "Road_1_line" && path.AllRoads[x][i + 1].tag == "Road_1_line_turn")
                    {
                        if (path.AllRoads[x][i].waypoint_nr1 != null && path.AllRoads[x][i].waypoint_nr1.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr1.transform.position, path.AllRoads[x][i].waypoint_nr1.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr4 != null && path.AllRoads[x][i + 1].waypoint_nr4.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr4.transform.position, path.AllRoads[x][i + 1].waypoint_nr4.nextWaypoint.transform.position);
                        }

                    }
                    if (path.AllRoads[x][i].tag == "Road_1_line_turn" && path.AllRoads[x][i + 1].tag == "Road_1_line_90")
                    {
                        if (path.AllRoads[x][i].waypoint_nr8 != null && path.AllRoads[x][i].waypoint_nr8.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr8.transform.position, path.AllRoads[x][i].waypoint_nr8.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr1 != null && path.AllRoads[x][i + 1].waypoint_nr1.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr1.transform.position, path.AllRoads[x][i + 1].waypoint_nr1.nextWaypoint.transform.position);

                        }
                        Gizmos.color = Color.red;
                        if (path.AllRoads[x][i].waypoint_nr5.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr5.transform.position, path.AllRoads[x][i].waypoint_nr5.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr6.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr6.transform.position, path.AllRoads[x][i].waypoint_nr6.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr7.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr7.transform.position, path.AllRoads[x][i].waypoint_nr7.nextWaypoint.transform.position);
                        Gizmos.color = Color.blue;
                        if (path.AllRoads[x][i].waypoint_nr1.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr1.transform.position, path.AllRoads[x][i].waypoint_nr1.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr2.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr2.transform.position, path.AllRoads[x][i].waypoint_nr2.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr3.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr3.transform.position, path.AllRoads[x][i].waypoint_nr3.nextWaypoint.transform.position);
                    }
                    if (path.AllRoads[x][i].tag == "Road_1_line" && path.AllRoads[x][i + 1].tag == "Road_1_line_turn_270")
                    {
                        if (path.AllRoads[x][i].waypoint_nr2 != null && path.AllRoads[x][i].waypoint_nr2.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr2.transform.position, path.AllRoads[x][i].waypoint_nr2.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr4 != null && path.AllRoads[x][i + 1].waypoint_nr4.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr4.transform.position, path.AllRoads[x][i + 1].waypoint_nr4.nextWaypoint.transform.position);

                        }
                    }
                    if (path.AllRoads[x][i].tag == "Road_1_line_turn_270" && path.AllRoads[x][i + 1].tag == "Road_1_line_90")
                    {
                        if (path.AllRoads[x][i].waypoint_nr8 != null && path.AllRoads[x][i].waypoint_nr8.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr8.transform.position, path.AllRoads[x][i].waypoint_nr8.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr1 != null && path.AllRoads[x][i + 1].waypoint_nr1.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr1.transform.position, path.AllRoads[x][i + 1].waypoint_nr1.nextWaypoint.transform.position);
                        }
                        Gizmos.color = Color.red;
                        if (path.AllRoads[x][i].waypoint_nr5.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr5.transform.position, path.AllRoads[x][i].waypoint_nr5.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr6.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr6.transform.position, path.AllRoads[x][i].waypoint_nr6.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr7.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr7.transform.position, path.AllRoads[x][i].waypoint_nr7.nextWaypoint.transform.position);

                        Gizmos.color = Color.blue;
                        if (path.AllRoads[x][i].waypoint_nr1.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr1.transform.position, path.AllRoads[x][i].waypoint_nr1.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr2.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr2.transform.position, path.AllRoads[x][i].waypoint_nr2.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr3.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr3.transform.position, path.AllRoads[x][i].waypoint_nr3.nextWaypoint.transform.position);
                    }
                    if (path.AllRoads[x][i].tag == "Road_1_line_90" && path.AllRoads[x][i + 1].tag == "Road_1_line_turn_270")
                    {
                        if (path.AllRoads[x][i].waypoint_nr1 != null && path.AllRoads[x][i].waypoint_nr1.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr1.transform.position, path.AllRoads[x][i].waypoint_nr1.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr8 != null && path.AllRoads[x][i + 1].waypoint_nr8.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr8.transform.position, path.AllRoads[x][i + 1].waypoint_nr8.nextWaypoint.transform.position);
                        }
                    }
                    if (path.AllRoads[x][i].tag == "Road_1_line_turn_270" && path.AllRoads[x][i + 1].tag == "Road_1_line")
                    {
                        if (path.AllRoads[x][i].waypoint_nr4 != null && path.AllRoads[x][i].waypoint_nr4.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr4.transform.position, path.AllRoads[x][i].waypoint_nr4.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr2 != null && path.AllRoads[x][i + 1].waypoint_nr2.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr2.transform.position, path.AllRoads[x][i + 1].waypoint_nr2.nextWaypoint.transform.position);
                        }
                        Gizmos.color = Color.blue;
                        if (path.AllRoads[x][i].waypoint_nr5.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr5.transform.position, path.AllRoads[x][i].waypoint_nr5.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr6.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr6.transform.position, path.AllRoads[x][i].waypoint_nr6.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr7.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr7.transform.position, path.AllRoads[x][i].waypoint_nr7.nextWaypoint.transform.position);

                        Gizmos.color = Color.red;
                        if (path.AllRoads[x][i].waypoint_nr1.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr1.transform.position, path.AllRoads[x][i].waypoint_nr1.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr2.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr2.transform.position, path.AllRoads[x][i].waypoint_nr2.nextWaypoint.transform.position);
                        if (path.AllRoads[x][i].waypoint_nr3.nextWaypoint != null)
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr3.transform.position, path.AllRoads[x][i].waypoint_nr3.nextWaypoint.transform.position);
                    }
                //ronda i proste drogi
                if (path.AllRoads[x][i].tag == "Road_1_line" && path.AllRoads[x][i + 1].tag == "circle")
                {
                    //lewo prawo
                    if (path.AllRoads[x][i].y < path.AllRoads[x][i + 1].y)
                    {
                        if (path.AllRoads[x][i].waypoint_nr1 != null && path.AllRoads[x][i].waypoint_nr1.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr1.transform.position, path.AllRoads[x][i].waypoint_nr1.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr15 != null && path.AllRoads[x][i + 1].waypoint_nr15.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr15.transform.position, path.AllRoads[x][i + 1].waypoint_nr15.nextWaypoint.transform.position);
                        }
                    }
                    //prawo lewo
                    if (path.AllRoads[x][i].y > path.AllRoads[x][i + 1].y)
                    {
                        if (path.AllRoads[x][i].waypoint_nr2 != null && path.AllRoads[x][i].waypoint_nr2.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr2.transform.position, path.AllRoads[x][i].waypoint_nr2.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr12 != null && path.AllRoads[x][i + 1].waypoint_nr12.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr12.transform.position, path.AllRoads[x][i + 1].waypoint_nr12.nextWaypoint.transform.position);
                        }
                    }
                }
                if (path.AllRoads[x][i].tag == "Road_1_line_90" && path.AllRoads[x][i + 1].tag == "circle")
                {
                    //góra dół
                    if (path.AllRoads[x][i].x < path.AllRoads[x][i + 1].x)
                    {
                        if (path.AllRoads[x][i].waypoint_nr2 != null && path.AllRoads[x][i].waypoint_nr2.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr2.transform.position, path.AllRoads[x][i].waypoint_nr2.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr13 != null && path.AllRoads[x][i + 1].waypoint_nr13.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr13.transform.position, path.AllRoads[x][i + 1].waypoint_nr13.nextWaypoint.transform.position);
                        }
                    }
                    //dów góra
                    if (path.AllRoads[x][i].x > path.AllRoads[x][i + 1].x)
                    {
                        if (path.AllRoads[x][i].waypoint_nr1 != null && path.AllRoads[x][i].waypoint_nr1.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr1.transform.position, path.AllRoads[x][i].waypoint_nr1.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr10 != null && path.AllRoads[x][i + 1].waypoint_nr10.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr10.transform.position, path.AllRoads[x][i + 1].waypoint_nr10.nextWaypoint.transform.position);
                        }
                    }
                }
                if (path.AllRoads[x][i].tag == "circle" && path.AllRoads[x][i + 1].tag == "Road_1_line")
                {
                    //lewo prawo
                    if (path.AllRoads[x][i].y < path.AllRoads[x][i + 1].y)
                    {
                        if (path.AllRoads[x][i].waypoint_nr12 != null && path.AllRoads[x][i].waypoint_nr12.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr12.transform.position, path.AllRoads[x][i].waypoint_nr12.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr2!= null && path.AllRoads[x][i + 1].waypoint_nr2.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr2.transform.position, path.AllRoads[x][i + 1].waypoint_nr2.nextWaypoint.transform.position);
                        }
                    }
                    //prawo lewo
                    if (path.AllRoads[x][i].y > path.AllRoads[x][i + 1].y)
                    {
                        if (path.AllRoads[x][i].waypoint_nr15 != null && path.AllRoads[x][i].waypoint_nr15.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr15.transform.position, path.AllRoads[x][i].waypoint_nr15.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr1 != null && path.AllRoads[x][i + 1].waypoint_nr1.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr1.transform.position, path.AllRoads[x][i + 1].waypoint_nr1.nextWaypoint.transform.position);
                        }
                    }
                }
                if (path.AllRoads[x][i].tag == "circle" && path.AllRoads[x][i + 1].tag == "Road_1_line_90")
                {
                    //góra dół
                    if (path.AllRoads[x][i].x < path.AllRoads[x][i + 1].x)
                    {
                        if (path.AllRoads[x][i].waypoint_nr10 != null && path.AllRoads[x][i].waypoint_nr10.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr10.transform.position, path.AllRoads[x][i].waypoint_nr10.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr1!= null && path.AllRoads[x][i + 1].waypoint_nr1.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr1.transform.position, path.AllRoads[x][i + 1].waypoint_nr1.nextWaypoint.transform.position);
                        }
                    }
                    //dów góra
                    if (path.AllRoads[x][i].x > path.AllRoads[x][i + 1].x)
                    {
                        if (path.AllRoads[x][i].waypoint_nr13 != null && path.AllRoads[x][i].waypoint_nr13.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr13.transform.position, path.AllRoads[x][i].waypoint_nr13.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr10 != null && path.AllRoads[x][i + 1].waypoint_nr10.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr2.transform.position, path.AllRoads[x][i + 1].waypoint_nr2.nextWaypoint.transform.position);
                        }
                    }
                    DrawWaypointInCircle(path.AllRoads, x, i);
                }
                //ronda i skrecające drogi 
                if (path.AllRoads[x][i].tag == "circle" && path.AllRoads[x][i + 1].tag == "Road_1_line_turn")
                {
                    //lewo prawo
                    if (path.AllRoads[x][i].y < path.AllRoads[x][i + 1].y)
                    {
                        if (path.AllRoads[x][i].waypoint_nr12 != null && path.AllRoads[x][i].waypoint_nr12.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr12.transform.position, path.AllRoads[x][i].waypoint_nr12.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr4 != null && path.AllRoads[x][i + 1].waypoint_nr4.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr4.transform.position, path.AllRoads[x][i + 1].waypoint_nr4.nextWaypoint.transform.position);
                        }
                    }
                    //dół góra
                    if (path.AllRoads[x][i].x < path.AllRoads[x][i + 1].x)
                    {
                        if (path.AllRoads[x][i].waypoint_nr13 != null && path.AllRoads[x][i].waypoint_nr13.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr13.transform.position, path.AllRoads[x][i].waypoint_nr13.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr8 != null && path.AllRoads[x][i + 1].waypoint_nr8.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr8.transform.position, path.AllRoads[x][i + 1].waypoint_nr1.nextWaypoint.transform.position);
                        }
                    }
                }
                if (path.AllRoads[x][i].tag == "circle" && path.AllRoads[x][i + 1].tag == "Road_1_line_turn_90")
                {
                    //lewo prawo
                    if (path.AllRoads[x][i].y < path.AllRoads[x][i + 1].y)
                    {
                        if (path.AllRoads[x][i].waypoint_nr12 != null && path.AllRoads[x][i].waypoint_nr12.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr12.transform.position, path.AllRoads[x][i].waypoint_nr12.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr8 != null && path.AllRoads[x][i + 1].waypoint_nr8.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr8.transform.position, path.AllRoads[x][i + 1].waypoint_nr8.nextWaypoint.transform.position);
                        }
                        DrawWaypointInCircle(path.AllRoads, x, i);
                    }
                    //góra-> dół
                    if (path.AllRoads[x][i].x < path.AllRoads[x][i + 1].x)
                    {
                        if (path.AllRoads[x][i].waypoint_nr10 != null && path.AllRoads[x][i].waypoint_nr10.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr10.transform.position, path.AllRoads[x][i].waypoint_nr10.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr4 != null && path.AllRoads[x][i + 1].waypoint_nr4.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr4.transform.position, path.AllRoads[x][i + 1].waypoint_nr4.nextWaypoint.transform.position);
                        }
                    }
                }
                if (path.AllRoads[x][i].tag == "circle" && path.AllRoads[x][i + 1].tag == "Road_1_line_turn_180")
                {
                    //prawo lewo
                    if (path.AllRoads[x][i].y > path.AllRoads[x][i + 1].y)
                    {
                        if (path.AllRoads[x][i].waypoint_nr15 != null && path.AllRoads[x][i].waypoint_nr15.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr15.transform.position, path.AllRoads[x][i].waypoint_nr15.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr8 != null && path.AllRoads[x][i + 1].waypoint_nr8.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr8.transform.position, path.AllRoads[x][i + 1].waypoint_nr8.nextWaypoint.transform.position);
                        }
                    }
                    //dół-> góra
                    if (path.AllRoads[x][i].x < path.AllRoads[x][i + 1].x)
                    {
                        if (path.AllRoads[x][i].waypoint_nr10 != null && path.AllRoads[x][i].waypoint_nr10.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr10.transform.position, path.AllRoads[x][i].waypoint_nr10.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr4 != null && path.AllRoads[x][i + 1].waypoint_nr4.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr4.transform.position, path.AllRoads[x][i + 1].waypoint_nr4.nextWaypoint.transform.position);
                        }
                    }
                }
                if (path.AllRoads[x][i].tag == "circle" && path.AllRoads[x][i + 1].tag == "Road_1_line_turn_270")
                {
                    //prawo lewo
                    if (path.AllRoads[x][i].y > path.AllRoads[x][i + 1].y)
                    {
                        if (path.AllRoads[x][i].waypoint_nr15 != null && path.AllRoads[x][i].waypoint_nr15.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr15.transform.position, path.AllRoads[x][i].waypoint_nr15.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr4 != null && path.AllRoads[x][i + 1].waypoint_nr4.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr4.transform.position, path.AllRoads[x][i + 1].waypoint_nr4.nextWaypoint.transform.position);
                        }
                    }
                    //dół-> góra
                    if (path.AllRoads[x][i].x > path.AllRoads[x][i + 1].x)
                    {
                        if (path.AllRoads[x][i].waypoint_nr13 != null && path.AllRoads[x][i].waypoint_nr13.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr13.transform.position, path.AllRoads[x][i].waypoint_nr13.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr8 != null && path.AllRoads[x][i + 1].waypoint_nr8.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr8.transform.position, path.AllRoads[x][i + 1].waypoint_nr8.nextWaypoint.transform.position);
                        }
                    }
                }
                /// cross road i proste drogi -> zaczynając od drogi
                if (path.AllRoads[x][i].tag == "Road_1_line" && path.AllRoads[x][i + 1].tag == "crossroad_90")
                {
                    if (path.AllRoads[x][i].waypoint_nr1 != null && path.AllRoads[x][i].waypoint_nr1.nextWaypoint != null)
                    {
                        Gizmos.color = Color.red;
                        Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr1.transform.position, path.AllRoads[x][i].waypoint_nr1.nextWaypoint.transform.position);
                    }
                    if (path.AllRoads[x][i + 1].waypoint_nr9 != null && path.AllRoads[x][i + 1].waypoint_nr9.nextWaypoint != null)
                    {
                        Gizmos.color = Color.blue;
                        Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr9.transform.position, path.AllRoads[x][i + 1].waypoint_nr9.nextWaypoint.transform.position);
                    }

                }
                if (path.AllRoads[x][i].tag == "Road_1_line_90" && path.AllRoads[x][i + 1].tag == "crossroad_90")
                {
                    //góra->dół
                    if (path.AllRoads[x][i].x < path.AllRoads[x][i + 1].x)
                    {
                        if (path.AllRoads[x][i].waypoint_nr2 != null && path.AllRoads[x][i].waypoint_nr2.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr2.transform.position, path.AllRoads[x][i].waypoint_nr2.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr4 != null && path.AllRoads[x][i + 1].waypoint_nr4.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr4.transform.position, path.AllRoads[x][i + 1].waypoint_nr4.nextWaypoint.transform.position);
                        }
                    }
                    //dół->góra
                    if (path.AllRoads[x][i].x >path.AllRoads[x][i + 1].x)
                    {
                        if (path.AllRoads[x][i].waypoint_nr1 != null && path.AllRoads[x][i].waypoint_nr1.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr1.transform.position, path.AllRoads[x][i].waypoint_nr1.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr8 != null && path.AllRoads[x][i + 1].waypoint_nr8.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr8.transform.position, path.AllRoads[x][i + 1].waypoint_nr8.nextWaypoint.transform.position);
                        }
                    }
                }
                /// cross road i proste drogi -> zaczynając od drogi

                if (i != path.AllRoads[x].Count - 1 && path.AllRoads[x][i].tag == "crossroad_90" && path.AllRoads[x][i + 1].tag == "Road_1_line")
                {
                    if (path.AllRoads[x][i].waypoint_nr9 != null && path.AllRoads[x][i].waypoint_nr9.nextWaypoint != null)
                    {
                        Gizmos.color = Color.red;
                        Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr9.transform.position, path.AllRoads[x][i].waypoint_nr9.nextWaypoint.transform.position);
                    }
                    if (path.AllRoads[x][i + 1].waypoint_nr1 != null && path.AllRoads[x][i + 1].waypoint_nr1.nextWaypoint != null)
                    {
                        Gizmos.color = Color.blue;
                        Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr1.transform.position, path.AllRoads[x][i + 1].waypoint_nr1.nextWaypoint.transform.position);
                    }

                }
              
                if ( i!= path.AllRoads[x].Count-1 && path.AllRoads[x][i].tag == "crossroad_90" && path.AllRoads[x][i + 1].tag == "Road_1_line_90")
                {
                    //góra->dół
                    if (path.AllRoads[x][i].x < path.AllRoads[x][i + 1].x)
                    {
                        if (path.AllRoads[x][i].waypoint_nr8 != null && path.AllRoads[x][i].waypoint_nr8.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr8.transform.position, path.AllRoads[x][i].waypoint_nr8.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr1 != null && path.AllRoads[x][i + 1].waypoint_nr1.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr1.transform.position, path.AllRoads[x][i + 1].waypoint_nr1.nextWaypoint.transform.position);
                        }
                    }
                    //dół->góra
                    if (path.AllRoads[x][i].x > path.AllRoads[x][i + 1].x)
                    {
                        if (path.AllRoads[x][i].waypoint_nr4 != null && path.AllRoads[x][i].waypoint_nr4.nextWaypoint != null)
                        {
                            Gizmos.color = Color.red;
                            Gizmos.DrawLine(path.AllRoads[x][i].waypoint_nr4.transform.position, path.AllRoads[x][i].waypoint_nr4.nextWaypoint.transform.position);
                        }
                        if (path.AllRoads[x][i + 1].waypoint_nr2 != null && path.AllRoads[x][i + 1].waypoint_nr2.nextWaypoint != null)
                        {
                            Gizmos.color = Color.blue;
                            Gizmos.DrawLine(path.AllRoads[x][i + 1].waypoint_nr2.transform.position, path.AllRoads[x][i + 1].waypoint_nr2.nextWaypoint.transform.position);
                        }
                    }
                }
              


            }

        }
       
    }
   
}
