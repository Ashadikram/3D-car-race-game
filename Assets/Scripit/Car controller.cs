using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carcontroller : MonoBehaviour
{
     public WheelCollider frontRightWheelCollider;
     public WheelCollider backRightWheelCollider;
     public WheelCollider frontLeftWheelCollider;
     public WheelCollider backLeftWheelCollider;
     
      public float motorForce = 100f;
      public float SteeringAngle = 30f;

    // Start is called before the first frame update
    public Transform frontRightWheelTransform;
     public Transform frontLeftWheelTransform;
      public Transform backRightWheelTransform;
       public Transform backLeftWheelTransform;

     float verticalInput;
     float horizontalInput;   
     public Transform carCenterOfMassTransform;
     public Rigidbody rigidbody;
      
    void Start()
    {
        rigidbody.centerOfMass = carCenterOfMassTransform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       motorTorque();
       UpdateWheel();
       GetInput();
       Steering();
       ApplyBrakes();
    }
    void GetInput(){
       verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }

    void ApplyBrakes(){

        if(Input.GetKey(KeyCode.Space)){

        frontRightWheelCollider.brakeTorque = 1000f;
        frontLeftWheelCollider.brakeTorque = 1000f;
        backLeftWheelCollider.brakeTorque = 1000f;
        backRightWheelCollider.brakeTorque = 1000f;

        }else{
        
        frontRightWheelCollider.brakeTorque = 0f;
        frontLeftWheelCollider.brakeTorque = 0f;
        backLeftWheelCollider.brakeTorque = 0f;
        backRightWheelCollider.brakeTorque = 0f;

        }

    }
    void motorTorque(){
        if(Input.GetKey(KeyCode.Q)){
         frontRightWheelCollider.motorTorque = 1000f*verticalInput;
         frontLeftWheelCollider.motorTorque = 1000f*verticalInput;
        }else{
        frontRightWheelCollider.motorTorque = motorForce*verticalInput;
         frontLeftWheelCollider.motorTorque = motorForce*verticalInput;
        }
    }

    void Steering(){
        
        frontRightWheelCollider.steerAngle = SteeringAngle*horizontalInput;
        frontLeftWheelCollider.steerAngle = SteeringAngle*horizontalInput;
    }
    void UpdateWheel(){
        RotateWheel(frontRightWheelCollider,frontRightWheelTransform);
        RotateWheel(backRightWheelCollider,backRightWheelTransform);
        RotateWheel(frontLeftWheelCollider,frontLeftWheelTransform);
        RotateWheel(backLeftWheelCollider,backLeftWheelTransform);
    }
    void RotateWheel(WheelCollider wheelCollider, Transform transform){
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos,out rot);
        transform.position = pos;
        transform.rotation = rot;
    }
    
}
