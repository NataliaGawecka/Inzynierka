using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    // Start is called before the first frame update
    //public MapGenerator Map;
    public List<List<Roads_waypoint>> AllRoads;
  

    void Start()
    {
        AllRoads = new List<List<Roads_waypoint>>();
       
    }

    
    public void WaypointConnect()
    {
        Debug.Log("path");
        Debug.Log("number of lis" + AllRoads.Count);

        for (int x = 0; x < AllRoads.Count; x++)
        {
            for (int i = 0; i < AllRoads[x].Count; i++)
            {
                if (AllRoads[x][i].tag == "Road_1_line" && AllRoads[x][i + 1].tag == "Road_1_line")
                {
                    //jeżeli leci lewo->prawo
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        if (AllRoads[x][i].waypoint_nr1 != null && AllRoads[x][i + 1].waypoint_nr1 != null && AllRoads[x][i].waypoint_nr2 != null && AllRoads[x][i + 1].waypoint_nr2 != null)
                        {
                            AllRoads[x][i].waypoint_nr1.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                            AllRoads[x][i + 1].waypoint_nr2.nextWaypoint = AllRoads[x][i].waypoint_nr2;
                        }

                    }
                    //jeżeli leci prawo->lewo
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        if (AllRoads[x][i].waypoint_nr1 != null && AllRoads[x][i + 1].waypoint_nr1 != null && AllRoads[x][i].waypoint_nr2 != null && AllRoads[x][i + 1].waypoint_nr2 != null)
                        {
                            AllRoads[x][i].waypoint_nr2.nextWaypoint = AllRoads[x][i + 1].waypoint_nr2;
                            AllRoads[x][i + 1].waypoint_nr1.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                        }

                    }

                }
                if (AllRoads[x][i].tag == "Road_1_line" && AllRoads[x][i + 1].tag == "Road_1_line_turn_90")
                {
                    //zawsze leci lewo_prawo, wiec nie trzeba sprawdzac w ktora storne to leci
                    if (AllRoads[x][i].waypoint_nr1 != null && AllRoads[x][i + 1].waypoint_nr1 != null && AllRoads[x][i].waypoint_nr2 != null && AllRoads[x][i + 1].waypoint_nr8 != null)
                    {
                        AllRoads[x][i].waypoint_nr1.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr2;
                    }

                }
                if (AllRoads[x][i].tag == "Road_1_line_turn_90" && AllRoads[x][i + 1].tag == "Road_1_line_90")
                {
                    //tez nie ma innej mozliwosci musi leciec do gory
                    if (AllRoads[x][i].waypoint_nr4 != null && AllRoads[x][i + 1].waypoint_nr1 != null && AllRoads[x][i].waypoint_nr5 != null && AllRoads[x][i + 1].waypoint_nr2 != null)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr2.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line_90" && AllRoads[x][i + 1].tag == "Road_1_line_90")
                {
                    //jezeli leci dół->góra
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        if (AllRoads[x][i].waypoint_nr1 != null && AllRoads[x][i + 1].waypoint_nr1 != null && AllRoads[x][i].waypoint_nr2 != null && AllRoads[x][i + 1].waypoint_nr2 != null)
                        {
                            AllRoads[x][i].waypoint_nr1.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                            AllRoads[x][i + 1].waypoint_nr2.nextWaypoint = AllRoads[x][i].waypoint_nr2;
                        }
                    }
                    //jeżeli leci góra->dół
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr2.nextWaypoint = AllRoads[x][i + 1].waypoint_nr2;
                        AllRoads[x][i + 1].waypoint_nr1.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line_90" && AllRoads[x][i + 1].tag == "Road_1_line_turn_90")
                {
                    //nie muszę spradzać bo wiadomo że leci od góry

                    if (AllRoads[x][i].waypoint_nr2 != null && AllRoads[x][i + 1].waypoint_nr2 != null && AllRoads[x][i].waypoint_nr1 != null && AllRoads[x][i + 1].waypoint_nr1 != null)
                    {
                        AllRoads[x][i].waypoint_nr2.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr1;

                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line_turn_90" && AllRoads[x][i + 1].tag == "Road_1_line")
                {
                    //nie musze sprawdzać bo wiadomo ze leci w lewo
                    if (AllRoads[x][i].waypoint_nr1 != null && AllRoads[x][i + 1].waypoint_nr1 != null && AllRoads[x][i].waypoint_nr8 != null && AllRoads[x][i + 1].waypoint_nr2 != null)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr2;
                        AllRoads[x][i + 1].waypoint_nr1.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line" && AllRoads[x][i + 1].tag == "Road_1_line_turn_180")
                {
                    if (AllRoads[x][i].waypoint_nr1 != null && AllRoads[x][i + 1].waypoint_nr1 != null && AllRoads[x][i].waypoint_nr2 != null && AllRoads[x][i + 1].waypoint_nr8 != null)
                    {
                        AllRoads[x][i].waypoint_nr2.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line_turn_180" && AllRoads[x][i + 1].tag == "Road_1_line_90")
                {
                    if (AllRoads[x][i].waypoint_nr4 != null && AllRoads[x][i + 1].waypoint_nr1 != null && AllRoads[x][i].waypoint_nr5 != null && AllRoads[x][i + 1].waypoint_nr2 != null)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr2.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line_90" && AllRoads[x][i + 1].tag == "Road_1_line_turn")
                {
                    if (AllRoads[x][i].waypoint_nr1 != null && AllRoads[x][i + 1].waypoint_nr1 != null && AllRoads[x][i].waypoint_nr2 != null && AllRoads[x][i + 1].waypoint_nr8 != null)
                    {
                        AllRoads[x][i].waypoint_nr1.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr2;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line_turn" && AllRoads[x][i + 1].tag == "Road_1_line")
                {
                    if (AllRoads[x][i].waypoint_nr4 != null && AllRoads[x][i + 1].waypoint_nr2 != null && AllRoads[x][i].waypoint_nr5 != null && AllRoads[x][i + 1].waypoint_nr2 != null)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr2;
                        AllRoads[x][i + 1].waypoint_nr1.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }

                }
                if (AllRoads[x][i].tag == "Road_1_line" && AllRoads[x][i + 1].tag == "Road_1_line_turn")
                {
                    if (AllRoads[x][i].waypoint_nr1 != null && AllRoads[x][i + 1].waypoint_nr5 != null && AllRoads[x][i].waypoint_nr2 != null && AllRoads[x][i + 1].waypoint_nr4 != null)
                    {
                        AllRoads[x][i].waypoint_nr1.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr2;
                    }

                }
                if (AllRoads[x][i].tag == "Road_1_line_turn" && AllRoads[x][i + 1].tag == "Road_1_line_90")
                {
                    if (AllRoads[x][i].waypoint_nr1 != null && AllRoads[x][i + 1].waypoint_nr1 != null && AllRoads[x][i].waypoint_nr8 != null && AllRoads[x][i + 1].waypoint_nr2 != null)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr2;
                        AllRoads[x][i + 1].waypoint_nr1.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line" && AllRoads[x][i + 1].tag == "Road_1_line_turn_270")
                {
                    if (AllRoads[x][i].waypoint_nr1 != null && AllRoads[x][i + 1].waypoint_nr4 != null && AllRoads[x][i].waypoint_nr2 != null && AllRoads[x][i + 1].waypoint_nr5 != null)
                    {

                        AllRoads[x][i].waypoint_nr2.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line_turn_270" && AllRoads[x][i + 1].tag == "Road_1_line_90")
                {
                    if (AllRoads[x][i].waypoint_nr8 != null && AllRoads[x][i + 1].waypoint_nr2 != null && AllRoads[x][i].waypoint_nr1 != null && AllRoads[x][i + 1].waypoint_nr1 != null)
                    {

                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr2;
                        AllRoads[x][i + 1].waypoint_nr1.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line_90" && AllRoads[x][i + 1].tag == "Road_1_line_turn_270")
                {
                    if (AllRoads[x][i].waypoint_nr2 != null && AllRoads[x][i + 1].waypoint_nr8 != null && AllRoads[x][i].waypoint_nr1 != null && AllRoads[x][i + 1].waypoint_nr1 != null)
                    {

                        AllRoads[x][i].waypoint_nr1.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr2;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line_turn_270" && AllRoads[x][i + 1].tag == "Road_1_line")
                {
                    if (AllRoads[x][i].waypoint_nr4 != null && AllRoads[x][i + 1].waypoint_nr1 != null && AllRoads[x][i].waypoint_nr5 != null && AllRoads[x][i + 1].waypoint_nr2 != null)
                    {

                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr2.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                }
                if(AllRoads[x][i].tag== "Road_1_line" && AllRoads[x][i+1].tag == "circle")
                {   
                    //jezeli leci lewo -> prawo
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr1.nextWaypoint = AllRoads[x][i + 1].waypoint_nr16;
                        AllRoads[x][i+1].waypoint_nr15.nextWaypoint = AllRoads[x][i].waypoint_nr2;
                    }
                    //prawo_lewo
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr2.nextWaypoint = AllRoads[x][i + 1].waypoint_nr11;
                        AllRoads[x][i + 1].waypoint_nr12.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line_90" && AllRoads[x][i + 1].tag == "circle")
                {
                    //jezeli leci góra -> dół
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr2.nextWaypoint = AllRoads[x][i + 1].waypoint_nr14;
                        AllRoads[x][i + 1].waypoint_nr13.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                    //dół-> góra
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr1.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr10.nextWaypoint = AllRoads[x][i].waypoint_nr2;
                    }
                }
                if (AllRoads[x][i].tag == "circle" && AllRoads[x][i + 1].tag == "Road_1_line")
                {
                    //jezeli leci lewo -> prawo
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr12.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr2.nextWaypoint = AllRoads[x][i].waypoint_nr11;
                    }
                    //prawo_lewo
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr15.nextWaypoint = AllRoads[x][i + 1].waypoint_nr2;
                        AllRoads[x][i + 1].waypoint_nr1.nextWaypoint = AllRoads[x][i].waypoint_nr16;
                    }
                }
                
                if (AllRoads[x][i].tag == "circle" && AllRoads[x][i + 1].tag == "Road_1_line_90")
                {
                    //jezeli leci góra -> dół
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr10.nextWaypoint = AllRoads[x][i + 1].waypoint_nr2;
                        AllRoads[x][i + 1].waypoint_nr1.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                    //dół-> góra
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr13.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr2.nextWaypoint = AllRoads[x][i].waypoint_nr14;
                    }
                }
                ////////////////////////
                if (AllRoads[x][i].tag == "circle" && AllRoads[x][i + 1].tag == "Road_1_line_turn")
                {
                    //jezeli leci lewa -> prawo
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr12.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr11;
                    }
                    //dół-> góra
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr13.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr14;
                    }
                }
                ////////////////////////
                if (AllRoads[x][i].tag == "circle" && AllRoads[x][i + 1].tag == "Road_1_line_turn_90")
                {
                    //jezeli leci lewa -> prawo
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr12.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr11;
                    }
                    //góra-> dół
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr10.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                /////////////////////////////////////
                if (AllRoads[x][i].tag == "circle" && AllRoads[x][i + 1].tag == "Road_1_line_turn_180")
                {
                    //jezeli leci góra -> dół
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr10.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                    //prawo-> lewo
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr15.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr16;
                    }
                }
                /////////////////////////////////////
                if (AllRoads[x][i].tag == "circle" && AllRoads[x][i + 1].tag == "Road_1_line_turn_270")
                {
                    //jezeli leci dół -> góra
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr13.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr14;
                    }
                    //prawo-> lewo
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr15.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr16;
                    }
                }
                /////////////cross_road_90 i proste drogi//zaczynamy od prostych drog
                if(AllRoads[x][i].tag=="Road_1_line" && AllRoads[x][i+1].tag == "crossroad_90")
                {
                    //nie trzeba patrzec dwóch stron bo jest tylko jedna możlliwość
                    AllRoads[x][i].waypoint_nr1.nextWaypoint = AllRoads[x][i + 1].waypoint_nr10;
                    AllRoads[x][i + 1].waypoint_nr9.nextWaypoint = AllRoads[x][i].waypoint_nr2;
                }
                if (AllRoads[x][i].tag == "Road_1_line_90" && AllRoads[x][i+1].tag == "crossroad_90")
                {
                    Debug.Log("jestem");
                    //góra->dół
                    if(AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr2.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                    //dół->góra
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr1.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr2;
                    }
                 }
                /////////////cross_road_90 i proste drogi//zaczynamy od cross_road
                if (AllRoads[x][i].tag == "crossroad_90" && i!= AllRoads[x].Count-1)
                {
                    if (AllRoads[x][i + 1].tag == "Road_1_line")
                    {
                        AllRoads[x][i].waypoint_nr9.nextWaypoint = AllRoads[x][i + 1].waypoint_nr2;
                        AllRoads[x][i + 1].waypoint_nr1.nextWaypoint = AllRoads[x][i].waypoint_nr10;
                    }
                }
                
                if(AllRoads[x][i].tag == "crossroad_90" && i != AllRoads[x].Count - 1)
                {
                    Debug.Log("jestem");
                    //góra->dół
                    if (AllRoads[x][i + 1].tag == "Road_1_line_90")
                    {
                        if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                        {
                            AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr2;
                            AllRoads[x][i + 1].waypoint_nr1.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                        }
                        //dół->góra
                        if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                        {
                            AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr4;
                            AllRoads[x][i + 1].waypoint_nr2.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                        }
                    }
                }
                

            }
        }

    }


}
