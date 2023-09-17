using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintAndCrouch : MonoBehaviour
{
    private PlayerMovement playerMovement;

    public float sprint_speed = 8f;
    public float move_speed = 4f;
    public float crouch_speed = 1.5f;
    private Transform look_Root;
    private float stand_height = 1.6f;
    private float crouch_height = 1f;
    private bool is_Crouching;
    
    private PlayerFootsteps player_footsteps;
    private float sprint_volume = 1f;
    private float crouch_volume = 0.1f;
    private float walk_volume_min = 0.2f, walk_volume_max = 0.6f;
    private float walk_step_distance = 0.4f;
    private float sprint_step_distance = 0.25f;
    private float crouch_step_distance = 0.5f;

    private PlayerStates player_states;
    private float Sprint_Value = 100f;
    public float sprint_TresHold = 10f;

    void Awake()
    {
        playerMovement=GetComponent<PlayerMovement>();
        look_Root = transform.GetChild(0);
        player_footsteps = GetComponentInChildren<PlayerFootsteps>();
        player_states=GetComponent<PlayerStates>();
    }
    void Start()
    {
        player_footsteps.volume_min = walk_volume_min;
        player_footsteps.volume_max = walk_volume_max;
        player_footsteps.step_distance = walk_step_distance;
    }
    // Update is called once per frame
    void Update()
    {
        sprint();
        crouch();
    }
    void sprint()
    {
      if(Sprint_Value > 0f)
        {
            if (Input.GetKeyDown(KeyCode.RightShift) && !is_Crouching)
            {
                playerMovement.speed = sprint_speed;

                player_footsteps.step_distance = sprint_step_distance;
                player_footsteps.volume_min = sprint_volume;
                player_footsteps.volume_max = sprint_volume;
            }
        }
        if(Input.GetKeyUp(KeyCode.RightShift ) && !is_Crouching )
        {
            playerMovement.speed = move_speed;
            player_footsteps.step_distance = walk_step_distance;
            player_footsteps.volume_min = walk_volume_min;
            player_footsteps.volume_max = walk_volume_max;

        }
        if(Input.GetKey(KeyCode.RightShift ) && !is_Crouching && move_speed>0)
        {
            Sprint_Value -= sprint_TresHold*Time.deltaTime;
            if(Sprint_Value<=0f) {

                Sprint_Value=0f;

                playerMovement.speed = move_speed;

                player_footsteps.step_distance = walk_step_distance;
                player_footsteps.volume_min = walk_volume_min;
                player_footsteps.volume_max = walk_volume_max;

            }
            player_states.StaminaStates(sprint_volume);
            
        }
        else
        {
            if (Sprint_Value != 100f)
            {
                Sprint_Value += (sprint_TresHold / 2f) * Time.deltaTime;

                player_states.StaminaStates(sprint_volume);
                if (Sprint_Value > 100f)
                {
                    Sprint_Value = 100f;
                }

            }
        }


    }
    void crouch()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (is_Crouching)
            {
                look_Root.localPosition = new Vector3(0f, stand_height, 0f);
                playerMovement.speed = move_speed;

                player_footsteps.step_distance = walk_step_distance;
                player_footsteps.volume_min = walk_volume_min;
                player_footsteps.volume_max = walk_volume_max;

                is_Crouching = false;
            }
            else
            {
                look_Root.localPosition = new Vector3(0f, crouch_height, 0f);
                playerMovement.speed = crouch_speed;

                player_footsteps.step_distance = crouch_step_distance;
                player_footsteps.volume_min = crouch_volume;
                player_footsteps.volume_max = crouch_volume;


                is_Crouching = true;


            }
        }

    }
}

