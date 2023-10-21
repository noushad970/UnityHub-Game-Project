using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [Header("Wheel Collider")]
    public WheelCollider frontRightWheelCollider;
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider BackRightWheelCollider;
    public WheelCollider BackLeftWheelCollider;

    [Header("Wheel Transform")]
    public Transform frontRightWheelTransform;
    public Transform frontLeftWheelTransform;
    public Transform BackRightWheelTransform;
    public Transform BackLeftWheelTransform;
    public Transform VehicleDoor;

    [Header("Vehicle Engine")]
    public float AccelerationForce = 100f;
    private float presentAcceleration = 0f;
    public float breakingForce = 200f;
    float presentBreakForce = 0f;
    public GameObject CarCam;

    [Header("Vehicle Security")]
    public PlayerController player;
    private float radius =5f;
    private bool isOpen = false;


    [Header("Disable Thing")]
    public GameObject AimCam;
    public GameObject CrossHair;
    public GameObject ThirdPerson;
    public GameObject PlayerCharacter;
    public GameObject thirdPersonCar;


    [Header("Vehicle Steering")]
    public float wheelsTorque=20f;
    private float presentTurnAngle = 0f;

    [Header("AudioSystem")]
    public soundSystem soundsystem;
    bool PlayBreakSoundSpeedLimit=false;
    bool engineStart=false;

    [HideInInspector]
    public bool playAccelerationSound;
    public bool playengineStartSound;
    public bool playBrakeSound;
    public bool playhorn;
    public bool playIdealCarsound;
    [HideInInspector]
    public int i = 0;

    private void Update()
    {
        //this if condition satisfy that the player is in the radius of the car which is 3f.that
        //mean if the player is closer to the car under 3f distance this condition will work
        if(Vector3.Distance(transform.position,player.transform.position) <= radius)
        {
            if(Input.GetKey(KeyCode.E))
            {
                isOpen = true;
                radius = 5000f;
                PlayerCharacter.SetActive(false);
                playengineStartSound = true;
                i = 1;
                
                
            }
            else if(Input.GetKey(KeyCode.O))
            {
                player.transform.position = VehicleDoor.transform.position;
                isOpen=false;
                radius = 5f;
                PlayerCharacter.SetActive(true);
                engineStart = false;
                playengineStartSound=false;
                i = 0;

            }
            
            if(Input.GetKey(KeyCode.RightShift) && isOpen==true)
            {
              playhorn = true;
            }
            else
                playhorn=false;
            
        }
        if (isOpen == true)
        {
            ThirdPerson.SetActive(false);
            AimCam.SetActive(false);
            CrossHair.SetActive(false);
            CarCam.SetActive(true);
            thirdPersonCar.SetActive(true);
            //soundSystem
           // soundsystem.PlayCarEngieStartSound();
            moveVehicle();
            VehicleSteering();
            applyBreaks();
            playIdealCarsound = true;
        }
        else if(isOpen==false)
        {
            ThirdPerson.SetActive(true);
            AimCam.SetActive(true);
            CrossHair.SetActive(true);
            CarCam.SetActive(false);
            thirdPersonCar.SetActive(false);
            playIdealCarsound=false;
        }


    }

    void moveVehicle()
    {
        frontRightWheelCollider.motorTorque = presentAcceleration;
        frontLeftWheelCollider.motorTorque = presentAcceleration;
        BackRightWheelCollider.motorTorque = presentAcceleration;
        BackLeftWheelCollider.motorTorque = presentAcceleration;

        presentAcceleration = AccelerationForce * Input.GetAxis("Vertical");
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) && isOpen == true)
        {
           playAccelerationSound = true;
        }
        else { playAccelerationSound = false; }
    }

    void VehicleSteering()
    {
        presentTurnAngle = wheelsTorque * Input.GetAxis("Horizontal");

        frontRightWheelCollider.steerAngle = presentTurnAngle;
        frontLeftWheelCollider.steerAngle = presentTurnAngle;

        SteeringWheels(frontRightWheelCollider, frontRightWheelTransform);
        SteeringWheels(frontLeftWheelCollider, frontLeftWheelTransform); ;
        SteeringWheels(BackRightWheelCollider, BackRightWheelTransform);
        SteeringWheels(BackLeftWheelCollider, BackLeftWheelTransform);
    }

    void SteeringWheels(WheelCollider WC,Transform WT)
    {
        Vector3 position;
        Quaternion rotation;

        WC.GetWorldPose(out position, out rotation);

        WT.position=position; 
        WT.rotation = rotation;
    }

    void applyBreaks()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            presentBreakForce = breakingForce;
            if (presentAcceleration > 70)
            {
                PlayBreakSoundSpeedLimit = true;
            }
            else
                PlayBreakSoundSpeedLimit=false; 
            if(PlayBreakSoundSpeedLimit)
            {
                playBrakeSound = true;
            }
            else
                playBrakeSound=false;
            
        }
        else
            presentBreakForce = 0f;

        frontRightWheelCollider.brakeTorque = presentBreakForce;
        frontLeftWheelCollider.brakeTorque = presentBreakForce;
        BackRightWheelCollider.brakeTorque = presentBreakForce;
        BackLeftWheelCollider.brakeTorque = presentBreakForce;
    }

}
