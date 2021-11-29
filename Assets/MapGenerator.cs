using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MapGenerator : MonoBehaviour
{
    public Roads_waypoint[] simple_road;
    public Roads_waypoint[] intersection;
    public int mapWidth = 20;
    public int mapHeight = 20;
    public float distance = 2.0f;
    public int[,] MapMatrix;
    public int number_of_intersections = 0;
    public  List<Roads_waypoint> roads_list;
    public List<Roads_waypoint> roads_list_2;
    public Path path;
    public int id_1= -1;
    public int id_2 = -1;

    public int seed = 23;

    enum directions
    {
        
        up,
        down,
        right,
        left
    }

    void Start()
    {
        roads_list = new List<Roads_waypoint>();

        Random.InitState(seed);

        MapMatrix = new int[20, 20];
        FillMatrixWithEmptySquares();
        PrintMatrixAsLog(MapMatrix);

        int x = Random.Range(0, 20);
        int y = Random.Range(0, 20);
        Vector3 pos = new Vector3(x * distance, 0.2f, y * distance);
        Roads_waypoint road = simple_road[Random.Range(1, 2)];
        directions dir;
        dir = FillWithRoads(road, pos, x, y);
        Debug.Log(dir);
        Debug.Log("po funkcji fill with roads_list");
        if (dir == directions.right)
        {
            FindForFirstPieceConnection(road, new Vector3(x * distance, 0.2f, (y - 1) * distance), x, y - 1, directions.left);
        }
        if (dir == directions.left)
        {
            FindForFirstPieceConnection(road, new Vector3(x * distance, 0.2f, (y - 1) * distance), x, y + 1, directions.right);
        }

      
        path.AllRoads.Add(roads_list);
        path.AllRoads.Add(roads_list_2);
        path.WaypointConnect();
    }

    private void PrintMatrixAsLog(int[,] mapMatrix)
    {
        string arrayString = "";
        for (int i = 0; i < mapMatrix.GetLength(0); i++)
        {
            for (int k = 0; k < mapMatrix.GetLength(1); k++)
            {
                arrayString += string.Format("{0} ", mapMatrix[i, k]);
            }
            arrayString += System.Environment.NewLine + System.Environment.NewLine;
        }
        Debug.Log(arrayString);
    }

    private void FillMatrixWithEmptySquares()
    {
        for (int h = 0; h < mapHeight; h++)
        {
            for (int w = 0; w < mapWidth; w++)
            {
                MapMatrix[w, h] = 0;
                Vector3 position = new Vector3(w * distance, 0, h * distance);
                Instantiate(simple_road[0], position, Quaternion.identity);
            }
        }
    }


   directions FillWithRoads(Roads_waypoint road, Vector3 position,int x, int y)
    {
        directions dir=directions.right;
     /*   if (x == 0) return;
        if (y == 0) return;
        if(x==19)
        {
          
            return;
        }
        if (y == 19 && road == simple_road[1]) return;
        if(x==19 && y==19)
        {
            return;
        }*/
        if (road == simple_road[1])
        {
            MapMatrix[x, y] = 1;
            Roads_waypoint r=Instantiate(road, position, road.transform.rotation) as Roads_waypoint;
            r.x = x;
            r.y = y;
            id_1++;
            r.id = id_1;
            id_2++;
            roads_list.Add(r);
            roads_list_2.Add(r);
            dir = (directions)Random.Range(2, 3);
            if (dir == directions.right)
            {

                  FillWithRoads(road, new Vector3(x * distance, 0.2f, (y + 1) * distance), x, y+1,dir);
                //display MapMatrix
                // FillWithRoads(road, new Vector3(x * distance, 0.2f, (y + 1) * distance), x, y + 1);
                PrintMatrixAsLog(MapMatrix);
                return dir;
            }
            if (dir == directions.left)
            {

                 FillWithRoads(road, new Vector3(x * distance, 0.2f, (y -1) * distance), x, y-1,dir);
                //display MapMatrix
                PrintMatrixAsLog(MapMatrix);
                return dir;
            }



         

        }
        if (road == simple_road[2])
        {
            dir = (directions)Random.Range(0, 1);
            MapMatrix[x, y] = 2;

            Roads_waypoint r=Instantiate(road, position, road.transform.rotation);
            r.x = x;
            r.y = y;
            id_1++;
            r.id = id_1;
            roads_list.Add(r);
            return dir;
        }
        return dir;
    }
 
    void FillWithRoads(Roads_waypoint road, Vector3 position, int x, int y, directions condition)
    {
        
            directions dir;
        Debug.Log(number_of_intersections);

        if (number_of_intersections == 5)
        {
            Debug.Log("end");
            return;
        }
        ///przy granicy
        //prawa 
       else if (y == 19 && x<19 && x>0 && road == simple_road[1] )
            {
            if (checkSimpleRoad(x, y,roads_list) == false)
            {
                Roads_waypoint road_2 = simple_road[Random.Range(3, 4)];
                if (road_2 == simple_road[3])
                {
                    MapMatrix[x, y] = 3;
                    CreateRoad(position, x, y, road_2, roads_list);
                    Roads_waypoint road_3 = simple_road[2];
                    dir = directions.down;
                    FillWithRoads(road_3, new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, dir);

                }
                if (road_2 == simple_road[4])
                {
                    MapMatrix[x, y] = 4;
                    CreateRoad(position, x, y, road_2, roads_list);
                    Roads_waypoint road_3 = simple_road[2];
                    dir = directions.up;
                    FillWithRoads(road_3, new Vector3((x - 1) * distance, 0.2f, y * distance), x - 1, y, dir);

                }
            }
            else if (checkSimpleRoad(x, y, roads_list) == true)
            {
                return;
            }
        }
        //lewa
        else if (y == 0 && x < 19 && x > 0 && road == simple_road[1] )
        {
            if (checkSimpleRoad(x, y, roads_list) == false)
            {
                Roads_waypoint road_2 = simple_road[Random.Range(5, 6)];

                if (road_2 == simple_road[6])
                {
                    MapMatrix[x, y] = 6;
                    CreateRoad(position, x, y, road_2, roads_list);
                    Roads_waypoint road_3 = simple_road[2];
                    dir = directions.down;
                    FillWithRoads(road_3, new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, dir);

                }
                if (road_2 == simple_road[5])
                {
                    MapMatrix[x, y] = 5;
                    CreateRoad(position, x, y, road_2, roads_list);
                    Roads_waypoint road_3 = simple_road[2];
                    dir = directions.up;
                    FillWithRoads(road_3, new Vector3((x - 1) * distance, 0.2f, y * distance), x - 1, y, dir);

                }
            }
            else if(checkSimpleRoad(x, y, roads_list) == true)
            {
                return;
            }
        }
        //dolna
       else  if (x == 19 && y < 19 && y > 0 && road == simple_road[2] )
        {
            if (checkSimpleRoad(x, y, roads_list) == false)
            {
                Roads_waypoint road_2 = simple_road[Random.Range(4, 5)];
                if (road_2 == simple_road[4])
                {
                    MapMatrix[x, y] = 4;
                    CreateRoad(position, x, y, road_2, roads_list);
                    Roads_waypoint road_3 = simple_road[1];
                    dir = directions.left;
                    FillWithRoads(road_3, new Vector3((x) * distance, 0.2f, (y - 1) * distance), x, y - 1, dir);

                }
                if (road_2 == simple_road[5])
                {
                    MapMatrix[x, y] = 5;
                    CreateRoad(position, x, y, road_2, roads_list);
                    Roads_waypoint road_3 = simple_road[1];
                    dir = directions.right;
                    FillWithRoads(road_3, new Vector3(x * distance, 0.2f, y + 1 * distance), x, y + 1, dir);

                }
            }
            else if (checkSimpleRoad(x, y, roads_list) == true)
            {
                return;
            }
        }
        //górna
         else if (x == 0 && y < 19 && y > 0 && road == simple_road[2] )
        {
            if (checkSimpleRoad(x, y, roads_list) == false)
            {
                int rand = Random.Range(1, 2);

                if (rand == 1)
                {
                    Roads_waypoint road_2 = simple_road[3];
                    MapMatrix[x, y] = 3;
                    CreateRoad(position, x, y, road_2, roads_list);
                    Roads_waypoint road_3 = simple_road[1];
                    dir = directions.left;
                    FillWithRoads(road_3, new Vector3((x) * distance, 0.2f, (y - 1) * distance), x, y - 1, dir);

                }
                if (rand == 2)
                {
                    Roads_waypoint road_2 = simple_road[6];
                    MapMatrix[x, y] = 6;
                    CreateRoad(position, x, y, road_2, roads_list);
                    Roads_waypoint road_3 = simple_road[1];
                    dir = directions.right;
                    FillWithRoads(road_3, new Vector3(x * distance, 0.2f, y + 1 * distance), x, y + 1, dir);

                }
            }
            else if (checkSimpleRoad(x, y, roads_list) == true)
            {
                return;
            }
        }

        //
        else if (y==19 && x == 19 && road == simple_road[2])
        {
            MapMatrix[x, y] = 4;
            Roads_waypoint road_2=simple_road[4];
            CreateRoad(position, x, y, road_2, roads_list);
            Roads_waypoint road_3 = simple_road[1];
            dir = directions.left;
            FillWithRoads(road_3, new Vector3((x) * distance, 0.2f, (y-1) * distance), x, y-1, dir);
           

        }
        else if (y == 19 && x == 19 && road == simple_road[1] )
        {
            MapMatrix[x, y] = 4;
            Roads_waypoint road_2 = simple_road[4];
            CreateRoad(position, x, y, road_2, roads_list);
            Roads_waypoint road_3 = simple_road[2];
            dir = directions.up;
            FillWithRoads(road_3, new Vector3((x-1) * distance, 0.2f, (y) * distance), x-1, y, dir);


        }
      //      if (x == 19 && road!=simple_road[1]) return;
          else  if(x==19 && y==0 && road == simple_road[1] )
        {
            MapMatrix[x, y] = 5;
            Roads_waypoint road_2 = simple_road[5];
            CreateRoad(position, x, y, road_2, roads_list);
            Roads_waypoint road_3 = simple_road[2];
            dir = directions.up;
            FillWithRoads(road_3, new Vector3((x-1) * distance, 0.2f, y * distance), x-1, y, dir);

        }
            //nowe
        else if (x == 19 && y == 0 && road == simple_road[2] )
        {
            MapMatrix[x, y] = 5;
            Roads_waypoint road_2 = simple_road[5];
            CreateRoad(position, x, y, road_2, roads_list);
            Roads_waypoint road_3 = simple_road[1];
            dir = directions.right;
            FillWithRoads(road_3, new Vector3((x) * distance, 0.2f, (y+1) * distance), x, y+1, dir);
        }

         //   if (y == 0 && road!=simple_road[2]) return;
       else   if(y==0 && x==0 && road==simple_road[2])
           {
               MapMatrix[x, y] = 6;
               Roads_waypoint road_2 = simple_road[6];
            CreateRoad(position, x, y, road_2, roads_list);
            Roads_waypoint road_3 = simple_road[1];
               dir = directions.right;
               FillWithRoads(road_3, new Vector3(x * distance, 0.2f, (y +1)* distance), x, y+1, dir);
            

             
           }

       else  if (y == 0 && x == 0 && road == simple_road[1])
        {
            MapMatrix[x, y] = 6;
            Roads_waypoint road_2 = simple_road[6];
            CreateRoad(position, x, y, road_2, roads_list);
            Roads_waypoint road_3 = simple_road[2];
            dir = directions.down;
        
                FillWithRoads(road_3, new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, dir);
            
            


        }
        else if (y == 19 && x == 0 && road == simple_road[1] )
        {
            Debug.Log("halo");
            MapMatrix[x, y] = 3;
            Roads_waypoint road_2 = simple_road[3];
            CreateRoad(position, x, y, road_2, roads_list);
            if (checkSimpleRoad(x + 1, y, roads_list) == false)
            {
                Roads_waypoint road_3 = simple_road[2];
                dir = directions.down;
                FillWithRoads(road_3, new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, dir);
               
            }
            else if (checkSimpleRoad(x + 1, y, roads_list) == true)
            {
                Debug.Log("?");
                return;
               
            }
        }
        //nowe

      else   if (y == 19 && x == 0 && road == simple_road[2] )
        {
            Debug.Log("halo");
            MapMatrix[x, y] = 3;
            Roads_waypoint road_2 = simple_road[3];
            CreateRoad(position, x, y, road_2, roads_list);
            Roads_waypoint road_3 = simple_road[1];
            dir = directions.left;
            FillWithRoads(road_3, new Vector3((x) * distance, 0.2f, (y-1)* distance), x, y-1, dir);
            
        }

        ///

       else  if (road == simple_road[1] && condition == directions.right  && y!=19 )
        {
            if (CheckIfThereIsTurnRoad(road, x, y, roads_list) == true ){
                return;
            }
              else  if (checkSimpleRoad(x, y, roads_list) == false)
                {
                    int z = Random.Range(0, 100);
                    if (z < 50)
                    {
                        MapMatrix[x, y] = 1;
                    CreateRoad(position, x, y, road, roads_list);
                    FillWithRoads(road, new Vector3(x * distance, 0.2f, (y + 1) * distance), x, y + 1, condition);
                    }
                    //else  if (MapMatrix[x, y - 1] != 6 && MapMatrix[x, y - 1] != 5 && MapMatrix[x, y - 1] != 4 && MapMatrix[x, y - 1] != 3 && z > 50 && z < 75 && x != 19)
                    else if (MapMatrix[x, y - 1] != 6 && MapMatrix[x, y - 1] != 5 && MapMatrix[x, y - 1] != 4 && MapMatrix[x, y - 1] != 3 && z > 50 && z < 75 && x != 19 && MapMatrix[x, y + 1] != 2)
                    {
                    //tutaj sprawdzamy czy przed nami nie znajduje się skrzyżowanie w ta samą stronę, jeśli tak musimy dać w odwrotną stornę 
                    if (MapMatrix[x, y + 1] != 6)
                    {
                        MapMatrix[x, y] = 3;
                        Roads_waypoint road_2 = simple_road[3];
                        CreateRoad(position, x, y, road_2, roads_list);
                        FillWithRoads(simple_road[2], new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, directions.down);
                    }
                    else if (MapMatrix[x, y + 1] == 6 && x != 0)
                    {
                        MapMatrix[x, y] = 4;
                        Roads_waypoint road_2 = simple_road[4];
                        CreateRoad(position, x, y, road_2, roads_list);
                        FillWithRoads(simple_road[2], new Vector3((x - 1) * distance, 0.2f, y * distance), x - 1, y, directions.up);
                    }
                    else
                    {
                        MapMatrix[x, y] = 1;
                        CreateRoad(position, x, y, road, roads_list);
                        FillWithRoads(road, new Vector3(x * distance, 0.2f, (y + 1) * distance), x, y + 1, condition);
                    }

                }
                // else if (MapMatrix[x, y - 1] != 6 && MapMatrix[x, y - 1] != 5 && MapMatrix[x, y - 1] != 4 && MapMatrix[x, y - 1] != 3 && z > 75 && z <= 100 && x != 0)
                else if (MapMatrix[x, y - 1] != 6 && MapMatrix[x, y - 1] != 5 && MapMatrix[x, y - 1] != 4 && MapMatrix[x, y - 1] != 3 && z > 75 && z <= 100 && x != 0 && MapMatrix[x, y + 1] != 2)
                    {
                        if (MapMatrix[x, y + 1] != 5)
                        {
                            MapMatrix[x, y] = 4;
                            Roads_waypoint road_2 = simple_road[4];
                        CreateRoad(position, x, y, road_2, roads_list);
                        FillWithRoads(simple_road[2], new Vector3((x - 1) * distance, 0.2f, y * distance), x - 1, y, directions.up);
                        }
                        else if (MapMatrix[x, y + 1] == 5 && x!=19)
                        {
                            MapMatrix[x, y] = 3;
                            Roads_waypoint road_2 = simple_road[3];
                             CreateRoad(position, x, y, road_2, roads_list);
                           FillWithRoads(simple_road[2], new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, directions.down);
                        }
                       else
                        {
                           MapMatrix[x, y] = 1;
                        CreateRoad(position, x, y, road, roads_list);
                        FillWithRoads(road, new Vector3(x * distance, 0.2f, (y + 1) * distance), x, y + 1, condition);
                       }
                    }
                    else
                    {
                        MapMatrix[x, y] = 1;
                    CreateRoad(position, x, y, road, roads_list);
                    FillWithRoads(road, new Vector3(x * distance, 0.2f, (y + 1) * distance), x, y + 1, condition);
                    }
               
            }
            else 
            {
                Debug.Log("ho");
                number_of_intersections ++;
                FillWithRoads(road, new Vector3(x * distance, 0.2f, (y + 1) * distance), x, y + 1, condition);
                
            }
                
        }
            
         else   if (road == simple_road[1] && condition == directions.left && y!=0 )
            {

            // Debug.Log("halo");
            if (CheckIfThereIsTurnRoad(road, x, y, roads_list) == true)
            {
                return;
            }
            if (checkSimpleRoad(x, y, roads_list) == false)
            {

                int z = Random.Range(0, 100);
                if (z < 50)
                {
                    MapMatrix[x, y] = 1;
                    CreateRoad(position, x, y, road, roads_list);
                    FillWithRoads(road, new Vector3(x * distance, 0.2f, (y - 1) * distance), x, y - 1, condition);
                }
                //jezeli idziemy w lewo musimy sprawdzic czy za nami nie ma znowu skrzyzowanie w tym przypadku za nami bedzie to y+1
                //else if (MapMatrix[x, y + 1] != 6 && MapMatrix[x, y + 1] != 5 && MapMatrix[x, y + 1] != 4 && MapMatrix[x, y + 1] != 3 && z > 50 && z < 75 && x != 19)
                else if (MapMatrix[x, y + 1] != 6 && MapMatrix[x, y + 1] != 5 && MapMatrix[x, y + 1] != 4 && MapMatrix[x, y + 1] != 3 && z > 50 && z < 75 && x != 19 && MapMatrix[x, y - 1] != 2)
                {
                    if (MapMatrix[x, y - 1] != 3)
                    {
                        MapMatrix[x, y] = 6;
                        Roads_waypoint road_2 = simple_road[6];
                        CreateRoad(position, x, y, road_2, roads_list);
                        FillWithRoads(simple_road[2], new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, directions.down);
                    }
                    else if(MapMatrix[x, y - 1] == 3 && x!=0)
                    {

                        MapMatrix[x, y] = 5;
                        Roads_waypoint road_2 = simple_road[5];
                        CreateRoad(position, x, y, road_2, roads_list);
                        FillWithRoads(simple_road[2], new Vector3((x - 1) * distance, 0.2f, y * distance), x - 1, y, directions.up);
                    }
                    else
                    {
                        MapMatrix[x, y] = 1;
                        CreateRoad(position, x, y, road, roads_list);
                        FillWithRoads(road, new Vector3(x * distance, 0.2f, (y - 1) * distance), x, y - 1, condition);
                    }
                   
                  
                }
                //else  if (MapMatrix[x, y + 1] != 6 && MapMatrix[x, y + 1] != 5 && MapMatrix[x, y + 1] != 4 && MapMatrix[x, y + 1] != 3 && z > 75 && z <= 100 && x != 0)
                else if (MapMatrix[x, y + 1] != 6 && MapMatrix[x, y + 1] != 5 && MapMatrix[x, y + 1] != 4 && MapMatrix[x, y + 1] != 3 && z > 75 && z <= 100 && x != 0 && MapMatrix[x, y - 1] != 2)
                {


                    if (MapMatrix[x, y - 1] != 4)
                    {
                        MapMatrix[x, y] = 5;
                        Roads_waypoint road_2 = simple_road[5];
                        CreateRoad(position, x, y, road_2, roads_list);
                        FillWithRoads(simple_road[2], new Vector3((x - 1) * distance, 0.2f, y * distance), x - 1, y, directions.up);
                    }
                    else if (MapMatrix[x, y - 1] == 4 && x!=19)
                    {
                        MapMatrix[x, y] = 6;
                        Roads_waypoint road_2 = simple_road[6];
                        CreateRoad(position, x, y, road_2, roads_list);
                        FillWithRoads(simple_road[2], new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, directions.down);
                    }
                    else
                    {
                        MapMatrix[x, y] = 1;
                        CreateRoad(position, x, y, road, roads_list);
                        FillWithRoads(road, new Vector3(x * distance, 0.2f, (y - 1) * distance), x, y - 1, condition);
                    }

                }
                else
                {
                    MapMatrix[x, y] = 1;
                    CreateRoad(position, x, y, road, roads_list);
                    FillWithRoads(road, new Vector3(x * distance, 0.2f, (y - 1) * distance), x, y - 1, condition);
                }
            }
            else
            {
                Debug.Log("ho");
                number_of_intersections ++;
                FillWithRoads(road, new Vector3(x * distance, 0.2f, (y - 1) * distance), x, y - 1, condition);
            }

        }
        //tutaj tez nie wiem, warunek z x może być nie tak potem
        else if (road == simple_road[2] && condition == directions.up && x != 0 )
        {
            if (CheckIfThereIsTurnRoad(road, x, y, roads_list) == true)
            {
                return;
            }

            if (checkSimpleRoad(x, y, roads_list) == false)
            {
                int z = Random.Range(0, 100);
                if (z < 50)
                {
                    MapMatrix[x, y] = 2;

                    CreateRoad(position, x, y, road, roads_list);
                    FillWithRoads(road, new Vector3((x - 1) * distance, 0.2f, y * distance), x - 1, y, condition);
                }
                //else if (MapMatrix[x + 1, y] != 6 && MapMatrix[x + 1, y] != 5 && MapMatrix[x + 1, y] != 4 && MapMatrix[x + 1, y] != 3 && z > 50 && z < 75 && y != 19)
                else if (MapMatrix[x + 1, y] != 6 && MapMatrix[x + 1, y] != 5 && MapMatrix[x + 1, y] != 4 && MapMatrix[x + 1, y] != 3 && z > 50 && z < 75 && y != 19 && MapMatrix[x - 1, y] != 1)
                {

                    if (MapMatrix[x - 1, y] != 5)
                    {
                        MapMatrix[x, y] = 6;
                        Roads_waypoint road_2 = simple_road[6];
                        CreateRoad(position, x, y, road_2, roads_list);
                        FillWithRoads(simple_road[1], new Vector3((x) * distance, 0.2f, (y + 1) * distance), x, y + 1, directions.right);
                    }
                    //tutaj musi być y!=0 żeby nie skręcało w lewo w lewym rogu mapy 
                    else if (MapMatrix[x - 1, y] == 5 && y!=0)
                    {
                        MapMatrix[x, y] = 3;
                        Roads_waypoint road_2 = simple_road[3];
                        CreateRoad(position, x, y, road_2, roads_list);
                        FillWithRoads(simple_road[1], new Vector3((x) * distance, 0.2f, (y - 1) * distance), x, y - 1, directions.left);

                    }
                    else
                    {
                        MapMatrix[x, y] = 2;

                        CreateRoad(position, x, y, road, roads_list);
                        FillWithRoads(road, new Vector3((x - 1) * distance, 0.2f, y * distance), x - 1, y, condition);
                    }



                }
                //else if (MapMatrix[x + 1, y] != 6 && MapMatrix[x + 1, y] != 5 && MapMatrix[x + 1, y] != 4 && MapMatrix[x + 1, y] != 3 && z > 75 && z <=100 && y != 0)
                else if (MapMatrix[x + 1, y] != 6 && MapMatrix[x + 1, y] != 5 && MapMatrix[x + 1, y] != 4 && MapMatrix[x + 1, y] != 3 && z > 75 && z <= 100 && y != 0 && MapMatrix[x - 1, y] != 1)
                {

                    if (MapMatrix[x - 1, y] != 4)
                    {
                        MapMatrix[x, y] = 3;
                        Roads_waypoint road_2 = simple_road[3];
                        CreateRoad(position, x, y, road_2, roads_list);
                        FillWithRoads(simple_road[1], new Vector3((x) * distance, 0.2f, (y - 1) * distance), x, y - 1, directions.left);
                    }
                    else if (MapMatrix[x - 1, y] == 4 && y!=19)
                    {
                        MapMatrix[x, y] = 6;
                        Roads_waypoint road_2 = simple_road[6];
                        CreateRoad(position, x, y, road_2, roads_list);
                        FillWithRoads(simple_road[1], new Vector3((x) * distance, 0.2f, (y + 1) * distance), x, y + 1, directions.right);
                    }
                    else
                    {
                        MapMatrix[x, y] = 2;
                        CreateRoad(position, x, y, road, roads_list);
                        FillWithRoads(road, new Vector3((x - 1) * distance, 0.2f, y * distance), x - 1, y, condition);
                    }
                }
                else
                {
                    MapMatrix[x, y] = 2;
                    CreateRoad(position, x, y, road, roads_list);
                    FillWithRoads(road, new Vector3((x - 1) * distance, 0.2f, y * distance), x - 1, y, condition);
                }
            }
            else
            {
                number_of_intersections ++;

                FillWithRoads(road, new Vector3((x - 1) * distance, 0.2f, y * distance), x - 1, y, condition);
            }


        }

           else  if (road == simple_road[2] && condition == directions.down &&  x != 19 )
            {
            if (CheckIfThereIsTurnRoad(road, x, y,roads_list) == true)
            {
                return;
            }
            if (checkSimpleRoad(x, y, roads_list) == false)
            {
                int z = Random.Range(0, 100);
                if (z < 50)
                {

                    MapMatrix[x, y] = 2;

                    CreateRoad(position, x, y, road, roads_list);
                    FillWithRoads(road, new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, condition);
                }
               // else if (MapMatrix[x - 1, y] != 6 && MapMatrix[x - 1, y] != 5 && MapMatrix[x - 1, y] != 4 && MapMatrix[x - 1, y] != 3 && z > 50 && z < 75 && y != 19)
               else if (MapMatrix[x - 1, y] != 6 && MapMatrix[x - 1, y] != 5 && MapMatrix[x - 1, y] != 4 && MapMatrix[x - 1, y] != 3 && z > 50 && z <= 75 && y != 19 && MapMatrix[x + 1, y] == 1)
                {
                    if (MapMatrix[x + 1, y] != 6)
                    {
                        MapMatrix[x, y] = 5;
                        Roads_waypoint road_2 = simple_road[5];
                        CreateRoad(position, x, y, road_2, roads_list);
                        FillWithRoads(simple_road[1], new Vector3((x) * distance, 0.2f, (y + 1) * distance), x, y + 1, directions.right);
                    }
                    else if(MapMatrix[x + 1, y] == 6 && y!=0)
                    {

                        MapMatrix[x, y] = 4;
                        Roads_waypoint road_2 = simple_road[4];
                        CreateRoad(position, x, y, road_2, roads_list);
                        FillWithRoads(simple_road[1], new Vector3((x) * distance, 0.2f, (y - 1) * distance), x, y - 1, directions.left);
                    }

                    else
                    {
                        MapMatrix[x, y] = 2;
                        CreateRoad(position, x, y, road, roads_list);
                        FillWithRoads(road, new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, condition);
                    }


                }
               //else if (MapMatrix[x - 1, y] != 6 && MapMatrix[x - 1, y] != 5 && MapMatrix[x - 1, y] != 4 && MapMatrix[x - 1, y] != 3 && z > 50 && z < 75 && y != 0)
                else if (MapMatrix[x - 1, y] != 6 && MapMatrix[x - 1, y] != 5 && MapMatrix[x - 1, y] != 4 && MapMatrix[x - 1, y] != 3 && z > 75 && z <= 100 && y != 0 && MapMatrix[x + 1, y] != 1 )
                {
                    if (MapMatrix[x + 1, y] != 3)
                    {
                        MapMatrix[x, y] = 4;
                        Roads_waypoint road_2 = simple_road[4];
                        CreateRoad(position, x, y, road_2, roads_list);
                        FillWithRoads(simple_road[1], new Vector3((x) * distance, 0.2f, (y - 1) * distance), x, y - 1, directions.left);
                    }
                    else if(MapMatrix[x + 1, y] == 3  && y!=19)
                    {
                        MapMatrix[x, y] = 5;
                        Roads_waypoint road_2 = simple_road[5];
                        CreateRoad(position, x, y, road_2, roads_list);
                        FillWithRoads(simple_road[1], new Vector3((x) * distance, 0.2f, (y + 1) * distance), x, y + 1, directions.right);

                    }
                    else
                    {
                        MapMatrix[x, y] = 2;
                        CreateRoad(position, x, y, road, roads_list);
                        FillWithRoads(road, new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, condition);
                    }
                }
                else
                {
                    MapMatrix[x, y] = 2;
                    CreateRoad(position, x, y, road, roads_list);
                    FillWithRoads(road, new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, condition);
                }
            }
            else
            {
                number_of_intersections ++;
                FillWithRoads(road, new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, condition);
            }


        }

        PrintMatrixAsLog(MapMatrix);


    }

    private void CreateRoad(Vector3 position, int x, int y, Roads_waypoint road_2, List<Roads_waypoint> roadsList)
    {
        if (roadsList == roads_list)
        {
            if (road_2 == simple_road[0] || road_2 == simple_road[1] || road_2 == simple_road[2] || road_2 == simple_road[3] || road_2 == simple_road[4] || road_2 == simple_road[5] || road_2 == simple_road[6])
            {
                Roads_waypoint r = Instantiate(road_2, position, road_2.transform.rotation);
                r.x = x;
                r.y = y;
                id_1++;
                r.id = id_1;
                roadsList.Add(r);
            }
            else if (road_2 == intersection[0] || road_2 == intersection[1] || road_2 == intersection[2] || road_2 == intersection[3] || road_2 == intersection[4] || road_2 == intersection[5])
            {
                Roads_waypoint r = Instantiate(road_2, position, road_2.transform.rotation);
                r.x = x;
                r.y = y;
                id_1++;
                r.id = id_1;
                Roads_waypoint r_2 = roadsList.Find(item => item.x == x && item.y == y);
                if (r_2 != null)
                {
                    Destroy(roadsList[r_2.id].gameObject);
                    Debug.Log("id" + r_2.id);
                    roadsList[r_2.id] = r;
                    roadsList.Add(r);
                    if (roads_list_2.Find(item => item.x == x && item.y == y) != null)
                    {
                        Roads_waypoint r_3 = roads_list_2.Find(item => item.x == x && item.y == y);
                        roads_list_2[r_3.id] = r;
                        
                    }

                }


            }
        }

        if (roadsList == roads_list_2)
        {
            
            if (road_2 == simple_road[0] || road_2 == simple_road[1] || road_2 == simple_road[2] || road_2 == simple_road[3] || road_2 == simple_road[4] || road_2 == simple_road[5] || road_2 == simple_road[6])
            {
                Roads_waypoint r = Instantiate(road_2, position, road_2.transform.rotation);
                r.x = x;
                r.y = y;
                id_2++;
                r.id = id_2;
                roadsList.Add(r);
                Debug.Log("r" + r);
            }
            else if (road_2 == intersection[0] || road_2 == intersection[1] || road_2 == intersection[2] || road_2 == intersection[3] || road_2 == intersection[4] || road_2 == intersection[5])
            {
                Roads_waypoint r = Instantiate(road_2, position, road_2.transform.rotation);
                r.x = x;
                r.y = y;
                id_2++;
                r.id = id_2;
                Roads_waypoint r_2 = roadsList.Find(item => item.x == x && item.y == y);
                Debug.Log("r_2"+r_2);
                if (r_2 != null)
                {

                    Destroy(roadsList[r_2.id].gameObject);
                    Debug.Log("id from second list" + r_2.id);
                    roadsList[r_2.id] = r;
                    roadsList.Add(r);
                    if (roads_list.Find(item => item.x == x && item.y == y) != null)
                    {
                        Roads_waypoint r_3 = roads_list.Find(item => item.x == x && item.y == y);
                        roads_list[r_3.id] = r;

                    }
                }
                if (r_2 == null)
                { 

                    Roads_waypoint r_3 = roads_list.Find(item => item.x == x && item.y == y);
                    Destroy(roads_list[r_3.id].gameObject);
                    Debug.Log("id from another list" + r_3.id);
                    roads_list[r_3.id] = r;
                    roadsList.Add(r);

                }


            }
        }
    }


    bool checkSimpleRoad(int x, int y, List<Roads_waypoint> roads_list)
    {

        //skrzyżownie typu T na granichach

        if (MapMatrix[x, y] == 1 && x == 0)
        {
            Roads_waypoint inter = intersection[0];
            MapMatrix[x, y] = -1;
            Vector3 position = new Vector3(x * distance, 0.4f, y * distance);
            CreateRoad(position, x, y, inter, roads_list);
            return true;
        }
        if (MapMatrix[x, y] == 1 && x == 19)
        {
            Roads_waypoint inter = intersection[2];
            MapMatrix[x, y] = -2;
            Vector3 position = new Vector3(x * distance, 0.4f, y * distance);
            CreateRoad(position, x, y, inter, roads_list);
            return true;
        }
        if (MapMatrix[x, y] == 2 && y == 0)
        {
            Roads_waypoint inter = intersection[3];
            MapMatrix[x, y] = -3;
            Vector3 position = new Vector3(x * distance, 0.4f, y * distance);
            CreateRoad(position, x, y, inter, roads_list);
            return true;
        }
        if (MapMatrix[x, y] == 2 && y == 19)
        {
            Roads_waypoint inter = intersection[1];
            MapMatrix[x, y] = -1;
            Vector3 position = new Vector3(x * distance, 0.4f, y * distance);
            CreateRoad(position, x, y, inter, roads_list);
            return true;
        }
        //skrzyzowania z 4 rozgalezianiami 
        if (MapMatrix[x, y] == 1 && x < 19 && x > 0 & y < 19 && y > 0 )
        {
            Roads_waypoint inter = intersection[Random.Range(4, 5)];
            MapMatrix[x, y] = -4;
            Vector3 position = new Vector3(x * distance, 0.4f, y * distance);
            CreateRoad(position, x, y, inter, roads_list);
            //  Debug.Log(number_of_intersections);
            return true;

        }
        if (MapMatrix[x, y] == 2 && x < 19 && x > 0 & y < 19 && y > 0 )
        {
            Roads_waypoint inter = intersection[Random.Range(4, 5)];
            MapMatrix[x, y] = -4;
            Vector3 position = new Vector3(x * distance, 0.4f, y * distance);
            CreateRoad(position, x, y, inter, roads_list);
            //  Debug.Log(number_of_intersections);
            return true;


        }
        if (MapMatrix[x, y] == 0)
        {
           
            return false;
        }
        return false;
    }

    bool CheckIfThereIsTurnRoad(Roads_waypoint road, int x, int y, List<Roads_waypoint> roads_list)
    {

        if (MapMatrix[x, y] == 3)
        {
            if (road == simple_road[1])
            {
                Roads_waypoint inter = intersection[0];
                MapMatrix[x, y] = -1;
                Vector3 position = new Vector3(x * distance, 0.6f, y * distance);
                CreateRoad(position, x, y, inter, roads_list);
                return true;
            }
            else if (road == simple_road[2])
            {
                Roads_waypoint inter = intersection[1];
                MapMatrix[x, y] = -1;
                Vector3 position = new Vector3(x * distance, 0.6f, y * distance);
                CreateRoad(position, x, y, inter, roads_list);
                return true;
            }
        }
        else if (MapMatrix[x, y] == 4)
        {
            if (road == simple_road[1])
            {
                Roads_waypoint inter = intersection[2];
                MapMatrix[x, y] = -2;
                Vector3 position = new Vector3(x * distance, 0.6f, y * distance);
                CreateRoad(position, x, y, inter, roads_list);
                return true;
            }
            else if (road == simple_road[2])
            {
                Roads_waypoint inter = intersection[1];
                MapMatrix[x, y] = -1;
                Vector3 position = new Vector3(x * distance, 0.6f, y * distance);
                CreateRoad(position, x, y, inter, roads_list);
                return true;
            }
        }
        else if (MapMatrix[x, y] == 5)
        {
            if (road == simple_road[1])
            {
                Roads_waypoint inter = intersection[2];
                MapMatrix[x, y] = -2;
                Vector3 position = new Vector3(x * distance, 0.6f, y * distance);
                CreateRoad(position, x, y, inter, roads_list);
                return true;
            }
            else if (road == simple_road[2])
            {
                Roads_waypoint inter = intersection[3];
                MapMatrix[x, y] = -3;
                Vector3 position = new Vector3(x * distance, 0.6f, y * distance);
                CreateRoad(position, x, y, inter, roads_list);
                return true;
            }
        }
        else if (MapMatrix[x, y] == 6)
        {
            if (road == simple_road[1])
            {
                Roads_waypoint inter = intersection[0];
                MapMatrix[x, y] = -1;
                Vector3 position = new Vector3(x * distance, 0.6f, y * distance);
                CreateRoad(position, x, y, inter, roads_list);
                return true;
            }
            else if (road == simple_road[2])
            {
                Roads_waypoint inter = intersection[3];
                MapMatrix[x, y] = -3;
                Vector3 position = new Vector3(x * distance, 0.6f, y * distance);
                CreateRoad(position, x, y, inter, roads_list);
                return true;
            }
        }
        else
        {
            return false;
        }
        return false;
    }
  
    /// ///////////////////////// 
    void FindForFirstPieceConnection(Roads_waypoint road, Vector3 position, int x, int y, directions condition)
    {

        directions dir;
        Debug.Log(number_of_intersections);

        if (number_of_intersections == 5)
        {
            Debug.Log("end");
            return;
        }
        ///przy granicy
        //prawa 
        else if (y == 19 && x < 19 && x > 0 && road == simple_road[1])
        {
            if (checkSimpleRoad(x, y, roads_list_2) == false)
            {
                Roads_waypoint road_2 = simple_road[Random.Range(3, 4)];
                if (road_2 == simple_road[3])
                {
                    MapMatrix[x, y] = 3;
                    CreateRoad(position, x, y, road_2, roads_list_2);
                    Roads_waypoint road_3 = simple_road[2];
                    dir = directions.down;
                    FindForFirstPieceConnection(road_3, new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, dir);

                }
                if (road_2 == simple_road[4])
                {
                    MapMatrix[x, y] = 4;
                    CreateRoad(position, x, y, road_2, roads_list_2);

                    Roads_waypoint road_3 = simple_road[2];
                    dir = directions.up;
                    FindForFirstPieceConnection(road_3, new Vector3((x - 1) * distance, 0.2f, y * distance), x - 1, y, dir);

                }
            }
            else if (checkSimpleRoad(x, y, roads_list_2) == true)
            {
                return;
            }
        }
        //lewa
        else if (y == 0 && x < 19 && x > 0 && road == simple_road[1])
        {
            if (checkSimpleRoad(x, y, roads_list_2) == false)
            {
                Roads_waypoint road_2 = simple_road[Random.Range(5, 6)];
                if (road_2 == simple_road[6])
                {
                    MapMatrix[x, y] = 6;
                    CreateRoad(position, x, y, road_2, roads_list_2);
                    Roads_waypoint road_3 = simple_road[2];
                    dir = directions.down;
                    FindForFirstPieceConnection(road_3, new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, dir);

                }
                if (road_2 == simple_road[5])
                {
                    MapMatrix[x, y] = 5;
                    CreateRoad(position, x, y, road_2, roads_list_2);
                    Roads_waypoint road_3 = simple_road[2];
                    dir = directions.up;
                    FindForFirstPieceConnection(road_3, new Vector3((x - 1) * distance, 0.2f, y * distance), x - 1, y, dir);

                }
            }
            else if (checkSimpleRoad(x, y, roads_list_2) == true)
            {
                return;
            }
        }
        //dolna
        else if (x == 19 && y < 19 && y > 0 && road == simple_road[2])
        {
            if (checkSimpleRoad(x, y, roads_list_2) == false)
            {

                Roads_waypoint road_2 = simple_road[Random.Range(4, 5)];
                if (road_2 == simple_road[4])
                {
                    MapMatrix[x, y] = 4;
                    CreateRoad(position, x, y, road_2, roads_list_2);
                    Roads_waypoint road_3 = simple_road[1];
                    dir = directions.left;
                    FindForFirstPieceConnection(road_3, new Vector3((x) * distance, 0.2f, (y - 1) * distance), x, y - 1, dir);

                }
                if (road_2 == simple_road[5])
                {
                    MapMatrix[x, y] = 5;
                    CreateRoad(position, x, y, road_2, roads_list_2);
                    Roads_waypoint road_3 = simple_road[1];
                    dir = directions.right;
                    FindForFirstPieceConnection(road_3, new Vector3(x * distance, 0.2f, y + 1 * distance), x, y + 1, dir);

                }
            }
            else if (checkSimpleRoad(x, y, roads_list_2) == true)
            {
                return;
            }
        }
        //górna
        else if (x == 0 && y < 19 && y > 0 && road == simple_road[2])
        {
            if (checkSimpleRoad(x, y, roads_list_2) == false)
            {

                int rand = Random.Range(1, 2);

                if (rand == 1)
                {
                    Roads_waypoint road_2 = simple_road[3];
                    MapMatrix[x, y] = 3;
                    CreateRoad(position, x, y, road_2, roads_list_2);
                    Roads_waypoint road_3 = simple_road[1];
                    dir = directions.left;
                    FindForFirstPieceConnection(road_3, new Vector3((x) * distance, 0.2f, (y - 1) * distance), x, y - 1, dir);

                }
                if (rand == 2)
                {
                    Roads_waypoint road_2 = simple_road[6];
                    MapMatrix[x, y] = 6;
                    CreateRoad(position, x, y, road_2, roads_list_2);
                    Roads_waypoint road_3 = simple_road[1];
                    dir = directions.right;
                    FindForFirstPieceConnection(road_3, new Vector3(x * distance, 0.2f, y + 1 * distance), x, y + 1, dir);

                }
            }
            else if (checkSimpleRoad(x, y, roads_list_2) == true)
            {
                return;
            }
        }

        //
        else if (y == 19 && x == 19 && road == simple_road[2])
        {
            MapMatrix[x, y] = 4;
            Roads_waypoint road_2 = simple_road[4];
            CreateRoad(position, x, y, road_2, roads_list_2);
            Roads_waypoint road_3 = simple_road[1];
            dir = directions.left;
            FindForFirstPieceConnection(road_3, new Vector3((x) * distance, 0.2f, (y - 1) * distance), x, y - 1, dir);


        }
        else if (y == 19 && x == 19 && road == simple_road[1])
        {
            MapMatrix[x, y] = 4;
            Roads_waypoint road_2 = simple_road[4];
            CreateRoad(position, x, y, road_2, roads_list_2);
            Roads_waypoint road_3 = simple_road[2];
            dir = directions.up;
            FindForFirstPieceConnection(road_3, new Vector3((x - 1) * distance, 0.2f, (y) * distance), x - 1, y, dir);


        }
        //      if (x == 19 && road!=simple_road[1]) return;
        else if (x == 19 && y == 0 && road == simple_road[1])
        {
            MapMatrix[x, y] = 5;
            Roads_waypoint road_2 = simple_road[5];
            CreateRoad(position, x, y, road_2, roads_list_2);
            Roads_waypoint road_3 = simple_road[2];
            dir = directions.up;
            FindForFirstPieceConnection(road_3, new Vector3((x - 1) * distance, 0.2f, y * distance), x - 1, y, dir);

        }
        //nowe
        else if (x == 19 && y == 0 && road == simple_road[2])
        {
            MapMatrix[x, y] = 5;
            Roads_waypoint road_2 = simple_road[5];
            CreateRoad(position, x, y, road_2, roads_list_2);
            Roads_waypoint road_3 = simple_road[1];
            dir = directions.right;
            FindForFirstPieceConnection(road_3, new Vector3((x) * distance, 0.2f, (y + 1) * distance), x, y + 1, dir);
        }

        //   if (y == 0 && road!=simple_road[2]) return;
        else if (y == 0 && x == 0 && road == simple_road[2])
        {
            MapMatrix[x, y] = 6;
            Roads_waypoint road_2 = simple_road[6];
            CreateRoad(position, x, y, road_2, roads_list_2);

            Roads_waypoint road_3 = simple_road[1];
            dir = directions.right;
            FindForFirstPieceConnection(road_3, new Vector3(x * distance, 0.2f, (y + 1) * distance), x, y + 1, dir);



        }

        else if (y == 0 && x == 0 && road == simple_road[1])
        {
            MapMatrix[x, y] = 6;
            Roads_waypoint road_2 = simple_road[6];
            CreateRoad(position, x, y, road_2, roads_list_2);

            Roads_waypoint road_3 = simple_road[2];
            dir = directions.down;

            FindForFirstPieceConnection(road_3, new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, dir);




        }
        else if (y == 19 && x == 0 && road == simple_road[1])
        {
            Debug.Log("halo");
            MapMatrix[x, y] = 3;
            Roads_waypoint road_2 = simple_road[3];
             CreateRoad(position, x, y, road_2, roads_list_2);
            if (checkSimpleRoad(x + 1, y, roads_list_2) == false)
            {
                Roads_waypoint road_3 = simple_road[2];
                dir = directions.down;
                FindForFirstPieceConnection(road_3, new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, dir);

            }
            else if (checkSimpleRoad(x + 1, y, roads_list_2) == true)
            {
                Debug.Log("?");
                return;

            }
        }
        //nowe

        else if (y == 19 && x == 0 && road == simple_road[2])
        {
            Debug.Log("halo");
            MapMatrix[x, y] = 3;
            Roads_waypoint road_2 = simple_road[3];
            CreateRoad(position, x, y, road_2, roads_list_2);

            Roads_waypoint road_3 = simple_road[1];
            dir = directions.left;
            FindForFirstPieceConnection(road_3, new Vector3((x) * distance, 0.2f, (y - 1) * distance), x, y - 1, dir);

        }

        ///

        else if (road == simple_road[1] && condition == directions.right && y != 19)
        {
            if (CheckIfThereIsTurnRoad(road, x, y,roads_list_2) == true)
            {
                return;
            }
            else if (CanIMakeEndRoad(road,x, y,condition,roads_list_2) == false)
            {
                int z = Random.Range(0, 100);
                if (z < 50)
                {
                    MapMatrix[x, y] = 1;
                    CreateRoad(position, x, y, road, roads_list_2);
                    FindForFirstPieceConnection(road, new Vector3(x * distance, 0.2f, (y + 1) * distance), x, y + 1, condition);
                }
                //else  if (MapMatrix[x, y - 1] != 6 && MapMatrix[x, y - 1] != 5 && MapMatrix[x, y - 1] != 4 && MapMatrix[x, y - 1] != 3 && z > 50 && z < 75 && x != 19)
                else if (MapMatrix[x, y - 1] != 6 && MapMatrix[x, y - 1] != 5 && MapMatrix[x, y - 1] != 4 && MapMatrix[x, y - 1] != 3 && z > 50 && z < 75 && x != 19 && MapMatrix[x, y + 1] != 2)
                {
                    //tutaj sprawdzamy czy przed nami nie znajduje się skrzyżowanie w ta samą stronę, jeśli tak musimy dać w odwrotną stornę 
                    if (MapMatrix[x, y + 1] != 6)
                    {
                        MapMatrix[x, y] = 3;
                        Roads_waypoint road_2 = simple_road[3];
                        CreateRoad(position, x, y, road_2, roads_list_2);
                        FindForFirstPieceConnection(simple_road[2], new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, directions.down);
                    }
                    else if (MapMatrix[x, y + 1] == 6 && x != 0)
                    {
                        MapMatrix[x, y] = 4;
                        Roads_waypoint road_2 = simple_road[4];
                        CreateRoad(position, x, y, road_2, roads_list_2);
                        FindForFirstPieceConnection(simple_road[2], new Vector3((x - 1) * distance, 0.2f, y * distance), x - 1, y, directions.up);
                    }
                    else
                    {
                        MapMatrix[x, y] = 1;
                        CreateRoad(position, x, y, road, roads_list_2);
                        FindForFirstPieceConnection(road, new Vector3(x * distance, 0.2f, (y + 1) * distance), x, y + 1, condition);
                    }

                }
                // else if (MapMatrix[x, y - 1] != 6 && MapMatrix[x, y - 1] != 5 && MapMatrix[x, y - 1] != 4 && MapMatrix[x, y - 1] != 3 && z > 75 && z <= 100 && x != 0)
                else if (MapMatrix[x, y - 1] != 6 && MapMatrix[x, y - 1] != 5 && MapMatrix[x, y - 1] != 4 && MapMatrix[x, y - 1] != 3 && z > 75 && z <= 100 && x != 0 && MapMatrix[x, y + 1] != 2)
                {
                    if (MapMatrix[x, y + 1] != 5)
                    {
                        MapMatrix[x, y] = 4;
                        Roads_waypoint road_2 = simple_road[4];
                        CreateRoad(position, x, y, road_2, roads_list_2);
                        FindForFirstPieceConnection(simple_road[2], new Vector3((x - 1) * distance, 0.2f, y * distance), x - 1, y, directions.up);
                    }
                    else if (MapMatrix[x, y + 1] == 5 && x != 19)
                    {
                        MapMatrix[x, y] = 3;
                        Roads_waypoint road_2 = simple_road[3];
                        CreateRoad(position, x, y, road_2, roads_list_2);
                        FindForFirstPieceConnection(simple_road[2], new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, directions.down);
                    }
                    else
                    {
                        MapMatrix[x, y] = 1;
                        CreateRoad(position, x, y, road, roads_list_2);
                        FindForFirstPieceConnection(road, new Vector3(x * distance, 0.2f, (y + 1) * distance), x, y + 1, condition);
                    }
                }
                else
                {
                    MapMatrix[x, y] = 1;
                    Instantiate(road, position, road.transform.rotation);
                    FindForFirstPieceConnection(road, new Vector3(x * distance, 0.2f, (y + 1) * distance), x, y + 1, condition);
                }

            }
            else
            {
                return;

            }

        }

        else if (road == simple_road[1] && condition == directions.left && y != 0)
        {

            // Debug.Log("halo");
            if (CheckIfThereIsTurnRoad(road, x, y, roads_list_2) == true)
            {
                return;
            }
            if (CanIMakeEndRoad(road, x, y, condition, roads_list_2) == false)
            {

                int z = Random.Range(0, 100);
                if (z < 50)
                {
                    MapMatrix[x, y] = 1;
                    CreateRoad(position, x, y, road, roads_list_2);
                    FindForFirstPieceConnection(road, new Vector3(x * distance, 0.2f, (y - 1) * distance), x, y - 1, condition);
                }
                //jezeli idziemy w lewo musimy sprawdzic czy za nami nie ma znowu skrzyzowanie w tym przypadku za nami bedzie to y+1
                //else if (MapMatrix[x, y + 1] != 6 && MapMatrix[x, y + 1] != 5 && MapMatrix[x, y + 1] != 4 && MapMatrix[x, y + 1] != 3 && z > 50 && z < 75 && x != 19)
                else if (MapMatrix[x, y + 1] != 6 && MapMatrix[x, y + 1] != 5 && MapMatrix[x, y + 1] != 4 && MapMatrix[x, y + 1] != 3 && z > 50 && z < 75 && x != 19 && MapMatrix[x, y - 1] != 2)
                {
                    if (MapMatrix[x, y - 1] != 3)
                    {
                        MapMatrix[x, y] = 6;
                        Roads_waypoint road_2 = simple_road[6];
                        CreateRoad(position, x, y, road_2, roads_list_2);
                        FindForFirstPieceConnection(simple_road[2], new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, directions.down);
                    }
                    else if (MapMatrix[x, y - 1] == 3 && x != 0)
                    {

                        MapMatrix[x, y] = 5;
                        Roads_waypoint road_2 = simple_road[5];
                        CreateRoad(position, x, y, road_2, roads_list_2);
                        FindForFirstPieceConnection(simple_road[2], new Vector3((x - 1) * distance, 0.2f, y * distance), x - 1, y, directions.up);
                    }
                    else
                    {
                        MapMatrix[x, y] = 1;
                        CreateRoad(position, x, y, road, roads_list_2);
                        FindForFirstPieceConnection(road, new Vector3(x * distance, 0.2f, (y - 1) * distance), x, y - 1, condition);
                    }


                }
                //else  if (MapMatrix[x, y + 1] != 6 && MapMatrix[x, y + 1] != 5 && MapMatrix[x, y + 1] != 4 && MapMatrix[x, y + 1] != 3 && z > 75 && z <= 100 && x != 0)
                else if (MapMatrix[x, y + 1] != 6 && MapMatrix[x, y + 1] != 5 && MapMatrix[x, y + 1] != 4 && MapMatrix[x, y + 1] != 3 && z > 75 && z <= 100 && x != 0 && MapMatrix[x, y - 1] != 2)
                {


                    if (MapMatrix[x, y - 1] != 4)
                    {
                        MapMatrix[x, y] = 5;
                        Roads_waypoint road_2 = simple_road[5];
                        CreateRoad(position, x, y, road_2, roads_list_2);
                        FindForFirstPieceConnection(simple_road[2], new Vector3((x - 1) * distance, 0.2f, y * distance), x - 1, y, directions.up);
                    }
                    else if (MapMatrix[x, y - 1] == 4 && x != 19)
                    {
                        MapMatrix[x, y] = 6;
                        Roads_waypoint road_2 = simple_road[6];
                        CreateRoad(position, x, y, road_2, roads_list_2);
                        FindForFirstPieceConnection(simple_road[2], new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, directions.down);
                    }
                    else
                    {
                        MapMatrix[x, y] = 1;
                        CreateRoad(position, x, y, road, roads_list_2);
                        FindForFirstPieceConnection(road, new Vector3(x * distance, 0.2f, (y - 1) * distance), x, y - 1, condition);
                    }

                }
                else
                {
                    MapMatrix[x, y] = 1;
                    CreateRoad(position, x, y, road, roads_list_2);
                    FindForFirstPieceConnection(road, new Vector3(x * distance, 0.2f, (y - 1) * distance), x, y - 1, condition);
                }
            }
            else
            {
                return;
            }

        }
        //tutaj tez nie wiem, warunek z x może być nie tak potem
        else if (road == simple_road[2] && condition == directions.up && x != 0)
        {
            if (CheckIfThereIsTurnRoad(road, x, y, roads_list_2) == true)
            {
                return;
            }

            if (CanIMakeEndRoad(road, x, y, condition, roads_list_2) == false)
            {
                int z = Random.Range(0, 100);
                if (z < 50)
                {
                    MapMatrix[x, y] = 2;

                    CreateRoad(position, x, y, road, roads_list_2);
                    FindForFirstPieceConnection(road, new Vector3((x - 1) * distance, 0.2f, y * distance), x - 1, y, condition);
                }
                //else if (MapMatrix[x + 1, y] != 6 && MapMatrix[x + 1, y] != 5 && MapMatrix[x + 1, y] != 4 && MapMatrix[x + 1, y] != 3 && z > 50 && z < 75 && y != 19)
                else if (MapMatrix[x + 1, y] != 6 && MapMatrix[x + 1, y] != 5 && MapMatrix[x + 1, y] != 4 && MapMatrix[x + 1, y] != 3 && z > 50 && z < 75 && y != 19 && MapMatrix[x - 1, y] != 1)
                {

                    if (MapMatrix[x - 1, y] != 5)
                    {
                        MapMatrix[x, y] = 6;
                        Roads_waypoint road_2 = simple_road[6];
                        CreateRoad(position, x, y, road_2, roads_list_2);
                        FindForFirstPieceConnection(simple_road[1], new Vector3((x) * distance, 0.2f, (y + 1) * distance), x, y + 1, directions.right);
                    }
                    //tutaj musi być y!=0 żeby nie skręcało w lewo w lewym rogu mapy 
                    else if (MapMatrix[x - 1, y] == 5 && y != 0)
                    {
                        MapMatrix[x, y] = 3;
                        Roads_waypoint road_2 = simple_road[3];
                        CreateRoad(position, x, y, road_2, roads_list_2);
                        FindForFirstPieceConnection(simple_road[1], new Vector3((x) * distance, 0.2f, (y - 1) * distance), x, y - 1, directions.left);

                    }
                    else
                    {
                        MapMatrix[x, y] = 2;
                        CreateRoad(position, x, y, road, roads_list_2);
                        FindForFirstPieceConnection(road, new Vector3((x - 1) * distance, 0.2f, y * distance), x - 1, y, condition);
                    }



                }
                //else if (MapMatrix[x + 1, y] != 6 && MapMatrix[x + 1, y] != 5 && MapMatrix[x + 1, y] != 4 && MapMatrix[x + 1, y] != 3 && z > 75 && z <=100 && y != 0)
                else if (MapMatrix[x + 1, y] != 6 && MapMatrix[x + 1, y] != 5 && MapMatrix[x + 1, y] != 4 && MapMatrix[x + 1, y] != 3 && z > 75 && z <= 100 && y != 0 && MapMatrix[x - 1, y] != 1)
                {

                    if (MapMatrix[x - 1, y] != 4)
                    {
                        MapMatrix[x, y] = 3;
                        Roads_waypoint road_2 = simple_road[3];
                        CreateRoad(position, x, y, road_2, roads_list_2);
                        FindForFirstPieceConnection(simple_road[1], new Vector3((x) * distance, 0.2f, (y - 1) * distance), x, y - 1, directions.left);
                    }
                    else if (MapMatrix[x - 1, y] == 4 && y != 19)
                    {
                        MapMatrix[x, y] = 6;
                        Roads_waypoint road_2 = simple_road[6];
                        CreateRoad(position, x, y, road_2, roads_list_2);
                        FindForFirstPieceConnection(simple_road[1], new Vector3((x) * distance, 0.2f, (y + 1) * distance), x, y + 1, directions.right);
                    }
                    else
                    {
                        MapMatrix[x, y] = 2;

                        CreateRoad(position, x, y, road, roads_list_2);
                        FindForFirstPieceConnection(road, new Vector3((x - 1) * distance, 0.2f, y * distance), x - 1, y, condition);
                    }
                }
                else
                {
                    MapMatrix[x, y] = 2;

                    CreateRoad(position, x, y, road, roads_list_2);
                    FindForFirstPieceConnection(road, new Vector3((x - 1) * distance, 0.2f, y * distance), x - 1, y, condition);
                }
            }
            else
            {
                return;
            }


        }

        else if (road == simple_road[2] && condition == directions.down && x != 19)
        {
            if (CheckIfThereIsTurnRoad(road, x, y, roads_list_2) == true)
            {
                return;
            }
            if (CanIMakeEndRoad(road, x, y, condition, roads_list_2) == false)
            {
                int z = Random.Range(0, 100);
                if (z < 50)
                {

                    MapMatrix[x, y] = 2;

                    CreateRoad(position, x, y, road, roads_list_2);
                    FindForFirstPieceConnection(road, new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, condition);
                }
                // else if (MapMatrix[x - 1, y] != 6 && MapMatrix[x - 1, y] != 5 && MapMatrix[x - 1, y] != 4 && MapMatrix[x - 1, y] != 3 && z > 50 && z < 75 && y != 19)
                else if (MapMatrix[x - 1, y] != 6 && MapMatrix[x - 1, y] != 5 && MapMatrix[x - 1, y] != 4 && MapMatrix[x - 1, y] != 3 && z > 50 && z <= 75 && y != 19 && MapMatrix[x + 1, y] == 1)
                {
                    if (MapMatrix[x + 1, y] != 6)
                    {
                        MapMatrix[x, y] = 5;
                        Roads_waypoint road_2 = simple_road[5];
                        CreateRoad(position, x, y, road_2, roads_list_2);
                        FindForFirstPieceConnection(simple_road[1], new Vector3((x) * distance, 0.2f, (y + 1) * distance), x, y + 1, directions.right);
                    }
                    else if (MapMatrix[x + 1, y] == 6 && y != 0)
                    {

                        MapMatrix[x, y] = 4;
                        Roads_waypoint road_2 = simple_road[4];
                        CreateRoad(position, x, y, road_2, roads_list_2);
                        FindForFirstPieceConnection(simple_road[1], new Vector3((x) * distance, 0.2f, (y - 1) * distance), x, y - 1, directions.left);
                    }

                    else
                    {
                        MapMatrix[x, y] = 2;

                        CreateRoad(position, x, y, road, roads_list_2);
                        FindForFirstPieceConnection(road, new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, condition);
                    }


                }
                //else if (MapMatrix[x - 1, y] != 6 && MapMatrix[x - 1, y] != 5 && MapMatrix[x - 1, y] != 4 && MapMatrix[x - 1, y] != 3 && z > 50 && z < 75 && y != 0)
                else if (MapMatrix[x - 1, y] != 6 && MapMatrix[x - 1, y] != 5 && MapMatrix[x - 1, y] != 4 && MapMatrix[x - 1, y] != 3 && z > 75 && z <= 100 && y != 0 && MapMatrix[x + 1, y] != 1)
                {
                    if (MapMatrix[x + 1, y] != 3)
                    {
                        MapMatrix[x, y] = 4;
                        Roads_waypoint road_2 = simple_road[4];
                        CreateRoad(position, x, y, road_2, roads_list_2);
                        FindForFirstPieceConnection(simple_road[1], new Vector3((x) * distance, 0.2f, (y - 1) * distance), x, y - 1, directions.left);
                    }
                    else if (MapMatrix[x + 1, y] == 3 && y != 19)
                    {
                        MapMatrix[x, y] = 5;
                        Roads_waypoint road_2 = simple_road[5];
                        CreateRoad(position, x, y, road_2, roads_list_2);
                        FindForFirstPieceConnection(simple_road[1], new Vector3((x) * distance, 0.2f, (y + 1) * distance), x, y + 1, directions.right);

                    }
                    else
                    {
                        MapMatrix[x, y] = 2;

                        CreateRoad(position, x, y, road, roads_list_2);
                        FindForFirstPieceConnection(road, new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, condition);
                    }
                }
                else
                {
                    MapMatrix[x, y] = 2;

                    CreateRoad(position, x, y, road, roads_list_2);
                    FindForFirstPieceConnection(road, new Vector3((x + 1) * distance, 0.2f, y * distance), x + 1, y, condition);
                }
            }
            else
            {
                return;
            }


        }

        PrintMatrixAsLog(MapMatrix);


    }


    bool CanIMakeEndRoad(Roads_waypoint road,int x, int y, directions dir, List<Roads_waypoint> roads_list_2)
    {
        //skrzyżownie typu T na granichach

        if (MapMatrix[x, y] == 1 && x == 0)
        {
            Roads_waypoint inter = intersection[0];
            MapMatrix[x, y] = -1;
            Vector3 position = new Vector3(x * distance, 0.4f, y * distance);
            CreateRoad(position, x, y, inter, roads_list_2);
            return true;
        }
        if (MapMatrix[x, y] == 1 && x == 19)
        {
            Roads_waypoint inter = intersection[2];
            MapMatrix[x, y] = -2;
            Vector3 position = new Vector3(x * distance, 0.4f, y * distance);
            CreateRoad(position, x, y, inter, roads_list_2);
            return true;
        }
        if (MapMatrix[x, y] == 2 && y == 0)
        {
            Roads_waypoint inter = intersection[3];
            MapMatrix[x, y] = -3;
            Vector3 position = new Vector3(x * distance, 0.4f, y * distance);
            CreateRoad(position, x, y, inter, roads_list_2);
            return true;
        }
        if (MapMatrix[x, y] == 2 && y == 19)
        {
            Roads_waypoint inter = intersection[1];
            MapMatrix[x, y] = -1;
            Vector3 position = new Vector3(x * distance, 0.4f, y * distance);
            CreateRoad(position, x, y, inter, roads_list_2);
            return true;
        }

        if (MapMatrix[x, y] == 1 && x < 19 && x > 0 & y < 19 && y > 0 && road==simple_road[2] && dir==directions.up)
        {
            Roads_waypoint inter = intersection[0];
            MapMatrix[x, y] = -1;
            Vector3 position = new Vector3(x * distance, 0.4f, y * distance);
            CreateRoad(position, x, y, inter, roads_list_2);
            //  Debug.Log(number_of_intersections);
            return true;

        }
        if (MapMatrix[x, y] == 1 && x < 19 && x > 0 & y < 19 && y > 0 && road == simple_road[2] && dir == directions.down)
        {
            Roads_waypoint inter = intersection[2];
            MapMatrix[x, y] = -2;
            Vector3 position = new Vector3(x * distance, 0.4f, y * distance);
            CreateRoad(position, x, y, inter, roads_list_2);
            //  Debug.Log(number_of_intersections);
            return true;

        }
        if (MapMatrix[x, y] == 2 && x < 19 && x > 0 & y < 19 && y > 0 && road == simple_road[1] && dir == directions.left)
        {
            Roads_waypoint inter = intersection[3];
            MapMatrix[x, y] = -3;
            Vector3 position = new Vector3(x * distance, 0.4f, y * distance);
            CreateRoad(position, x, y, inter, roads_list_2);
            //  Debug.Log(number_of_intersections);
            return true;


        }
        if (MapMatrix[x, y] == 2 && x < 19 && x > 0 & y < 19 && y > 0 && road == simple_road[1] && dir == directions.right)
        {
            Roads_waypoint inter = intersection[1];
            MapMatrix[x, y] = -1;
            Vector3 position = new Vector3(x * distance, 0.4f, y * distance);
            CreateRoad(position, x, y, inter, roads_list_2);
            //  Debug.Log(number_of_intersections);
            return true;


        }
        if (MapMatrix[x, y] == 0)
        {

            return false;
        }
        return false;
    }


}

    
