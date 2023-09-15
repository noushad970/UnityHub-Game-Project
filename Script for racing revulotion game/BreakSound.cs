using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakSound : MonoBehaviour
{
    private CarControl carControl;
    private AudioSource brakeSound;
    public AudioClip breakSound;
    
    // Start is called before the first frame update
    void Awake()
    {
        brakeSound= GetComponent<AudioSource>();
        brakeSound.clip = breakSound;
        carControl = GetComponent<CarControl>();
    }
    

    // Update is called once per frame
    void Update()
    {
       playBrake();
    }
    void playBrake()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            brakeSound.Play();
        }
    }
}
