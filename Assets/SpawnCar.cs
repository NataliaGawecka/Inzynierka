using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnCar : MonoBehaviour
{
    public Path path;
    public GameObject car;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SpawnOneCarOnEachRode());
    }

     IEnumerator  SpawnOneCarOnEachRode()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("list:" + path.AllRoads.Count);
        for (int x=0; x < path.AllRoads.Count; x++)
        {
            Roads_waypoint r=PickRoad( x);
            Debug.Log("drogi:" + r);
            Instantiate(car, r.waypoint_nr1.transform.position, car.transform.rotation);
        }
     
    }

    public Roads_waypoint PickRoad(int x)
    {
        int i = Random.Range(0, path.AllRoads[x].Count);
       
            return path.AllRoads[x][i];
       

    }


  

}
