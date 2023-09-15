using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSound : MonoBehaviour
{
    //private CarControl carControl;
    private AudioSource boostSound;
    public AudioClip boostsound;

    // Start is called before the first frame update
    void Start()
    {
        boostSound = GetComponent<AudioSource>();
        boostSound.clip = boostsound;
       // carControl = GetComponent<CarControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Boostsound();
    }
    void Boostsound()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            boostSound.Play();
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            boostSound.Stop();
        }
    }
}
