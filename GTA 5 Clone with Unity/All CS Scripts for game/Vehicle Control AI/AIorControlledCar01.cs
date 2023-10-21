using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIorControlledCar01 : MonoBehaviour
{
    public AICarController01 carController01;
    public CarNevigator carNevigator;
    public CarWayPointNavigator wayPointNavigator;
    private void Update()
    {
        if(carController01.isOpen) { 
        carNevigator.enabled = false;
            wayPointNavigator.enabled = false;

        }
        if(!carController01.isOpen)
        {
            carNevigator.enabled=true;
            wayPointNavigator.enabled=true;
        }
    }
}
