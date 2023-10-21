using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarNevigator : MonoBehaviour
{

    [Header("Car Info")]
    public float movingSpeed;
    public float turningSpeed = 300f;
    public float stopSpeed = 1f;
    public GameObject sensor;
    float detectionRange = 10f;
    


    [Header("Destination Var")]
    public Vector3 destination;
    public bool destinationReached;
    public PLayer player;
    void Update()
    {
        RaycastHit hitinfo;
        if(Physics.Raycast(sensor.transform.position,sensor.transform.forward,out hitinfo,detectionRange))
        {
            Debug.Log(hitinfo.transform.name);
            CharacterNavigatorScript characterNPC=hitinfo.transform.GetComponent<CharacterNavigatorScript>();
            PLayer playerBody=hitinfo.transform.GetComponent<PLayer>();
            if(characterNPC!=null)
            {
                movingSpeed = 0f;
                return;
            }
            else if(playerBody!=null)
            {
                movingSpeed = 0f;
                return;
            }

        }

        Drive();


    }

    public void Drive()
    {
        movingSpeed = 6f;
        if (transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position; ;
            destinationDirection.y = 0;
            float destinationDistance = destinationDirection.magnitude;

            if (destinationDistance >= stopSpeed)
            {
                //turning
                destinationReached = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turningSpeed * Time.deltaTime);

                //Move AI

                transform.Translate(Vector3.forward * movingSpeed * Time.deltaTime);
            }

            else
            {
                destinationReached = true;
            }
        }



    }

    

    public void LocateDestination(Vector3 destination)
    {
        this.destination = destination;
        destinationReached = false;
    }

    //ai car sound

    
}
