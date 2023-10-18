using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapScript : MonoBehaviour
{
    //map follow the player position
    public Transform player;
    public Transform Car;
   
    public VehicleControl vehiclecontrol;
    public PlayerController playercontroller;

    private void LateUpdate()
    {
        if(vehiclecontrol.isOpen)
        {
            Vector3 newposition = player.position;
            newposition.y = transform.position.y;
            transform.position = newposition;

            transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
        }
        if(!vehiclecontrol.isOpen)
        {
            Vector3 newposition = Car.position;
            newposition.y = transform.position.y;
            transform.position = newposition;

            transform.rotation = Quaternion.Euler(90f, Car.eulerAngles.y, 0f);
        }
    }
}
