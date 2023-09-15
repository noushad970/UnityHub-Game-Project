using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5f;

    private void LateUpdate()
    {
        // Smoothly interpolate position and rotation
        transform.position = Vector3.Lerp(transform.position, target.position, smoothSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, smoothSpeed * Time.deltaTime);
    }
}
