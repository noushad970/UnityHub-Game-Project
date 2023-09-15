using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeControl : MonoBehaviour
{
    public float acceleration = 10f; // The acceleration of the car
    public float deceleration = 10f; // The deceleration of the car
    public float maxSpeed = 50f; // The maximum speed of the car
    public float rotationSpeed = 100f; // The rotation speed of the car
    public float brakeForce = 20f; // The force applied when braking
    public float gravity = 1f; // The gravity applied to the car
    public float boostMultiplier = 2f; // The speed multiplier when boosting

    private float currentSpeed = 0f; // The current speed of the car
    private bool isBoosting = false;


    public AudioClip musicClip1; // The audio clip to be played
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = musicClip1;
       
    }
    //void FixedUpdate()
    //{
    //    if (!braked)
    //    {
    //        WheelFL.brakeTorque = 0;
    //        WheelFR.brakeTorque = 0;
    //        WheelRL.brakeTorque = 0;
    //        WheelRR.brakeTorque = 0;
    //    }
    //    //speed of car, Car will move as you will provide the input to it.

    //    WheelRR.motorTorque = maxTorque * Input.GetAxis("Vertical");
    //    WheelRL.motorTorque = maxTorque * Input.GetAxis("Vertical");

    //    //changing car direction
    //   // Here we are changing the steer angle of the front tyres of the car so that we can change the car direction.
    //    WheelFL.steerAngle = 30 * (Input.GetAxis("Horizontal"));
    //    WheelFR.steerAngle = 30 * Input.GetAxis("Horizontal");
    //}


    void Update()
    {
       // float inputVertical = Input.GetAxis("Vertical"); // Get the input for acceleration or deceleration
        float inputHorizontal = Input.GetAxis("Horizontal"); // Get the input for rotation
        bool isBraking = Input.GetKey(KeyCode.Space); // Check if the brake key is pressed

        // Apply acceleration or deceleration based on the input
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Accelerate the car
            currentSpeed += acceleration * Time.deltaTime;

            // Clamp the speed to the maximum speed
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);

            // Check if boost key is pressed
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isBoosting = true;
            }
            // Check if boost key is released
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isBoosting = false;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            // Decelerate the car
            currentSpeed -= deceleration * Time.deltaTime;

            // Clamp the speed to zero
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);
        }

        // Rotate the car based on the input
        transform.Rotate(Vector3.up * inputHorizontal * rotationSpeed * Time.deltaTime);

        // Apply braking force if the brake key is pressed
        if (isBraking)
        {
            currentSpeed -= brakeForce * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxSpeed);
        }

        // Apply gravity
       // currentSpeed -= gravity * Time.deltaTime;

        // Apply boost multiplier if currently boosting
       
        currentSpeed -= gravity * Time.deltaTime;
        // Move the car forward based on the current speed
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
        // Apply gravity
        if(Input.GetKeyDown(KeyCode.UpArrow)) { 
        audioSource.Play();
        }
      

        // Move the car forward based on the current speed
       // transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

    }
}
