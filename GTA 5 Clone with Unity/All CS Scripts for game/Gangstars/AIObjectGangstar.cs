using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AIObjectGangstar : MonoBehaviour
{
    public float objectHealth = 120f;
    public Animator animator;
    public Gangstar1 AIcharacter;
    public PLayer player;

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
    }
    void Die()
    {
        Destroy(gameObject, 3f);
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        player.currentKills += 1;
        animator.SetBool("Die", true);
        AIcharacter.movingSpeed = 0f;
        player.playerMoney += 10;


    }

    public static implicit operator AIObjectGangstar(TMP_Text v)
    {
        throw new NotImplementedException();
    }
}
