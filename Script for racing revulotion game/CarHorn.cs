using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHorn : MonoBehaviour
{
    public AudioClip musicClip2; // The audio clip to be played
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musicClip2;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else if (Input.GetKeyUp(KeyCode.RightShift))
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
