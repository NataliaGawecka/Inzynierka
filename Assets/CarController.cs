using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentbreakForce;
    private bool isBreaking;
    private float currentSteerAngle;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider  WheelFL;
    [SerializeField] private WheelCollider WheelFR;
    [SerializeField] private WheelCollider WheelBL;
    [SerializeField] private WheelCollider WheelBR;



    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;
    private void FixedUpdate()
    {
        GetInput();
        // HandleMotor();
        // HandleSteering();
        //UpdateWheels();
        MoveCar();
    }

    /*(  private void UpdateWheels()
      {
          UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
          UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
          UpdateSingleWheel(backLeftWheelCollider, backLeftWheelTransform);
          UpdateSingleWheel(backRightWheelCollider, backRightWheelTransform);
      }

      private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
      {
          Vector3 pos;
          Quaternion rot;
          wheelCollider.GetWorldPose(out pos, out rot);
          wheelTransform.rotation = rot;
          wheelTransform.position = pos;

      }
    */

    /*private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();

    }
    */
    private void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isBreaking = Input.GetKey(KeyCode.Space);
    }
    private void MoveCar()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        WheelFL.steerAngle = currentSteerAngle;
        WheelFR.steerAngle = currentSteerAngle;

        WheelFL.motorTorque = verticalInput * motorForce;
        WheelFR.motorTorque = verticalInput * motorForce;

        if (isBreaking)
        {

            WheelFL.brakeTorque = currentbreakForce;
            WheelFR.brakeTorque = currentbreakForce;
            WheelBL.brakeTorque = currentbreakForce;
            WheelBR.brakeTorque = currentbreakForce;
        }
    }
  /*  private void ApplyBreaking()
    {
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        backLeftWheelCollider.brakeTorque = currentbreakForce;
        backRightWheelCollider.brakeTorque = currentbreakForce;
    }
  */
  
}

