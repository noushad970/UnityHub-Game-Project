using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerMovement : NetworkBehaviour
{
    [SerializeField] private float movementSpeed = 7f;
    [SerializeField] private float rotationSpeed = 500f;
    private Animator animator;
    [SerializeField] private float positionRange = 5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void OnNetworkSpawn()
    {
        transform.position = new Vector3(Random.Range(positionRange, -positionRange), 0, Random.Range(positionRange, -positionRange));
        transform.rotation= new Quaternion(0,180,0,0);
    }
    private void Update()
    {
        if(!IsOwner) return;
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection= new Vector3 (horizontalInput, 0,verticalInput);
        movementDirection.Normalize();

        transform.Translate(movementDirection * movementSpeed * Time.deltaTime, Space.World);

        if(movementDirection!=Vector3.zero)
        {
            Quaternion toRotation=Quaternion.LookRotation(movementDirection,Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        animator.SetFloat("run", movementDirection.magnitude); 
    
    
    }

}
