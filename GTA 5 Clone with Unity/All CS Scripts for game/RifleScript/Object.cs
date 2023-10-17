using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Object : MonoBehaviour
{
    public float objectHealth = 120f;
    public Animator animator;
    public CharacterNavigatorScript AIchar;
    public void ObjectHitDamage(float damage)
    {
        objectHealth -= damage;
        if(objectHealth <= 0 ) {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject,3f);
        animator.SetBool("Die", true);
        AIchar.movingSpeed = 0f;
    }

    public static implicit operator Object(TMP_Text v)
    {
        throw new NotImplementedException();
    }
}
