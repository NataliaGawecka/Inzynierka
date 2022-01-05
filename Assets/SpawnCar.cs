using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnCar : MonoBehaviour
{
    public Path path;
   public CarAI car;
    // public GameObject car;
    // Start is called before the first frame update
    public List<int> PickedRoads;
    void Start()
    {

        StartCoroutine(SpawnOneCarOnEachRoade());
    }

     IEnumerator  SpawnOneCarOnEachRoade()
    {
        yield return new WaitForSeconds(1);     
          
            for (int i = 0; i < path.AllRoads[0].Count/2; i++)
            {
                Roads_waypoint r = PickRoad(0);
                car.currentWaypoint = r.waypoint_nr1;
                Debug.Log("drogi:" + r);
                if (r.tag == "Road_1_line")
                {
                    Instantiate(car, new Vector3(r.waypoint_nr1.transform.position.x, r.waypoint_nr1.transform.position.y + 0.5f, r.waypoint_nr1.transform.position.z), car.transform.rotation);
                }
                else if (r.tag == "Road_1_line_90")
                {
                    Instantiate(car, r.waypoint_nr1.transform.position, Quaternion.AngleAxis(90, Vector3.down));
                }
            }
        
    }

    public Roads_waypoint PickRoad(int x)
    {
  
        int i = Random.Range(0, path.AllRoads[x].Count);
        if (path.AllRoads[x][i].tag == "Road_1_line" || path.AllRoads[x][i].tag == "Road_1_line_90")
        {
            if (!PickedRoads.Contains(i))
            {
                PickedRoads.Add(i);
                return path.AllRoads[x][i];
              
            }
            else
            {
                return PickRoad(x);
            }
        }
        
        return PickRoad(x);
       
     

    }


  

}
