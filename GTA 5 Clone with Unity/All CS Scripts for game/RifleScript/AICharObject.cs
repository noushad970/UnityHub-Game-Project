using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AICharObject : MonoBehaviour
{
    public float objectHealth = 120f;
    public Animator animator;
    public CharacterNavigatorScript AIchar;
    public PLayer player;

    [Header("Rifle Sound")]
    public GunSound AIcharSound;

    private void Update()
    {
        player = GameObject.FindObjectOfType<PLayer>();
    }
    public void ObjectHitDamage(float damage)
    {
        objectHealth -= damage;
        if (objectHealth <= 0)
        {
            Die();

        }
        
            AIcharSound.PlayhitHumanSound();
    }
    void Die()
    {
        AIcharSound.PlayDeathHuman();
        Destroy(gameObject, 3f);
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        player.currentKills += 1;
        animator.SetBool("Die", true);
        AIchar.movingSpeed = 0f;
        player.playerMoney += 10;


    }

    public static implicit operator AICharObject(TMP_Text v)
    {
        throw new NotImplementedException();
    }
}
