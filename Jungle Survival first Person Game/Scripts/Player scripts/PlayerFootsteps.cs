using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    private AudioSource footstep_sound;
    [SerializeField]
    private AudioClip[] footstep_clip;

    private CharacterController characterController;

    [HideInInspector]
    public float volume_min,volume_max;
    private float acumulate_distance;

    [HideInInspector]
    public float step_distance;

    
    // Start is called before the first frame update
    void Awake()
    {
        footstep_sound = GetComponent<AudioSource>();
        characterController = GetComponentInParent<CharacterController>();
    }

    
    // Update is called once per frame
    void Update()
    {
        checkToPlayFootStepSound();
    }


    void checkToPlayFootStepSound()
    {
        if(!characterController.isGrounded)
        { return; }
        if(characterController.velocity.sqrMagnitude>0 )
        {
            acumulate_distance += Time.deltaTime;

            if (acumulate_distance > step_distance)
            {
                footstep_sound.volume = Random.Range(volume_min, volume_max);
                footstep_sound.clip = footstep_clip[Random.Range(0, footstep_clip.Length)];
                footstep_sound.Play();

                acumulate_distance = 0f;
            }


        }
        else
            acumulate_distance = 0f;


    }




}
