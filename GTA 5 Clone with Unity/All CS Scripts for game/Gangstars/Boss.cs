using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Boss : MonoBehaviour
{
    float bossHealth = 200;
    public Animator animator;
    public PLayer player;
    public Missions missions;

    private void Update()
    {
        if(bossHealth<200)
        {
            animator.SetBool("Shoot", true);
        }
        if (bossHealth < 0)
        {
            Object.Destroy(gameObject,4.0f);
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
            animator.SetBool("Shoot", false);
            animator.SetBool("Sleep", true);
            //mission 4 completation
            if (missions.mission1 == true && missions.mission3 == true && missions.mission2 == true)
            {
                missions.mission4 = true;
                player.playerMoney += 2000;
            }
        }
    }

    public void characterHitDamage(float takeDamage)
    {
        bossHealth -= takeDamage;
    }

}
