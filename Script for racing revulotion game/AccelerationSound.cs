using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationSound : MonoBehaviour
{
    private CarControl carControl;
    private AudioSource AccSound;
    public AudioClip accelerationSound;
    private float updateDelay = 1f; // Delay in seconds
    private float timer = 0f;
    // Start is called before the first frame update
    void Awake()
    {
        AccSound = GetComponent<AudioSource>();
        AccSound.clip = accelerationSound;
       // AccSound.loop = false;
        //carControl = GetComponent<CarControl>();
    }


    // Update is called once per frame
    void Update()
    {
        
            Accelerationsound();

         
        
    }
    void Accelerationsound()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (!AccSound.isPlaying)
            {
                AccSound.Play();
            }
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (AccSound.isPlaying)
            {
                AccSound.Stop();
            }
        }
    }
}
