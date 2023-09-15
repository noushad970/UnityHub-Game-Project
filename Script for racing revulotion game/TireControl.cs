using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TireControl : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed at which the tire rotates

    private Transform tireTransform;

    private void Start()
    {
        tireTransform = transform;
    }

    public void RotateTire(float rotationAmount)
    {
        tireTransform.Rotate(Vector3.forward, rotationAmount);
    }
}
