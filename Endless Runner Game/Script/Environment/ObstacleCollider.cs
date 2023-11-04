using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollider : MonoBehaviour
{
    public GameObject theplayer;
    public GameObject charModel;
    public Animator animator;
    public GameObject mainCam;
    public bool hitSoundPlay=false;
    public AudioSource hitAudio;
    public GameObject ScoreEnd;
    public GameOver isOver;

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;    
        theplayer.GetComponent<PlayerController>().enabled = false;
        animator.SetBool("GameOver", true); 
        mainCam.GetComponent<Animator>().enabled = true;
        ScoreEnd.GetComponent<LevelDistance>().enabled = false;
        isOver.Gameover = true;
        
        hitAudio.Play(); 
    }
}
