using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour
{



    public float maxSteerAngle = 45f;
    private List<Waypoint> nodes;
    public Waypoint currentNode;

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


    [Header("Sensors")]
    public float sensorLenght = 10f;
    public float frontSensorPosition = 0.5f;
    public float frontsideSensorPosition = 0.3f;


    private void Start()
    {

        GetComponent<Rigidbody>().centerOfMass = centerOfMass;



    }


    void FixedUpdate()
    {

        try
        {
            Sensors();
            checkDistance();
            ApplySteer();

        }
        catch { }

    }

    private bool Sensors()
    {
        RaycastHit hit;
        Vector3 sensorStartPos = transform.position;
        sensorStartPos.z += frontSensorPosition;
        sensorStartPos.y = 0.5f + sensorStartPos.y;

        //front center sensor
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensorLenght))
        {
            Debug.DrawLine(sensorStartPos, hit.point);

            if (hit.collider.gameObject.CompareTag("Car"))
            {
                Debug.Log("stop because of car");
                return true;
            }

        }
        return false;
    }

    void checkDistance()
    {

        if (Vector3.Distance(transform.position, currentNode.transform.position) <= 1)
        {
            reachedDestination();
        }


    }


    private void reachedDestination()
    {
        if (currentNode.nextWaypoint == null)
        {
            isBraking = true;
            return;
        }

        if (currentNode.link != null && currentNode.link_nr2 == null && Random.Range(0, 100) <= 50)
            currentNode = currentNode.link;
        else if (currentNode.link != null && currentNode.link_nr2 != null && Random.Range(0, 300) < 100)
            currentNode = currentNode.link;
        else if (currentNode.link != null && currentNode.link_nr2 != null && Random.Range(0, 300) > 100 && Random.Range(0, 300) < 200)
            currentNode = currentNode.link_nr2;
        else
            currentNode = currentNode.nextWaypoint;


    }


    private void ApplySteer()
    {

        Vector3 relativeVector = transform.InverseTransformPoint(currentNode.transform.position);

        float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;

        currentSpeed = 2 * Mathf.PI * wheelFL.radius * wheelFL.rpm * 60 / 1000;


        wheelFL.steerAngle = newSteer;
        wheelFR.steerAngle = newSteer;

        Debug.Log("brakes" + wheelRL.brakeTorque);
        if (isBraking == false && Sensors() == false)
        {
            Debug.Log("is NOT breaking in function Apply Steer");
            wheelRL.brakeTorque = 0;
            wheelRR.brakeTorque = 0;


            if (currentSpeed < maxSpeed)
            {
                wheelFL.motorTorque = maxMotorTorque;
                wheelFR.motorTorque = maxMotorTorque;
            }
           else if(currentSpeed >= maxSpeed)
            {
                wheelFL.motorTorque = 0;
                wheelFR.motorTorque = 0;
            }

        }
       else  if (isBraking == false && Sensors() == true)
        {
            wheelRL.brakeTorque = currentSpeed * maxBrakeTorque;
            wheelRR.brakeTorque = currentSpeed * maxBrakeTorque;
        }


        else if (isBraking == true)
        {
            Debug.Log("is breaking in function Apply Steer");
            Debug.Log("brakes true" + wheelRL.brakeTorque);
            wheelRL.brakeTorque = currentSpeed * maxBrakeTorque;
            wheelRR.brakeTorque = currentSpeed * maxBrakeTorque;
            //maxSpeed = 50.0f;

        }





    }

    
    void OnTriggerStay(Collider other)
    {
        //Debug.Log("On trigger");

        if (other.gameObject.tag == "T_Intersection")
        {

            T_Intersection intersection = other.gameObject.GetComponent<T_Intersection>();
            //Debug.Log(intersection.car_status + " " + gameObject.name);

            if (intersection.car_status == Car_status.STOP && currentNode != intersection.freeToRideWaypoint)
            {
                Debug.Log("change bool of breaking");
                isBraking = true;
                // print(isBraking);

                //  Braking();


            }
            else if (intersection.car_status == Car_status.STOP && currentNode == intersection.freeToRideWaypoint)
            {
                Debug.Log("not change bool of breaking");
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
            print(currentNode);

            if (intersection.t_intersection_status.t_status == T_status.GO && intersection.t_intersection_status_two.t_status == T_status.GO && currentNode == intersection.WaypointWhereYouCheckJustTwoSide)
            {
                Debug.Log("two sides free and u check two sides");
                isBraking = false;
            }
            else if (intersection.t_intersection_status.t_status == T_status.STOP && intersection.t_intersection_status_two.t_status == T_status.STOP && currentNode == intersection.WaypointWhereYouCheckJustTwoSide)

            {
                Debug.Log("two sides occupied and u check two sides");
                isBraking = true;

            }
            else if (intersection.t_intersection_status.t_status == T_status.STOP && intersection.t_intersection_status_two.t_status == T_status.GO && currentNode == intersection.WaypointWhereYouCheckJustTwoSide)

            {
                Debug.Log("one side occupied but u must check two sides");
                isBraking = true;

            }
            else if (intersection.t_intersection_status.t_status == T_status.GO && intersection.t_intersection_status_two.t_status == T_status.STOP && currentNode == intersection.WaypointWhereYouCheckJustTwoSide)

            {
                Debug.Log("second side occupied but u must check two sides");
                isBraking = true;

            }
            //
            else if (intersection.t_intersection_status.t_status == T_status.GO && intersection.t_intersection_status_two.t_status == T_status.STOP && currentNode == intersection.WaypointWhereYouCheckJustOneSide)

            {
                Debug.Log("one side occupied but u must check one sides");
                isBraking = false;
            }
            else if (intersection.t_intersection_status.t_status == T_status.STOP && intersection.t_intersection_status_two.t_status == T_status.GO && currentNode == intersection.WaypointWhereYouCheckJustOneSide)

            {
                Debug.Log("second side occupied but u must check one sides");
                isBraking = true;
            }
            else if (intersection.t_intersection_status.t_status == T_status.STOP && intersection.t_intersection_status_two.t_status == T_status.STOP && currentNode == intersection.WaypointWhereYouCheckJustOneSide)

            {
                Debug.Log("two sides occupied and u check one sides");
                isBraking = true;
            }
            else if (intersection.t_intersection_status.t_status == T_status.GO && intersection.t_intersection_status_two.t_status == T_status.GO && currentNode == intersection.WaypointWhereYouCheckJustOneSide)

            {
                Debug.Log("two sides free and u check one sides");
                isBraking = false;
            }
            else
            {
                isBraking = false;
            }
        }
        
        else if (other.gameObject.tag == "Lights")
        {
            Intersection_Lights light = other.gameObject.GetComponent<Intersection_Lights>();
            Debug.Log(light.LightStatus);
            if (light.LightStatus == Status_Light.STOP)
            {
                isBraking = true;
                Debug.Log("Im in box collider for lights and lights are red");
            }
            else if (light.LightStatus == Status_Light.GO)
            {
                Debug.Log("Im in box collider for lights and lights are green");
                isBraking = false;
            }
        }
        
        else if (other.gameObject.tag == "Roundabout")
        {
            Debug.Log("im in Roundabout");
            Roundabout roundabout = other.gameObject.GetComponent<Roundabout>();
            if (roundabout.car_state == Roundabout_car_status.GO)
            {
                isBraking = false;
            }
            else if (roundabout.car_state == Roundabout_car_status.STOP)
            {
                isBraking = true;
            }
        }
    }
    
}
