using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    // Start is called before the first frame update
    public MapGenerator Map;

    public void WaypointConnect()
    {
        Debug.Log("path");
        Debug.Log("number of lis" + Map.roads_list.Count);
        /*  for (int i = 0; i < Map.roads_list.Count; i++)
          {

              if (Map.roads_list[i].tag == "Road_1_line" && Map.roads_list[i+1].tag == "Road_1_line")
              {
                  if (Map.roads_list[i].waypoint_nr1 != null && Map.roads_list[i + 1].waypoint_nr1 != null)
                      Map.roads_list[i].waypoint_nr1.nextWaypoint = Map.roads_list[i + 1].waypoint_nr1;
              }
              if (Map.roads_list[i].tag == "Road_1_line" && Map.roads_list[i + 1].tag == "Road_1_line_turn_90")
              {
                  if (Map.roads_list[i].waypoint_nr1 != null && Map.roads_list[i + 1].waypoint_nr1 != null)
                      Map.roads_list[i].waypoint_nr1.nextWaypoint = Map.roads_list[i + 1].waypoint_nr1;
              }
              if (Map.roads_list[i].tag == "Road_1_line_turn_90" && Map.roads_list[i + 1].tag == "Road_1_line_90")
              {
                  if (Map.roads_list[i].waypoint_nr4 != null && Map.roads_list[i + 1].waypoint_nr1 != null)
                      Map.roads_list[i].waypoint_nr4.nextWaypoint = Map.roads_list[i + 1].waypoint_nr1;
              }
              if (Map.roads_list[i].tag == "Road_1_line_90" && Map.roads_list[i + 1].tag == "Road_1_line_90")
              {
                  if (Map.roads_list[i].waypoint_nr1 != null && Map.roads_list[i + 1].waypoint_nr1 != null)
                      Map.roads_list[i].waypoint_nr1.nextWaypoint = Map.roads_list[i + 1].waypoint_nr1;
              }
              if (Map.roads_list[i].tag == "Road_1_line" && Map.roads_list[i + 1].tag == "Road_1_line_turn_180")
              {
                  if (Map.roads_list[i].waypoint_nr1 != null && Map.roads_list[i + 1].waypoint_nr1 != null)
                      Map.roads_list[i].waypoint_nr1.nextWaypoint = Map.roads_list[i + 1].waypoint_nr1;
              }
          }


          for (int i = Map.roads_list.Count-1; i >0 ; i--)
          {
              if (Map.roads_list[i].tag == "Road_1_line" && Map.roads_list[i - 1].tag == "Road_1_line")
              {
                  if (Map.roads_list[i].waypoint_nr2 != null && Map.roads_list[i - 1].waypoint_nr2 != null)
                      Map.roads_list[i].waypoint_nr2.nextWaypoint = Map.roads_list[i - 1].waypoint_nr2;
              }
              if (Map.roads_list[i].tag == "Road_1_line_turn_90" && Map.roads_list[i - 1].tag == "Road_1_line")
              {
                  if (Map.roads_list[i].waypoint_nr8 != null && Map.roads_list[i - 1].waypoint_nr2 != null)
                  {
                      Map.roads_list[i].waypoint_nr8.nextWaypoint = Map.roads_list[i - 1].waypoint_nr2;
                  }

              }
              if (Map.roads_list[i].tag == "Road_1_line_90" && Map.roads_list[i - 1].tag == "Road_1_line_turn_90")
              {
                  if (Map.roads_list[i].waypoint_nr2 != null && Map.roads_list[i - 1].waypoint_nr5 != null)
                  {
                      Map.roads_list[i].waypoint_nr2.nextWaypoint = Map.roads_list[i - 1].waypoint_nr5;
                  }

              }
              if (Map.roads_list[i].tag == "Road_1_line_90" && Map.roads_list[i - 1].tag == "Road_1_line_90")
              {
                  if (Map.roads_list[i].waypoint_nr2 != null && Map.roads_list[i - 1].waypoint_nr2 != null)
                      Map.roads_list[i].waypoint_nr2.nextWaypoint = Map.roads_list[i - 1].waypoint_nr2;
              }
          }
        */

        for (int i = 0; i < Map.roads_list.Count; i++)
        {
            if(Map.roads_list[i].tag == "Road_1_line" && Map.roads_list[i + 1].tag == "Road_1_line")
            {   
                //jeżeli leci lewo->prawo
                if(Map.roads_list[i].y< Map.roads_list[i + 1].y)
                {
                    if (Map.roads_list[i].waypoint_nr1 != null && Map.roads_list[i + 1].waypoint_nr1 != null && Map.roads_list[i].waypoint_nr2 != null && Map.roads_list[i + 1].waypoint_nr2 != null)
                    {
                        Map.roads_list[i].waypoint_nr1.nextWaypoint = Map.roads_list[i+1].waypoint_nr1;
                        Map.roads_list[i+1].waypoint_nr2.nextWaypoint = Map.roads_list[i].waypoint_nr2;
                    }

                }
                //jeżeli leci prawo->lewo
                if (Map.roads_list[i].y > Map.roads_list[i + 1].y)
                {
                    if (Map.roads_list[i].waypoint_nr1 != null && Map.roads_list[i + 1].waypoint_nr1 != null && Map.roads_list[i].waypoint_nr2 != null && Map.roads_list[i + 1].waypoint_nr2 != null)
                    {
                        Map.roads_list[i].waypoint_nr2.nextWaypoint = Map.roads_list[i + 1].waypoint_nr2;
                        Map.roads_list[i + 1].waypoint_nr1.nextWaypoint = Map.roads_list[i].waypoint_nr1;
                    }

                }

            }
            if (Map.roads_list[i].tag == "Road_1_line" && Map.roads_list[i + 1].tag == "Road_1_line_turn_90")
            {
                //zawsze leci lewo_prawo, wiec nie trzeba sprawdzac w ktora storne to leci
                if (Map.roads_list[i].waypoint_nr1 != null && Map.roads_list[i + 1].waypoint_nr1 != null && Map.roads_list[i].waypoint_nr2 != null && Map.roads_list[i + 1].waypoint_nr8 != null)
                {
                    Map.roads_list[i].waypoint_nr1.nextWaypoint = Map.roads_list[i + 1].waypoint_nr1;
                    Map.roads_list[i + 1].waypoint_nr8.nextWaypoint = Map.roads_list[i].waypoint_nr2;
                }

            }
            if(Map.roads_list[i].tag == "Road_1_line_turn_90" && Map.roads_list[i + 1].tag== "Road_1_line_90")
            {
                //tez nie ma innej mozliwosci musi leciec do gory
                if (Map.roads_list[i].waypoint_nr4 != null && Map.roads_list[i + 1].waypoint_nr1 != null && Map.roads_list[i].waypoint_nr5 != null && Map.roads_list[i + 1].waypoint_nr2 != null)
                {
                    Map.roads_list[i].waypoint_nr4.nextWaypoint= Map.roads_list[i + 1].waypoint_nr1;
                    Map.roads_list[i + 1].waypoint_nr2.nextWaypoint = Map.roads_list[i].waypoint_nr5;
                }
            }
            if(Map.roads_list[i].tag == "Road_1_line_90" && Map.roads_list[i + 1].tag == "Road_1_line_90")
            {
                //jezeli leci dół->góra
                if (Map.roads_list[i].x > Map.roads_list[i + 1].x)
                {
                    if (Map.roads_list[i].waypoint_nr1 != null && Map.roads_list[i + 1].waypoint_nr1 != null && Map.roads_list[i].waypoint_nr2 != null && Map.roads_list[i + 1].waypoint_nr2 != null)
                    {
                        Map.roads_list[i].waypoint_nr1.nextWaypoint = Map.roads_list[i + 1].waypoint_nr1;
                        Map.roads_list[i + 1].waypoint_nr2.nextWaypoint = Map.roads_list[i].waypoint_nr2;
                    }
                }
                //jeżeli leci góra->dół
                if (Map.roads_list[i].x < Map.roads_list[i + 1].x)
                {
                    Map.roads_list[i].waypoint_nr2.nextWaypoint = Map.roads_list[i + 1].waypoint_nr2;
                    Map.roads_list[i + 1].waypoint_nr1.nextWaypoint = Map.roads_list[i].waypoint_nr1;
                }
            }
            if (Map.roads_list[i].tag == "Road_1_line_90" && Map.roads_list[i + 1].tag == "Road_1_line_turn_90")
            {
                //nie muszę spradzać bo wiadomo że leci od góry

                if (Map.roads_list[i].waypoint_nr2 != null && Map.roads_list[i + 1].waypoint_nr2 != null && Map.roads_list[i].waypoint_nr1 != null && Map.roads_list[i + 1].waypoint_nr1 != null)
                {
                    Map.roads_list[i].waypoint_nr2.nextWaypoint = Map.roads_list[i + 1].waypoint_nr5;
                    Map.roads_list[i + 1].waypoint_nr4.nextWaypoint = Map.roads_list[i].waypoint_nr1;

                }
            }
            if (Map.roads_list[i].tag == "Road_1_line_turn_90" && Map.roads_list[i + 1].tag == "Road_1_line")
            {
                //nie musze sprawdzać bo wiadomo ze leci w lewo
                if (Map.roads_list[i].waypoint_nr1 != null && Map.roads_list[i + 1].waypoint_nr1 != null && Map.roads_list[i].waypoint_nr8 != null && Map.roads_list[i + 1].waypoint_nr2 != null)
                {
                    Map.roads_list[i].waypoint_nr8.nextWaypoint = Map.roads_list[i + 1].waypoint_nr2;
                    Map.roads_list[i + 1].waypoint_nr1.nextWaypoint = Map.roads_list[i].waypoint_nr1;
                }
            }
            if (Map.roads_list[i].tag == "Road_1_line" && Map.roads_list[i + 1].tag == "Road_1_line_turn_180")
            {
                if (Map.roads_list[i].waypoint_nr1 != null && Map.roads_list[i + 1].waypoint_nr1 != null && Map.roads_list[i].waypoint_nr2 != null && Map.roads_list[i + 1].waypoint_nr8 != null)
                {
                    Map.roads_list[i].waypoint_nr2.nextWaypoint = Map.roads_list[i + 1].waypoint_nr1;
                    Map.roads_list[i + 1].waypoint_nr8.nextWaypoint = Map.roads_list[i].waypoint_nr1;
                }
            }
            if (Map.roads_list[i].tag == "Road_1_line_turn_180" && Map.roads_list[i + 1].tag == "Road_1_line_90")
            {
                if (Map.roads_list[i].waypoint_nr4 != null && Map.roads_list[i + 1].waypoint_nr1 != null && Map.roads_list[i].waypoint_nr5 != null && Map.roads_list[i + 1].waypoint_nr2 != null)
                {
                    Map.roads_list[i].waypoint_nr4.nextWaypoint = Map.roads_list[i + 1].waypoint_nr1;
                    Map.roads_list[i + 1].waypoint_nr2.nextWaypoint = Map.roads_list[i].waypoint_nr5;
                }
            }
            if (Map.roads_list[i].tag == "Road_1_line_90" && Map.roads_list[i + 1].tag == "Road_1_line_turn")
            {
                if (Map.roads_list[i].waypoint_nr1 != null && Map.roads_list[i + 1].waypoint_nr1 != null && Map.roads_list[i].waypoint_nr2 != null && Map.roads_list[i + 1].waypoint_nr8 != null)
                {
                    Map.roads_list[i].waypoint_nr1.nextWaypoint = Map.roads_list[i + 1].waypoint_nr1;
                    Map.roads_list[i + 1].waypoint_nr8.nextWaypoint = Map.roads_list[i].waypoint_nr2;
                }
            }
            if (Map.roads_list[i].tag == "Road_1_line_turn" &&Map.roads_list[i + 1].tag == "Road_1_line")
            {
                if (Map.roads_list[i].waypoint_nr4 != null && Map.roads_list[i + 1].waypoint_nr2 != null && Map.roads_list[i].waypoint_nr5 != null && Map.roads_list[i + 1].waypoint_nr2 != null)
                {
                    Map.roads_list[i].waypoint_nr4.nextWaypoint = Map.roads_list[i + 1].waypoint_nr2;
                    Map.roads_list[i + 1].waypoint_nr1.nextWaypoint = Map.roads_list[i].waypoint_nr5;
                }

            }
            if (Map.roads_list[i].tag == "Road_1_line" && Map.roads_list[i + 1].tag == "Road_1_line_turn")
            {
                if (Map.roads_list[i].waypoint_nr1 != null && Map.roads_list[i + 1].waypoint_nr5 != null && Map.roads_list[i].waypoint_nr2 != null && Map.roads_list[i + 1].waypoint_nr4 != null)
                {
                    Map.roads_list[i].waypoint_nr1.nextWaypoint = Map.roads_list[i + 1].waypoint_nr5;
                    Map.roads_list[i + 1].waypoint_nr4.nextWaypoint = Map.roads_list[i].waypoint_nr2;
                }

            }
            if (Map.roads_list[i].tag == "Road_1_line_turn" && Map.roads_list[i + 1].tag == "Road_1_line_90")
            {
                if (Map.roads_list[i].waypoint_nr1 != null && Map.roads_list[i + 1].waypoint_nr1 != null && Map.roads_list[i].waypoint_nr8 != null && Map.roads_list[i + 1].waypoint_nr2 != null)
                {
                    Map.roads_list[i].waypoint_nr8.nextWaypoint = Map.roads_list[i + 1].waypoint_nr2;
                    Map.roads_list[i + 1].waypoint_nr1.nextWaypoint = Map.roads_list[i].waypoint_nr1;
                }
            }
            if (Map.roads_list[i].tag == "Road_1_line" && Map.roads_list[i + 1].tag == "Road_1_line_turn_270")
            {
                if (Map.roads_list[i].waypoint_nr1 != null && Map.roads_list[i + 1].waypoint_nr4 != null && Map.roads_list[i].waypoint_nr2 != null && Map.roads_list[i + 1].waypoint_nr5 != null)
                {

                    Map.roads_list[i].waypoint_nr2.nextWaypoint = Map.roads_list[i + 1].waypoint_nr5;
                    Map.roads_list[i + 1].waypoint_nr4.nextWaypoint = Map.roads_list[i].waypoint_nr1;
                }
            }
            if (Map.roads_list[i].tag == "Road_1_line_turn_270" && Map.roads_list[i + 1].tag == "Road_1_line_90")
            {
                if (Map.roads_list[i].waypoint_nr8 != null && Map.roads_list[i + 1].waypoint_nr2 != null && Map.roads_list[i].waypoint_nr1 != null && Map.roads_list[i + 1].waypoint_nr1 != null)
                {

                    Map.roads_list[i].waypoint_nr8.nextWaypoint = Map.roads_list[i + 1].waypoint_nr2;
                    Map.roads_list[i + 1].waypoint_nr1.nextWaypoint = Map.roads_list[i].waypoint_nr1;
                }
            }
            if (Map.roads_list[i].tag == "Road_1_line_90" && Map.roads_list[i + 1].tag == "Road_1_line_turn_270")
            {
                if (Map.roads_list[i].waypoint_nr2 != null && Map.roads_list[i + 1].waypoint_nr8 != null && Map.roads_list[i].waypoint_nr1 != null && Map.roads_list[i + 1].waypoint_nr1 != null)
                {

                    Map.roads_list[i].waypoint_nr1.nextWaypoint = Map.roads_list[i + 1].waypoint_nr1;
                    Map.roads_list[i + 1].waypoint_nr8.nextWaypoint = Map.roads_list[i].waypoint_nr2;
                }
            }
            if (Map.roads_list[i].tag == "Road_1_line_turn_270" && Map.roads_list[i + 1].tag == "Road_1_line")
            {
                if (Map.roads_list[i].waypoint_nr4 != null && Map.roads_list[i + 1].waypoint_nr1 != null && Map.roads_list[i].waypoint_nr5 != null && Map.roads_list[i + 1].waypoint_nr2 != null)
                {

                    Map.roads_list[i].waypoint_nr4.nextWaypoint = Map.roads_list[i + 1].waypoint_nr1;
                    Map.roads_list[i + 1].waypoint_nr2.nextWaypoint = Map.roads_list[i].waypoint_nr5;
                }
            }


        }


    }
}
