using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIVehicleWheelcontrol : MonoBehaviour
{

    public float rotationSpeed = 10.0f; // Adjust the speed as needed

    public GameObject w1;
    public GameObject w2;
    public GameObject w3;
    public GameObject w4;
    void Update()
    {
        // Get the current rotation
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // Modify the rotation on the X-axis
        currentRotation.x += rotationSpeed ;

        // Apply the new rotation
        w1.transform.rotation = Quaternion.Euler(currentRotation);
        w2.transform.rotation = Quaternion.Euler(currentRotation);
        w3.transform.rotation = Quaternion.Euler(currentRotation);
        w4.transform.rotation = Quaternion.Euler(currentRotation);
        rotationSpeed+=30f;
        if (rotationSpeed >= 360)
            rotationSpeed = 0;
    }

}
