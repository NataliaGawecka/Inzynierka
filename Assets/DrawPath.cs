using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPath : MonoBehaviour
{

   public Path path;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {

        /*for (int i = 0; i < path.Map.roads_list.Count; i++)
        {
            Gizmos.color = Color.red;
            if (path.Map.roads_list[i].tag == "Road_1_line") {
                if (path.Map.roads_list[i].waypoint_nr1 != null && path.Map.roads_list[i].waypoint_nr1.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr1.transform.position, path.Map.roads_list[i].waypoint_nr1.nextWaypoint.transform.position);
            }
              
            if (path.Map.roads_list[i].tag == "Road_1_line_turn_90")
            {
                if (path.Map.roads_list[i].waypoint_nr1.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr1.transform.position, path.Map.roads_list[i].waypoint_nr1.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr2.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr2.transform.position, path.Map.roads_list[i].waypoint_nr2.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr3.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr3.transform.position, path.Map.roads_list[i].waypoint_nr3.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr4.nextWaypoint != null)
                Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr4.transform.position, path.Map.roads_list[i].waypoint_nr4.nextWaypoint.transform.position);
             
            }
            if (path.Map.roads_list[i].tag == "Road_1_line_90")
            {
                if (path.Map.roads_list[i].waypoint_nr1 != null && path.Map.roads_list[i].waypoint_nr1.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr1.transform.position, path.Map.roads_list[i].waypoint_nr1.nextWaypoint.transform.position);
            }
        }


       
        for (int i = path.Map.roads_list.Count-1; i>0 ; i--)
        {
            Gizmos.color = Color.blue;
            if (path.Map.roads_list[i].tag == "Road_1_line")
            {
                if (path.Map.roads_list[i].waypoint_nr2 != null && path.Map.roads_list[i].waypoint_nr2.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr2.transform.position, path.Map.roads_list[i].waypoint_nr2.nextWaypoint.transform.position);
            }
            if (path.Map.roads_list[i].tag == "Road_1_line_turn_90")
            {
                if (path.Map.roads_list[i].waypoint_nr5.nextWaypoint != null)
                Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr5.transform.position, path.Map.roads_list[i].waypoint_nr5.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr6.nextWaypoint != null)
                Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr6.transform.position, path.Map.roads_list[i].waypoint_nr6.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr7.nextWaypoint != null)
                Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr7.transform.position, path.Map.roads_list[i].waypoint_nr7.nextWaypoint.transform.position);
                if(path.Map.roads_list[i].waypoint_nr8.nextWaypoint!=null)
                Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr8.transform.position, path.Map.roads_list[i].waypoint_nr8.nextWaypoint.transform.position);
            }
            if (path.Map.roads_list[i].tag == "Road_1_line_90")
            {
                if (path.Map.roads_list[i].waypoint_nr2 != null && path.Map.roads_list[i].waypoint_nr2.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr2.transform.position, path.Map.roads_list[i].waypoint_nr2.nextWaypoint.transform.position);
            }
        }
        */

        for (int i = 0; i < path.Map.roads_list.Count; i++)
        {
            Gizmos.color = Color.red;
            if (path.Map.roads_list[i].tag == "Road_1_line" && path.Map.roads_list[i+1].tag == "Road_1_line")
            {
                if (path.Map.roads_list[i].y < path.Map.roads_list[i + 1].y)
                {
                    if (path.Map.roads_list[i].waypoint_nr1 != null && path.Map.roads_list[i].waypoint_nr1.nextWaypoint != null)
                    {
                        Gizmos.color = Color.red;
                        Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr1.transform.position, path.Map.roads_list[i].waypoint_nr1.nextWaypoint.transform.position);


                    }
                    if (path.Map.roads_list[i+1].waypoint_nr2 != null && path.Map.roads_list[i+1].waypoint_nr2.nextWaypoint != null)
                    {
                        Gizmos.color = Color.blue;
                        Gizmos.DrawLine(path.Map.roads_list[i+1].waypoint_nr2.transform.position, path.Map.roads_list[i+1].waypoint_nr2.nextWaypoint.transform.position);

                    }
                }
               if (path.Map.roads_list[i].y > path.Map.roads_list[i + 1].y)
                    {
                    if (path.Map.roads_list[i+1].waypoint_nr1 != null && path.Map.roads_list[i+1].waypoint_nr1.nextWaypoint != null)
                    {
                        Gizmos.color = Color.blue;
                        Gizmos.DrawLine(path.Map.roads_list[i+1].waypoint_nr1.transform.position, path.Map.roads_list[i+1].waypoint_nr1.nextWaypoint.transform.position);
                    }
                    if (path.Map.roads_list[i].waypoint_nr2 != null && path.Map.roads_list[i].waypoint_nr2.nextWaypoint != null)
                    {
                        Gizmos.color = Color.red;
                        Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr2.transform.position, path.Map.roads_list[i].waypoint_nr2.nextWaypoint.transform.position);


                    }

                }
            }
            if (path.Map.roads_list[i].tag == "Road_1_line" && path.Map.roads_list[i + 1].tag == "Road_1_line_turn_90")
            {
               if (path.Map.roads_list[i].waypoint_nr1 != null && path.Map.roads_list[i].waypoint_nr1.nextWaypoint != null)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr1.transform.position, path.Map.roads_list[i].waypoint_nr1.nextWaypoint.transform.position);
                }
                if(path.Map.roads_list[i+1].waypoint_nr8 != null && path.Map.roads_list[i+1].waypoint_nr8.nextWaypoint != null)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(path.Map.roads_list[i+1].waypoint_nr8.transform.position, path.Map.roads_list[i+1].waypoint_nr8.nextWaypoint.transform.position);
                }
                
            }
            if(path.Map.roads_list[i].tag == "Road_1_line_turn_90" && path.Map.roads_list[i + 1].tag == "Road_1_line_90")
            {
                Gizmos.color = Color.red;
                if (path.Map.roads_list[i].waypoint_nr1.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr1.transform.position, path.Map.roads_list[i].waypoint_nr1.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr2.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr2.transform.position, path.Map.roads_list[i].waypoint_nr2.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr3.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr3.transform.position, path.Map.roads_list[i].waypoint_nr3.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr4.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr4.transform.position, path.Map.roads_list[i].waypoint_nr4.nextWaypoint.transform.position);
                    Gizmos.color = Color.blue;
                if (path.Map.roads_list[i].waypoint_nr5.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr5.transform.position, path.Map.roads_list[i].waypoint_nr5.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr6.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr6.transform.position, path.Map.roads_list[i].waypoint_nr6.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr7.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr7.transform.position, path.Map.roads_list[i].waypoint_nr7.nextWaypoint.transform.position);
                if (path.Map.roads_list[i+1].waypoint_nr2.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i+1].waypoint_nr2.transform.position, path.Map.roads_list[i+1].waypoint_nr2.nextWaypoint.transform.position);

            }
            if (path.Map.roads_list[i].tag == "Road_1_line_90" && path.Map.roads_list[i + 1].tag == "Road_1_line_90")
            {
                if(path.Map.roads_list[i].x > path.Map.roads_list[i + 1].x)
                {
                    if (path.Map.roads_list[i].waypoint_nr1 != null && path.Map.roads_list[i].waypoint_nr1.nextWaypoint != null)
                    {
                        Gizmos.color = Color.red;
                        Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr1.transform.position, path.Map.roads_list[i].waypoint_nr1.nextWaypoint.transform.position);


                    }
                    if (path.Map.roads_list[i + 1].waypoint_nr2 != null && path.Map.roads_list[i + 1].waypoint_nr2.nextWaypoint != null)
                    {
                        Gizmos.color = Color.blue;
                        Gizmos.DrawLine(path.Map.roads_list[i + 1].waypoint_nr2.transform.position, path.Map.roads_list[i + 1].waypoint_nr2.nextWaypoint.transform.position);

                    }
                }
                if (path.Map.roads_list[i].x < path.Map.roads_list[i + 1].x)
                {
                    if (path.Map.roads_list[i].waypoint_nr2 != null && path.Map.roads_list[i].waypoint_nr2.nextWaypoint != null)
                    {
                        Gizmos.color = Color.red;
                        Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr2.transform.position, path.Map.roads_list[i].waypoint_nr2.nextWaypoint.transform.position);
                    }
                    if (path.Map.roads_list[i + 1].waypoint_nr1 != null && path.Map.roads_list[i + 1].waypoint_nr1.nextWaypoint != null)
                    {
                        Gizmos.color = Color.blue;
                        Gizmos.DrawLine(path.Map.roads_list[i + 1].waypoint_nr1.transform.position, path.Map.roads_list[i + 1].waypoint_nr1.nextWaypoint.transform.position);
                    }

                }
            }
            if (path.Map.roads_list[i].tag == "Road_1_line_90" && path.Map.roads_list[i + 1].tag == "Road_1_line_turn_90")
            {

                if (path.Map.roads_list[i].waypoint_nr2 != null && path.Map.roads_list[i].waypoint_nr2.nextWaypoint != null)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr2.transform.position, path.Map.roads_list[i].waypoint_nr2.nextWaypoint.transform.position);
                }
                if (path.Map.roads_list[i + 1].waypoint_nr4 != null && path.Map.roads_list[i + 1].waypoint_nr4.nextWaypoint != null)
                {

                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(path.Map.roads_list[i+1].waypoint_nr4.transform.position, path.Map.roads_list[i+1].waypoint_nr4.nextWaypoint.transform.position);
                }
            }
            if (path.Map.roads_list[i].tag == "Road_1_line_turn_90" && path.Map.roads_list[i + 1].tag == "Road_1_line")
            {
                if (path.Map.roads_list[i].waypoint_nr8 != null && path.Map.roads_list[i].waypoint_nr8.nextWaypoint != null)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr8.transform.position, path.Map.roads_list[i].waypoint_nr8.nextWaypoint.transform.position);
                }
                if (path.Map.roads_list[i + 1].waypoint_nr1 != null && path.Map.roads_list[i + 1].waypoint_nr1.nextWaypoint != null)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(path.Map.roads_list[i+1].waypoint_nr1.transform.position, path.Map.roads_list[i+1].waypoint_nr1.nextWaypoint.transform.position);
                }
                Gizmos.color = Color.red;
                if (path.Map.roads_list[i].waypoint_nr5.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr5.transform.position, path.Map.roads_list[i].waypoint_nr5.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr6.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr6.transform.position, path.Map.roads_list[i].waypoint_nr6.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr7.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr7.transform.position, path.Map.roads_list[i].waypoint_nr7.nextWaypoint.transform.position);
                Gizmos.color = Color.blue;
                if (path.Map.roads_list[i].waypoint_nr1.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr1.transform.position, path.Map.roads_list[i].waypoint_nr1.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr2.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr2.transform.position, path.Map.roads_list[i].waypoint_nr2.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr3.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr3.transform.position, path.Map.roads_list[i].waypoint_nr3.nextWaypoint.transform.position);

            }
            if (path.Map.roads_list[i].tag == "Road_1_line" && path.Map.roads_list[i + 1].tag == "Road_1_line_turn_180")
            {
                if (path.Map.roads_list[i+1].waypoint_nr8 != null && path.Map.roads_list[i+1].waypoint_nr8.nextWaypoint != null)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(path.Map.roads_list[i+1].waypoint_nr8.transform.position, path.Map.roads_list[i+1].waypoint_nr8.nextWaypoint.transform.position);
                }
                if (path.Map.roads_list[i].waypoint_nr2 != null && path.Map.roads_list[i].waypoint_nr2.nextWaypoint != null)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr2.transform.position, path.Map.roads_list[i].waypoint_nr2.nextWaypoint.transform.position);
                }
            }
            if(path.Map.roads_list[i].tag == "Road_1_line_turn_180" && path.Map.roads_list[i + 1].tag == "Road_1_line_90")
            {
                if (path.Map.roads_list[i].waypoint_nr4 != null && path.Map.roads_list[i].waypoint_nr4.nextWaypoint != null)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr4.transform.position, path.Map.roads_list[i].waypoint_nr4.nextWaypoint.transform.position);
                }
                if (path.Map.roads_list[i+1].waypoint_nr2 != null && path.Map.roads_list[i+1].waypoint_nr2.nextWaypoint != null)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(path.Map.roads_list[i+1].waypoint_nr2.transform.position, path.Map.roads_list[i+1].waypoint_nr2.nextWaypoint.transform.position);
                }
                Gizmos.color = Color.red;
                if (path.Map.roads_list[i].waypoint_nr1.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr1.transform.position, path.Map.roads_list[i].waypoint_nr1.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr2.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr2.transform.position, path.Map.roads_list[i].waypoint_nr2.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr3.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr3.transform.position, path.Map.roads_list[i].waypoint_nr3.nextWaypoint.transform.position);
                Gizmos.color = Color.blue;
                if (path.Map.roads_list[i].waypoint_nr5.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr5.transform.position, path.Map.roads_list[i].waypoint_nr5.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr6.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr6.transform.position, path.Map.roads_list[i].waypoint_nr6.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr7.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr7.transform.position, path.Map.roads_list[i].waypoint_nr7.nextWaypoint.transform.position);
            }
            if (path.Map.roads_list[i].tag == "Road_1_line_90" && path.Map.roads_list[i + 1].tag == "Road_1_line_turn")
            {
                if (path.Map.roads_list[i].waypoint_nr1 != null && path.Map.roads_list[i].waypoint_nr1.nextWaypoint != null)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr1.transform.position, path.Map.roads_list[i].waypoint_nr1.nextWaypoint.transform.position);
                }
                if (path.Map.roads_list[i + 1].waypoint_nr8 != null && path.Map.roads_list[i + 1].waypoint_nr8.nextWaypoint != null)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(path.Map.roads_list[i + 1].waypoint_nr8.transform.position, path.Map.roads_list[i + 1].waypoint_nr8.nextWaypoint.transform.position);
                }

            }
            if (path.Map.roads_list[i].tag == "Road_1_line_turn" && path.Map.roads_list[i + 1].tag == "Road_1_line")
            {
                if (path.Map.roads_list[i].waypoint_nr4 != null && path.Map.roads_list[i].waypoint_nr4.nextWaypoint != null)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr4.transform.position, path.Map.roads_list[i].waypoint_nr4.nextWaypoint.transform.position);
                }
                if (path.Map.roads_list[i + 1].waypoint_nr1 != null && path.Map.roads_list[i + 1].waypoint_nr1.nextWaypoint != null)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(path.Map.roads_list[i + 1].waypoint_nr1.transform.position, path.Map.roads_list[i + 1].waypoint_nr1.nextWaypoint.transform.position);
                }
                Gizmos.color = Color.red;
                if (path.Map.roads_list[i].waypoint_nr1.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr1.transform.position, path.Map.roads_list[i].waypoint_nr1.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr2.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr2.transform.position, path.Map.roads_list[i].waypoint_nr2.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr3.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr3.transform.position, path.Map.roads_list[i].waypoint_nr3.nextWaypoint.transform.position);
                Gizmos.color = Color.blue;
                if (path.Map.roads_list[i].waypoint_nr5.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr5.transform.position, path.Map.roads_list[i].waypoint_nr5.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr6.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr6.transform.position, path.Map.roads_list[i].waypoint_nr6.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr7.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr7.transform.position, path.Map.roads_list[i].waypoint_nr7.nextWaypoint.transform.position);
            }
            if (path.Map.roads_list[i].tag == "Road_1_line" && path.Map.roads_list[i + 1].tag == "Road_1_line_turn")
            {
                if (path.Map.roads_list[i].waypoint_nr1 != null && path.Map.roads_list[i].waypoint_nr1.nextWaypoint != null)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr1.transform.position, path.Map.roads_list[i].waypoint_nr1.nextWaypoint.transform.position);
                }
                if (path.Map.roads_list[i + 1].waypoint_nr4 != null && path.Map.roads_list[i + 1].waypoint_nr4.nextWaypoint != null)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(path.Map.roads_list[i + 1].waypoint_nr4.transform.position, path.Map.roads_list[i + 1].waypoint_nr4.nextWaypoint.transform.position);
                }

            }
            if (path.Map.roads_list[i].tag == "Road_1_line_turn" && path.Map.roads_list[i + 1].tag == "Road_1_line_90")
            {
                if (path.Map.roads_list[i].waypoint_nr8 != null && path.Map.roads_list[i].waypoint_nr8.nextWaypoint != null)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr8.transform.position, path.Map.roads_list[i].waypoint_nr8.nextWaypoint.transform.position);
                }
                if (path.Map.roads_list[i + 1].waypoint_nr1 != null && path.Map.roads_list[i + 1].waypoint_nr1.nextWaypoint != null)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(path.Map.roads_list[i + 1].waypoint_nr1.transform.position, path.Map.roads_list[i + 1].waypoint_nr1.nextWaypoint.transform.position);

                }
                Gizmos.color = Color.red;
                if (path.Map.roads_list[i].waypoint_nr5.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr5.transform.position, path.Map.roads_list[i].waypoint_nr5.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr6.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr6.transform.position, path.Map.roads_list[i].waypoint_nr6.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr7.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr7.transform.position, path.Map.roads_list[i].waypoint_nr7.nextWaypoint.transform.position);
                Gizmos.color = Color.blue;
                if (path.Map.roads_list[i].waypoint_nr1.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr1.transform.position, path.Map.roads_list[i].waypoint_nr1.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr2.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr2.transform.position, path.Map.roads_list[i].waypoint_nr2.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr3.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr3.transform.position, path.Map.roads_list[i].waypoint_nr3.nextWaypoint.transform.position);
            }
            if (path.Map.roads_list[i].tag == "Road_1_line" && path.Map.roads_list[i + 1].tag == "Road_1_line_turn_270")
            {
                if (path.Map.roads_list[i].waypoint_nr2 != null && path.Map.roads_list[i].waypoint_nr2.nextWaypoint != null)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr2.transform.position, path.Map.roads_list[i].waypoint_nr2.nextWaypoint.transform.position);
                }
                if (path.Map.roads_list[i+1].waypoint_nr4 != null && path.Map.roads_list[i+1].waypoint_nr4.nextWaypoint != null)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(path.Map.roads_list[i+1].waypoint_nr4.transform.position, path.Map.roads_list[i+1].waypoint_nr4.nextWaypoint.transform.position);

                }
            }
            if (path.Map.roads_list[i].tag == "Road_1_line_turn_270" && path.Map.roads_list[i + 1].tag == "Road_1_line_90")
            {
                if (path.Map.roads_list[i].waypoint_nr8 != null && path.Map.roads_list[i].waypoint_nr8.nextWaypoint != null)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr8.transform.position, path.Map.roads_list[i].waypoint_nr8.nextWaypoint.transform.position);
                }
                if (path.Map.roads_list[i+1].waypoint_nr1 != null && path.Map.roads_list[i+1].waypoint_nr1.nextWaypoint != null)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(path.Map.roads_list[i+1].waypoint_nr1.transform.position, path.Map.roads_list[i+1].waypoint_nr1.nextWaypoint.transform.position);
                }
                Gizmos.color = Color.red;
                if (path.Map.roads_list[i].waypoint_nr5.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr5.transform.position, path.Map.roads_list[i].waypoint_nr5.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr6.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr6.transform.position, path.Map.roads_list[i].waypoint_nr6.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr7.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr7.transform.position, path.Map.roads_list[i].waypoint_nr7.nextWaypoint.transform.position);

                Gizmos.color = Color.blue;
                if (path.Map.roads_list[i].waypoint_nr1.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr1.transform.position, path.Map.roads_list[i].waypoint_nr1.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr2.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr2.transform.position, path.Map.roads_list[i].waypoint_nr2.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr3.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr3.transform.position, path.Map.roads_list[i].waypoint_nr3.nextWaypoint.transform.position);
            }
            if (path.Map.roads_list[i].tag == "Road_1_line_90" && path.Map.roads_list[i + 1].tag == "Road_1_line_turn_270")
            {
                if (path.Map.roads_list[i].waypoint_nr1 != null && path.Map.roads_list[i].waypoint_nr1.nextWaypoint != null)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr1.transform.position, path.Map.roads_list[i].waypoint_nr1.nextWaypoint.transform.position);
                }
                if (path.Map.roads_list[i + 1].waypoint_nr8 != null && path.Map.roads_list[i + 1].waypoint_nr8.nextWaypoint != null)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(path.Map.roads_list[i + 1].waypoint_nr8.transform.position, path.Map.roads_list[i + 1].waypoint_nr8.nextWaypoint.transform.position);
                }
            }
            if (path.Map.roads_list[i].tag == "Road_1_line_turn_270" && path.Map.roads_list[i + 1].tag == "Road_1_line")
            {
                if (path.Map.roads_list[i].waypoint_nr4 != null && path.Map.roads_list[i].waypoint_nr4.nextWaypoint != null)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr4.transform.position, path.Map.roads_list[i].waypoint_nr4.nextWaypoint.transform.position);
                }
                if (path.Map.roads_list[i + 1].waypoint_nr2 != null && path.Map.roads_list[i + 1].waypoint_nr2.nextWaypoint != null)
                {
                    Gizmos.color = Color.blue;
                    Gizmos.DrawLine(path.Map.roads_list[i + 1].waypoint_nr2.transform.position, path.Map.roads_list[i + 1].waypoint_nr2.nextWaypoint.transform.position);
                }
                Gizmos.color = Color.blue;
                if (path.Map.roads_list[i].waypoint_nr5.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr5.transform.position, path.Map.roads_list[i].waypoint_nr5.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr6.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr6.transform.position, path.Map.roads_list[i].waypoint_nr6.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr7.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr7.transform.position, path.Map.roads_list[i].waypoint_nr7.nextWaypoint.transform.position);

                Gizmos.color = Color.red;
                if (path.Map.roads_list[i].waypoint_nr1.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr1.transform.position, path.Map.roads_list[i].waypoint_nr1.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr2.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr2.transform.position, path.Map.roads_list[i].waypoint_nr2.nextWaypoint.transform.position);
                if (path.Map.roads_list[i].waypoint_nr3.nextWaypoint != null)
                    Gizmos.DrawLine(path.Map.roads_list[i].waypoint_nr3.transform.position, path.Map.roads_list[i].waypoint_nr3.nextWaypoint.transform.position);
            }






        }

          
        


    }
   
}
