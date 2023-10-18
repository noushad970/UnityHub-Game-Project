using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdealCarSound : MonoBehaviour
{

    public AudioClip IdealSound; // The audio clip to be played
    private AudioSource audioSource;
    public VehicleController vehicleController;
    

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //vehicleController = GetComponent<VehicleController>();

    }
    // Update is called once per frame
    void Update()
    {
        if(vehicleController.playIdealCarsound)
        {
            audioSource.clip = IdealSound;
            if (!audioSource.isPlaying)
                audioSource.Play();
            if (audioSource.isPlaying)
                return;
        }
    }
}
