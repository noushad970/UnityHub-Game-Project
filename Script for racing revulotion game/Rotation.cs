using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 1f;
    
    public GameObject rotateobject;
    // Start is called before the first frame update
    void Awake()
    {
        
        rotateobject = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rotateobject.SetActive(true );
        rotateobject.transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
    }
}
