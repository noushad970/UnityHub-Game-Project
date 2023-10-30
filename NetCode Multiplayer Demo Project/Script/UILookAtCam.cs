using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAtCam : MonoBehaviour
{
   

    // Update is called once per frame
    void lateUpdate()
    {
        transform.LookAt(transform.position+Camera.main.transform.forward);
    }
}
