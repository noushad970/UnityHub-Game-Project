using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAxeWoshSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] wooshSound;
    void playWoshSound()
    {
        audioSource.clip = wooshSound[Random.Range(0, wooshSound.Length)];
        audioSource.Play();
    }

}
