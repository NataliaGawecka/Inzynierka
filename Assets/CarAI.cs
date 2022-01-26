using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAI : MonoBehaviour
{



    public float maxSteerAngle = 45f;
    public Waypoint currentWaypoint;
    public float dist;
    public WheelCollider wheelFL;
    public WheelCollider wheelFR;
    public WheelCollider wheelRL;
    public WheelCollider wheelRR;
    public Vector3 centerOfMass;
    public float maxMotorTorque = 80f;
    public float maxBrakeTorque = 150f;
    public float currentSpeed;
    public float maxSpeed = 100;
   
    public bool isBraking = false;
    public Renderer carRenderer;
    private float vertical, horizontal;
    private float radius = 8, distance;


    [Header("RaycastSensors")]
    public float rayLenght = 10f;



    private void Start()
    {

        GetComponent<Rigidbody>().centerOfMass = centerOfMass;



    }


    void FixedUpdate()
    {

        try
        {
            RaycastSensors();
            checkWaypointDistance();
            ApplySteer();

        }
        catch { }

    }

    private bool RaycastSensors()
    {
        RaycastHit hit;
  

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLenght))
        {
            // Debug.DrawLine(transform.position, hit.point);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            if (hit.collider.gameObject.CompareTag("Car"))
            {
                //Debug.Log("stop because of car");
                CarAI SecondCar = hit.collider.gameObject.GetComponent<CarAI>();
                if (SecondCar.currentWaypoint == currentWaypoint.nextWaypoint || SecondCar.currentWaypoint == currentWaypoint)
                {
                    return true;
                }
                else return false;
            }

        }
        return false;
    }

    void checkWaypointDistance()
    {

        if (Vector3.Distance(transform.position, currentWaypoint.transform.position) <= 1)
        {
            reachedWaypoint();
        }


    }


    private void reachedWaypoint()
    {
        if (currentWaypoint.nextWaypoint == null)
        {
            isBraking = true;
            return;
        }

        if (currentWaypoint.link != null && currentWaypoint.link_nr2 == null && Random.Range(0, 100) <= 50)
            currentWaypoint = currentWaypoint.link;
        else if (currentWaypoint.link != null && currentWaypoint.link_nr2 != null && Random.Range(0, 300) < 100)
            currentWaypoint = currentWaypoint.link;
        else if (currentWaypoint.link != null && currentWaypoint.link_nr2 != null && Random.Range(0, 300) > 100 && Random.Range(0, 300) < 200)
            currentWaypoint = currentWaypoint.link_nr2;
        else
            currentWaypoint = currentWaypoint.nextWaypoint;


    }


    private void ApplySteer()
    {

        Vector3 relativeVector = transform.InverseTransformPoint(currentWaypoint.transform.position);

        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;

        currentSpeed = 2 * Mathf.PI * wheelFL.radius * wheelFL.rpm * 60 / 1000;


        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer;

        Debug.Log("brakes" + wheelRL.brakeTorque);
        //jezeli auto nie powinno chamowac ani nie wykryto zadnego pojazdu przed autem
        if (isBraking == false && RaycastSensors() == false)
        {
           // Debug.Log("is NOT breaking in function Apply Steer");
            //moc hamulców ustawiona jest na 0
            wheelRL.brakeTorque = 0;
            wheelRR.brakeTorque = 0;

            //jezeli obecna predkosć nie przekracza maksymalnej prędkości motorTorque jest ustawiony na maksymalny moment obrotowy silnika
            if (currentSpeed < maxSpeed)
            {
                wheelFL.motorTorque = maxMotorTorque;
                wheelFR.motorTorque = maxMotorTorque;
            }
            //jezeli obecna predkość przekracza lub jest równa maksymalnej przestaje być dodawana moc do silnika
           else if(currentSpeed >= maxSpeed)
            {
                wheelFL.motorTorque = 0;
                wheelFR.motorTorque = 0;
            }

        }
       //jezeli auto nie hamuje ale wykryto pojazd przed nami moc hamulcow jest usrawiona w zależności od aktualnej predkości oraz maksymalnej siły hamulców.
       else  if (isBraking == false && RaycastSensors() == true)
        {
            wheelRL.brakeTorque = currentSpeed * maxBrakeTorque;
            wheelRR.brakeTorque = currentSpeed * maxBrakeTorque;
        }
        //jezeli auto hamuje ustawiana jest wartość siły hamulcowej
        else if (isBraking == true)
        {
            //Debug.Log("is breaking in function Apply Steer");
            //Debug.Log("brakes true" + wheelRL.brakeTorque);
            wheelRL.brakeTorque = currentSpeed * maxBrakeTorque;
            wheelRR.brakeTorque = currentSpeed * maxBrakeTorque;
        }





    }

    
    void OnTriggerStay(Collider other)
    {
        //Debug.Log("On trigger");

        if (other.gameObject.tag == "T_Intersection")
        {

            T_Intersection intersection = other.gameObject.GetComponent<T_Intersection>();
            //Debug.Log(intersection.car_status + " " + gameObject.name);

            if (intersection.t_intersection_status.t_status == T_status.STOP && currentWaypoint != intersection.freeToRideWaypoint)
            {
              //  Debug.Log("change bool of breaking");
                isBraking = true;
                // print(isBraking);

                //  Braking();


            }
            else if (intersection.t_intersection_status.t_status == T_status.STOP && currentWaypoint == intersection.freeToRideWaypoint)
            {
             //   Debug.Log("not change bool of breaking");
                isBraking = false;
            }
            else
            {
                isBraking = false;
            }

        }
        else if (other.gameObject.tag == "T_Intersection_Two")
        {
            T_Intersection intersection = other.gameObject.GetComponent<T_Intersection>();
            print(intersection.name + " " + intersection.car_status);
            print(intersection.t_intersection_status.t_status + "   " + intersection.t_intersection_status_two.t_status);
            print(currentWaypoint);

            if (intersection.t_intersection_status.t_status == T_status.GO && intersection.t_intersection_status_two.t_status == T_status.GO && currentWaypoint == intersection.WaypointWhereYouCheckJustTwoSide)
            {
               // Debug.Log("two sides free and u check two sides");
                isBraking = false;
            }
            else if (intersection.t_intersection_status.t_status == T_status.STOP && intersection.t_intersection_status_two.t_status == T_status.STOP && currentWaypoint == intersection.WaypointWhereYouCheckJustTwoSide)
            {
               // Debug.Log("two sides occupied and u check two sides");
                isBraking = true;
            }
            else if (intersection.t_intersection_status.t_status == T_status.STOP && intersection.t_intersection_status_two.t_status == T_status.GO && currentWaypoint == intersection.WaypointWhereYouCheckJustTwoSide)
            {
                //Debug.Log("one side occupied but u must check two sides");
                isBraking = true;
            }
            else if (intersection.t_intersection_status.t_status == T_status.GO && intersection.t_intersection_status_two.t_status == T_status.STOP && currentWaypoint == intersection.WaypointWhereYouCheckJustTwoSide)
            {
               // Debug.Log("second side occupied but u must check two sides");
                isBraking = true;
            }
            //
            else if (intersection.t_intersection_status.t_status == T_status.GO && intersection.t_intersection_status_two.t_status == T_status.STOP && currentWaypoint == intersection.WaypointWhereYouCheckJustOneSide)

            {
                //Debug.Log("one side occupied but u must check one sides");
                isBraking = false;
            }
            else if (intersection.t_intersection_status.t_status == T_status.STOP && intersection.t_intersection_status_two.t_status == T_status.GO && currentWaypoint == intersection.WaypointWhereYouCheckJustOneSide)

            {
                //Debug.Log("second side occupied but u must check one sides");
                isBraking = true;
            }
            else if (intersection.t_intersection_status.t_status == T_status.STOP && intersection.t_intersection_status_two.t_status == T_status.STOP && currentWaypoint == intersection.WaypointWhereYouCheckJustOneSide)

            {
                //Debug.Log("two sides occupied and u check one sides");
                isBraking = true;
            }
            else if (intersection.t_intersection_status.t_status == T_status.GO && intersection.t_intersection_status_two.t_status == T_status.GO && currentWaypoint == intersection.WaypointWhereYouCheckJustOneSide)

            {
               // Debug.Log("two sides free and u check one sides");
                isBraking = false;
            }
            else
            {
                isBraking = false;
            }
        }
        //Sprawdzanie w jakim colliderze znajduje sie pojazd
        else if (other.gameObject.tag == "Lights")
        {
            //stowrzenie obiektu na podstawie odczytanego componentu danego collidera
            Intersection_Lights light = other.gameObject.GetComponent<Intersection_Lights>();
            Debug.Log(light.LightStatus);
            //jezeli status wynosi STOP to auto się zatrzymuje
            if (light.LightStatus == Status_Light.STOP)
            {
                isBraking = true;
              //  Debug.Log("Im in box collider for lights and lights are red");
            }
            //jezeli status wynosi GO auto jedzie dalej
            else if (light.LightStatus == Status_Light.GO)
            {
              //  Debug.Log("Im in box collider for lights and lights are green");
                isBraking = false;
            }
        }

        else if (other.gameObject.tag == "Roundabout")
        {
            /*
             Roundabout roundabout = other.gameObject.GetComponent<Roundabout>();
             Roads_waypoint element = other.gameObject.GetComponentInParent(typeof(Roads_waypoint)) as Roads_waypoint;
             Debug.Log("element" + element.transform.position);
             Vector3 other_position =  transform.position - element.transform.position;
             //Debug.Log("rondo" + Vector3.Dot(other_position, transform.forward));
             if (Vector3.Dot(transform.TransformDirection(Vector3.forward),other_position) > 0)
             {
                 Debug.Log("im in Roundabout");
                 if (roundabout.car_state == Roundabout_car_status.GO)
                 {
                     isBraking = false;
                 }
                 else if (roundabout.car_state == Roundabout_car_status.STOP)
                 {
                     isBraking = true;
                 }
             }
             else if (Vector3.Dot(other_position, transform.forward) < 0)
             {
                 Debug.Log("rondo opuszczam");
                 isBraking = false;
             }
            */
            Roundabout roundabout = other.gameObject.GetComponent<Roundabout>();
            Roads_waypoint element = other.gameObject.GetComponentInParent(typeof(Roads_waypoint)) as Roads_waypoint;
            float DistTemp = Vector3.Distance(element.transform.position, transform.position);
            if (DistTemp < dist)
            {
                Debug.Log("im in Roundabout");
                if (roundabout.car_state == Roundabout_car_status.GO)
                {
                    isBraking = false;
                }
                else if (roundabout.car_state == Roundabout_car_status.STOP)
                {
                    isBraking = true;
                }
                dist = DistTemp;
            }
            else if (DistTemp > dist)
            {
                Debug.Log("Im leaving");
                dist = DistTemp;
                isBraking = false;
            }
        }
    }
    
}
