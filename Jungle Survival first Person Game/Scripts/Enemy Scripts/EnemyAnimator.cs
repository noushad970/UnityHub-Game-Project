using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void walk(bool walk)
    {
        anim.SetBool(animationTag.Walk_Parameter,walk);
    }
    public void Run(bool Run)
    {
        anim.SetBool(animationTag.Run_Parameter, Run);
    }

    public void Attack()
    {
        anim.SetTrigger(animationTag.Attack_Trigger);
    }

    public void Dead()
    {
        anim.SetTrigger(animationTag.Dead_trigger);
    }




}
