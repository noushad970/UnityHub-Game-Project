using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyAudio : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip Scream_clip, Die_Clip;
    [SerializeField]
    private AudioClip[] Attack_clip;

    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PLay_Scream_Sound()
    {
        audioSource.clip = Scream_clip;
        audioSource.Play();
    }
    public void Attack_sound()
    {
        audioSource.clip = Attack_clip[UnityEngine.Random.Range(0, Attack_clip.Length)];
        audioSource.Play();
    }
    public void PLay_Dead_Sound()
    {
        audioSource.clip = Die_Clip;
        audioSource.Play();
    }
}
