using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController character_Controller;
    private Vector3 Move_direction;
    public float speed = 4f;
    private float gravity = 20f;
    public float jumpforce = 10f;
    private float vertical_velocity;
    void Awake()
    {
        character_Controller = GetComponent<CharacterController>();        
    }
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();  
    }
    void MoveThePlayer()
    {
        Move_direction = new Vector3(Input.GetAxis(axis.Horizon), 0f , Input.GetAxis(axis.Verti));
        Move_direction = transform.TransformDirection(Move_direction);
        Move_direction *= speed*Time.deltaTime;
        ApplyGravity();
        character_Controller.Move(Move_direction);
    }
    void ApplyGravity()
    {
        if (character_Controller.isGrounded) {
        vertical_velocity-=gravity*Time.deltaTime;
            PlayerJump();
        
        }
        else
            vertical_velocity -= gravity * Time.deltaTime;
        Move_direction.y = vertical_velocity*Time.deltaTime;

    }
    void PlayerJump()
    {
        if(character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space)) { 
        vertical_velocity=jumpforce;
        }
    }

}










