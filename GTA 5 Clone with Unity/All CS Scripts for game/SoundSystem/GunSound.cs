using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSound : MonoBehaviour
{
    public AudioClip handGunSound; // The audio clip to be played
    private AudioSource audioSource;
    public AudioClip UziGunSound;
    public AudioClip ShotGunSound;
    public AudioClip BasookaSound;
    public AudioClip reloadSound;
    public AudioClip hitMatelsound;
    public AudioClip hithumanSound;
    public AudioClip accelerationSound;
    public AudioClip hornSound;
    public AudioClip FootStepSound;
    public AudioClip humanInjuredSound;
    public AudioClip DeathSound;
    public AudioClip introMusic;
  //  public AudioClip CarIdealSound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    public void playHandGunSound()
    {
        audioSource.clip = handGunSound;
        if (!audioSource.isPlaying)
                audioSource.Play();
        if (audioSource.isPlaying)
            return;
    }
    public void playShotGunSound()
    {
        audioSource.clip = ShotGunSound;
        if (!audioSource.isPlaying)
            audioSource.Play();
        if (audioSource.isPlaying)
            return;

    }
    public void playUziGunSound()
    {
        audioSource.clip = UziGunSound;
        if (!audioSource.isPlaying)
        audioSource.Play();


        if (audioSource.isPlaying)
            audioSource.Play();
    }
    public void playBasookaSound()
    {

        audioSource.clip = BasookaSound;
        if (!audioSource.isPlaying)
            audioSource.Play();
        
        if (audioSource.isPlaying)
            audioSource.Play();
    }
    public void PlayreloadSound()
    {
        audioSource.clip = reloadSound;
        if (!audioSource.isPlaying)
            audioSource.Play();
        if (audioSource.isPlaying)
            audioSource.Play();
    }
    public void PlayhitMatelsound()
    {
        audioSource.clip = hithumanSound;
        if (!audioSource.isPlaying)
            audioSource.Play();
        if (audioSource.isPlaying)
            audioSource.Play();
    }
    public void PlayhitHumanSound()
    {
        audioSource.clip = hithumanSound;
        if (!audioSource.isPlaying)
            audioSource.Play();
        if (audioSource.isPlaying)
            audioSource.Play();
    }
    public void PlayInjuredHumanSound()
    {
        audioSource.clip = humanInjuredSound;
        if (!audioSource.isPlaying)
            audioSource.Play();
        if (audioSource.isPlaying)
            audioSource.Play();
    }
    public void PlayDeathHuman()
    {
        audioSource.clip = DeathSound;
        if (!audioSource.isPlaying)
            audioSource.Play();
        if (audioSource.isPlaying)
            audioSource.Play();
    }
    public void PlayAccelerationSound()
    {
        audioSource.clip = accelerationSound;
        if (!audioSource.isPlaying)
            audioSource.Play();
        if (audioSource.isPlaying)
            audioSource.Play();
    }
    public void PlayFootStepSound()
    {
        audioSource.clip = FootStepSound;
        if (!audioSource.isPlaying)
            audioSource.Play();
        if (audioSource.isPlaying)
            audioSource.Play();
    }
    public void PlayHornSound()
    {
        audioSource.clip = hornSound;
        if (!audioSource.isPlaying)
            audioSource.Play();
        if (audioSource.isPlaying)
            audioSource.Play();
    }

    public void playIntroSound()
    {
        audioSource.clip = introMusic;
        if (!audioSource.isPlaying)
            audioSource.Play();
        if (audioSource.isPlaying)
            return;

    }
    
}
