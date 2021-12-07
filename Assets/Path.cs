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
                ///////// circle i zakrety zaczynajac od zakretów
                ///
                 if (AllRoads[x][i].tag == "Road_1_line_turn" && AllRoads[x][i + 1].tag == "circle")
                {
                    //jezeli leci prawo-> lewo
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr11;
                        AllRoads[x][i + 1].waypoint_nr12.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                    //góra-> dół
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr14;
                        AllRoads[x][i + 1].waypoint_nr13.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                ////////////////////////
                if (AllRoads[x][i].tag == "Road_1_line_turn_90" && AllRoads[x][i + 1].tag == "circle")
                {
                    //jezeli leci prawo -> lewo
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr11;
                        AllRoads[x][i + 1].waypoint_nr12.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                    //dół góra
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr10.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                }
                /////////////////////////////////////
                if (AllRoads[x][i].tag == "Road_1_line_turn_180" && AllRoads[x][i + 1].tag == "circle")
                {
                    //jezeli leci dół -> góra
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr10.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                    //lewo-> prawo
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr16;
                        AllRoads[x][i + 1].waypoint_nr15.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                /////////////////////////////////////
                if (AllRoads[x][i].tag == "Road_1_line_turn_270" && AllRoads[x][i + 1].tag == "circle")
                {
                    //jezeli leci góra -> dół
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr14;
                        AllRoads[x][i + 1].waypoint_nr13.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                    //lewo-> prawo
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr16;
                        AllRoads[x][i + 1].waypoint_nr15.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                }
                ///
                /////////////cross_road_90 i proste drogi//zaczynamy od prostych drog
                if (AllRoads[x][i].tag=="Road_1_line" && AllRoads[x][i+1].tag == "crossroad_90")
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
                /// cross_road_90 i skręty// zaczynamy od skrętów 
                if(AllRoads[x][i].tag=="Road_1_line_turn_270" && AllRoads[x][i+1].tag == "crossroad_90")
                {
                    //moze leciec od lewej lub od gory
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr10;
                        AllRoads[x][i + 1].waypoint_nr9.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line_turn_180" && AllRoads[x][i + 1].tag == "crossroad_90")
                {
                    //moze leciec od lewej lub od dolu
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr10;
                        AllRoads[x][i + 1].waypoint_nr9.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line_turn_90" && AllRoads[x][i + 1].tag == "crossroad_90")
                {
                    //moze tylko od dolu
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                  
                }
                if (AllRoads[x][i].tag == "Road_1_line_turn" && AllRoads[x][i + 1].tag == "crossroad_90")
                {
                    //moze tylko od gory
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }

                }
                //// crossroad_90 i skrety// zaczynamy od crossroad_90
                ///
                if (i != AllRoads[x].Count - 1 && AllRoads[x][i].tag == "crossroad_90" && AllRoads[x][i + 1].tag == "Road_1_line_turn_270")
                {
                    //moze leciec od prawej lub od dolu
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr9.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr10;
                    }
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                }
                if (i != AllRoads[x].Count - 1 && AllRoads[x][i].tag == "crossroad_90" && AllRoads[x][i + 1].tag == "Road_1_line_turn_180")
                {
                    //moze leciec od prawej lub od góry
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr9.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr10;
                    }
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                if (i != AllRoads[x].Count - 1 &&  AllRoads[x][i].tag == "crossroad_90" && AllRoads[x][i + 1].tag == "Road_1_line_turn_90")
                {
                    //moze tylko od góry
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }

                }
                if (i != AllRoads[x].Count - 1 &&  AllRoads[x][i].tag == "crossroad_90" && AllRoads[x][i + 1].tag == "Road_1_line_turn")
                {
                    //moze tylko od dołu
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }

                }
                /////crossroad i proste drogi->zaczynamy od prostych drog
                if (AllRoads[x][i].tag == "Road_1_line" && AllRoads[x][i + 1].tag == "crossroad")
                {
                    //prawo->lewo
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr1.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr2;
                    }
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr2.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line_90" && AllRoads[x][i + 1].tag == "crossroad")
                {
                    //jest tylko jedna mozliwosc
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr1.nextWaypoint = AllRoads[x][i + 1].waypoint_nr10;
                        AllRoads[x][i + 1].waypoint_nr9.nextWaypoint = AllRoads[x][i].waypoint_nr2;
                    }
                    
                }
                /// crossroad i proste drogi->zaczynamy od prostych drog ->zaczynamy od crossroad
                if (i != AllRoads[x].Count - 1 && AllRoads[x][i].tag == "crossroad" && AllRoads[x][i + 1].tag == "Road_1_line")
                {
                    //prawo->lewo
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr2.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr2;
                        AllRoads[x][i + 1].waypoint_nr1.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                }
                if (i != AllRoads[x].Count - 1 && AllRoads[x][i].tag == "crossroad" && AllRoads[x][i + 1].tag == "Road_1_line_90")
                {
                    //jest tylko jedna mozliwosc
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr9.nextWaypoint = AllRoads[x][i + 1].waypoint_nr2;
                        AllRoads[x][i + 1].waypoint_nr1.nextWaypoint = AllRoads[x][i].waypoint_nr10;
                    }

                }
                ///crossroad i skrety -> zaczynamy od skrętów
                if ( AllRoads[x][i].tag == "Road_1_line_turn" && AllRoads[x][i + 1].tag == "crossroad")
                {
                    //jest tylko jedna mozliwosc
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }

                }
                if (AllRoads[x][i].tag == "Road_1_line_turn_90" && AllRoads[x][i + 1].tag == "crossroad")
                {
                    //dół->góra
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr10;
                        AllRoads[x][i + 1].waypoint_nr9.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                    //prawo->lewo
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line_turn_180" && AllRoads[x][i + 1].tag == "crossroad")
                {
                    //dół->góra
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr10;
                        AllRoads[x][i + 1].waypoint_nr9.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                    //lewo->prawo
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line_turn_270" && AllRoads[x][i + 1].tag == "crossroad")
                {
                    //jest tylko jedna mozliwosc
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }

                }
                /////////crossroad i skrety -> zaczynamy od crossroad
                if (i != AllRoads[x].Count - 1 && AllRoads[x][i].tag == "crossroad" && AllRoads[x][i + 1].tag == "Road_1_line_turn")
                {
                    //jest tylko jedna mozliwosc
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }

                }
                if (i != AllRoads[x].Count - 1 && AllRoads[x][i].tag == "crossroad" && AllRoads[x][i + 1].tag == "Road_1_line_turn_90")
                {
                    //góra->dół
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr9.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr10;
                    }
                    //lewo->prawo
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                if (i != AllRoads[x].Count - 1 && AllRoads[x][i].tag == "crossroad" && AllRoads[x][i + 1].tag == "Road_1_line_turn_180")
                {
                    //góra->dół
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr9.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr10;
                    }
                    //prawo->lewo
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                }
                if (i != AllRoads[x].Count - 1 &&  AllRoads[x][i].tag == "crossroad" && AllRoads[x][i + 1].tag == "Road_1_line_turn_270")
                {
                    //jest tylko jedna mozliwosc
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }

                }
                /////crossroad_270 i proste drogi-> zacztnamy od dróg
                if (AllRoads[x][i].tag == "Road_1_line" && AllRoads[x][i + 1].tag == "crossroad_270")
                {
                      // tylko jedna mozliwosc 
                      if(AllRoads[x][i].y> AllRoads[x][i+1].y)
                    {
                        AllRoads[x][i].waypoint_nr2.nextWaypoint = AllRoads[x][i + 1].waypoint_nr10;
                        AllRoads[x][i + 1].waypoint_nr9.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line_90" && AllRoads[x][i + 1].tag == "crossroad_270")
                {
                    // góra dół 
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr2.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                    //  dół góra
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr1.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr2;
                    }
                }
                ///crossroad_270 i proste drogi-> zacztnamy od crossroad
                if (i != AllRoads[x].Count - 1 && AllRoads[x][i].tag == "crossroad_270" && AllRoads[x][i + 1].tag == "Road_1_line")
                {
                    // tylko jedna mozliwosc 
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr9.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr2.nextWaypoint = AllRoads[x][i].waypoint_nr10;
                    }
                }
                if (i != AllRoads[x].Count - 1 && AllRoads[x][i].tag == "crossroad_270" && AllRoads[x][i + 1].tag == "Road_1_line_90")
                {
                    // góra dół 
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr2;
                        AllRoads[x][i + 1].waypoint_nr1.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                    //  dół góra
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr2.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                ///crossroad_270 i skręty-> zacztnamy od skrętów
                if (AllRoads[x][i].tag == "Road_1_line_turn" && AllRoads[x][i + 1].tag == "crossroad_270")
                {
                    // z góry na dół
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                    //z prawej na lewo
                    if (AllRoads[x][i].y >AllRoads[x][i + 1].y)
                    {
                       AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr10;
                       AllRoads[x][i + 1].waypoint_nr9.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line_turn_90" && AllRoads[x][i + 1].tag == "crossroad_270")
                {
                    // z dołu na góra
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                       AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                      AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                    //z prawej na lewo
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr10;
                        AllRoads[x][i + 1].waypoint_nr9.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line_turn_180" && AllRoads[x][i + 1].tag == "crossroad_270")
                {
                    // z dołu na góra
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }

                }
                if (AllRoads[x][i].tag == "Road_1_line_turn_270" && AllRoads[x][i + 1].tag == "crossroad_270")
                {
                    // z góry na dół
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }

                }
                ///crossroad_270 i skręty-> zacztnamy od crossroad_270
                if (i != AllRoads[x].Count - 1 && AllRoads[x][i].tag == "crossroad_270" && AllRoads[x][i + 1].tag == "Road_1_line_turn")
                {
                    // z dołu na górę
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                    //z lewej na prawo
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr9.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr10;
                    }
                }
                if (i != AllRoads[x].Count - 1 && AllRoads[x][i].tag == "crossroad_270" && AllRoads[x][i + 1].tag == "Road_1_line_turn_90")
                {
                    // z góry na dół
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                    //z lewej na prawo
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr9.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr10;
                    }
                }
                if (i != AllRoads[x].Count - 1 && AllRoads[x][i].tag == "crossroad_270" && AllRoads[x][i + 1].tag == "Road_1_line_turn_180")
                {
                    // z góry na dół
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }

                }
                if (i != AllRoads[x].Count - 1 && AllRoads[x][i].tag == "crossroad_270" && AllRoads[x][i + 1].tag == "Road_1_line_turn_270")
                {
                    // z dołu na górę
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }

                }
                ////crossroad_180 i proste drogi -> zaczniemy od prostych dróg
                if (AllRoads[x][i].tag == "Road_1_line" && AllRoads[x][i + 1].tag == "crossroad_180")
                {
                    //prawo->lewo
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr1.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr2;
                    }
                    //lewej do prawej
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr2.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line_90" && AllRoads[x][i + 1].tag == "crossroad_180")
                {
                    //jest tylko jedna mozliwosc
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr2.nextWaypoint = AllRoads[x][i + 1].waypoint_nr10;
                        AllRoads[x][i + 1].waypoint_nr9.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }

                }
                ////crossroad_180 i proste drogi -> zaczniemy od crossroad_180
                if (i != AllRoads[x].Count - 1 &&AllRoads[x][i].tag == "crossroad_180" && AllRoads[x][i + 1].tag == "Road_1_line")
                {
                    //prawo->lewo
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr2.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                    //lewej do prawej
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr2;
                        AllRoads[x][i + 1].waypoint_nr1.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                if (i != AllRoads[x].Count - 1 && AllRoads[x][i].tag == "crossroad_180" && AllRoads[x][i + 1].tag == "Road_1_line_90")
                {
                    //jest tylko jedna mozliwosc
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr9.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr2.nextWaypoint = AllRoads[x][i].waypoint_nr10;
                    }

                }
                ///crossroad_180 i skręty -> zaczynamy od skrętów
                if (AllRoads[x][i].tag == "Road_1_line_turn" && AllRoads[x][i + 1].tag == "crossroad_180")
                {
                    // z góry na dół
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr10;
                        AllRoads[x][i + 1].waypoint_nr9.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                    //z prawej na lewo
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line_turn_90" && AllRoads[x][i + 1].tag == "crossroad_180")
                {
                
                    //z prawej na lewo
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line_turn_180" && AllRoads[x][i + 1].tag == "crossroad_180")
                {
                    // z lewej do prawej
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }

                }
                if (AllRoads[x][i].tag == "Road_1_line_turn_270" && AllRoads[x][i + 1].tag == "crossroad_180")
                {
                    // z góry na dół
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr10;
                        AllRoads[x][i + 1].waypoint_nr9.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                    // z lewej do prawej
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }

                }
                ///crossroad_180 i skrety-> zaczynamy od crossroad
                if (i != AllRoads[x].Count - 1 && AllRoads[x][i].tag == "crossroad_180" && AllRoads[x][i + 1].tag == "Road_1_line_turn")
                {
                    // z dołu na góry
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr9.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr10;
                    }
                    //z lewj na prawej
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                }
                if (i != AllRoads[x].Count - 1 && AllRoads[x][i].tag == "crossroad_180" && AllRoads[x][i + 1].tag == "Road_1_line_turn_90")
                {

                    //z lewej na prawo
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                }
                if (i != AllRoads[x].Count - 1 && AllRoads[x][i].tag == "crossroad_180" && AllRoads[x][i + 1].tag == "Road_1_line_turn_180")
                {
                    // z prawej do lewej
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }

                }
                if (i != AllRoads[x].Count - 1 && AllRoads[x][i].tag == "crossroad_180" && AllRoads[x][i + 1].tag == "Road_1_line_turn_270")
                {
                    // z dołu na górę
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr9.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr8.nextWaypoint = AllRoads[x][i].waypoint_nr10;
                    }
                    // z prawej do lewej
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr5;
                        AllRoads[x][i + 1].waypoint_nr4.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }

                }
                //cross
                if (AllRoads[x][i].tag == "Road_1_line" && AllRoads[x][i + 1].tag == "cross")
                {
                    //jezeli leci lewo -> prawo
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr1.nextWaypoint = AllRoads[x][i + 1].waypoint_nr16;
                        AllRoads[x][i + 1].waypoint_nr15.nextWaypoint = AllRoads[x][i].waypoint_nr2;
                    }
                    //prawo_lewo
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr2.nextWaypoint = AllRoads[x][i + 1].waypoint_nr11;
                        AllRoads[x][i + 1].waypoint_nr12.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                if (AllRoads[x][i].tag == "Road_1_line_90" && AllRoads[x][i + 1].tag == "cross")
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
                if (AllRoads[x][i].tag == "cross" && AllRoads[x][i + 1].tag == "Road_1_line")
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

                if (AllRoads[x][i].tag == "cross" && AllRoads[x][i + 1].tag == "Road_1_line_90")
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
                if (AllRoads[x][i].tag == "cross" && AllRoads[x][i + 1].tag == "Road_1_line_turn")
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
                if (AllRoads[x][i].tag == "cross" && AllRoads[x][i + 1].tag == "Road_1_line_turn_90")
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
                if (AllRoads[x][i].tag == "cross" && AllRoads[x][i + 1].tag == "Road_1_line_turn_180")
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
                if (AllRoads[x][i].tag == "cross" && AllRoads[x][i + 1].tag == "Road_1_line_turn_270")
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
                ///////// circle i zakrety zaczynajac od zakretów
                ///
                if (AllRoads[x][i].tag == "Road_1_line_turn" && AllRoads[x][i + 1].tag == "cross")
                {
                    //jezeli leci prawo-> lewo
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr11;
                        AllRoads[x][i + 1].waypoint_nr12.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                    //góra-> dół
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr14;
                        AllRoads[x][i + 1].waypoint_nr13.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                ////////////////////////
                if (AllRoads[x][i].tag == "Road_1_line_turn_90" && AllRoads[x][i + 1].tag == "cross")
                {
                    //jezeli leci prawo -> lewo
                    if (AllRoads[x][i].y > AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr11;
                        AllRoads[x][i + 1].waypoint_nr12.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                    //dół góra
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr10.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                }
                /////////////////////////////////////
                if (AllRoads[x][i].tag == "Road_1_line_turn_180" && AllRoads[x][i + 1].tag == "cross")
                {
                    //jezeli leci dół -> góra
                    if (AllRoads[x][i].x > AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr1;
                        AllRoads[x][i + 1].waypoint_nr10.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                    //lewo-> prawo
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr16;
                        AllRoads[x][i + 1].waypoint_nr15.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                }
                /////////////////////////////////////
                if (AllRoads[x][i].tag == "Road_1_line_turn_270" && AllRoads[x][i + 1].tag == "cross")
                {
                    //jezeli leci góra -> dół
                    if (AllRoads[x][i].x < AllRoads[x][i + 1].x)
                    {
                        AllRoads[x][i].waypoint_nr8.nextWaypoint = AllRoads[x][i + 1].waypoint_nr14;
                        AllRoads[x][i + 1].waypoint_nr13.nextWaypoint = AllRoads[x][i].waypoint_nr1;
                    }
                    //lewo-> prawo
                    if (AllRoads[x][i].y < AllRoads[x][i + 1].y)
                    {
                        AllRoads[x][i].waypoint_nr4.nextWaypoint = AllRoads[x][i + 1].waypoint_nr16;
                        AllRoads[x][i + 1].waypoint_nr15.nextWaypoint = AllRoads[x][i].waypoint_nr5;
                    }
                }
            }
        }

    }


}
