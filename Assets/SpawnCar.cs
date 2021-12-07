using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnCar : MonoBehaviour
{
    public Path path;
   public CarEngine car;
   // public GameObject car;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SpawnOneCarOnEachRode());
    }

     IEnumerator  SpawnOneCarOnEachRode()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("list:" + path.AllRoads.Count);
      
            for (int i = 0; i < 10; i++)
            {
                Roads_waypoint r = PickRoad(0);
                car.currentNode = r.waypoint_nr1;
                Debug.Log("drogi:" + r);
                if (r.tag == "Road_1_line")
                {
                    Instantiate(car, new Vector3(r.waypoint_nr1.transform.position.x, r.waypoint_nr1.transform.position.y + 0.5f, r.waypoint_nr1.transform.position.z), car.transform.rotation);
                }
                else if (r.tag == "Road_1_line_90") { 
                        Instantiate(car, r.waypoint_nr1.transform.position, Quaternion.AngleAxis(90, Vector3.down));
                }
            }
        
     
    }

    public Roads_waypoint PickRoad(int x)
    {
  
        int i = Random.Range(0, path.AllRoads[x].Count);
        if (path.AllRoads[x][i].tag == "Road_1_line" || path.AllRoads[x][i].tag == "Road_1_line_90")
        {
            return path.AllRoads[x][i];
        }
        
        return PickRoad(x);
       
     

    }


  

}
