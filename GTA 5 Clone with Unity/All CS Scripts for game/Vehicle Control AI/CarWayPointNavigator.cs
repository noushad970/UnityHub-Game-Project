using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWayPointNavigator : MonoBehaviour
{
    [Header("Car AI")]
    public CarNevigator car;
    public WayPoint currentWaypoint;
    private void Awake()
    {
        car= GetComponent<CarNevigator>();
    }
    private void Start()
    {
        car.LocateDestination(currentWaypoint.GetPosition());
    }
    private void Update()
    {
        if(car.destinationReached)
        {
            currentWaypoint = currentWaypoint.nextWayPoint;
            car.LocateDestination(currentWaypoint.GetPosition()); 
        }
    }
}
