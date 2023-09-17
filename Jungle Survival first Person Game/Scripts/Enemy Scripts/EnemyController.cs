using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyState
{
    PATROL,
    CHASE,
    ATTACK
}

public class EnemyController : MonoBehaviour
{
    private EnemyAnimator Enemy_Animator;
    private NavMeshAgent navAgent;

    private EnemyState enemy_State;

    public float Walk_Speed = 0.5f;
    public float Run_Speed = 4f;
    public float chase_distance = 7f;
    private float Current_Chase_Distance;
    public float Attack_Distance=1.8f;
    public float chase_After_Attack_Distance=2f;
    public float patrol_Radius_Min = 20f, patrol_Radius_Max = 60f;
    public float patrol_for_this_time = 15f;
    private float patrol_timer;

    public float Wait_Before_attack=2f;
    private float Attack_timer;
    private Transform target;
    public GameObject attack_point;
    private EnemyAudio enemy_Audio;





    // Start is called before the first frame update
    void Awake()
    {
        Enemy_Animator = GetComponent<EnemyAnimator>();
        navAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindWithTag(Tags.Player_Tag).transform;
        enemy_Audio = GetComponentInChildren<EnemyAudio>();
    }

    void Start()
    {
         enemy_State= EnemyState.PATROL;
        patrol_timer = patrol_for_this_time;

        Attack_timer = Wait_Before_attack;
        Current_Chase_Distance = chase_distance;  
    }
    // Update is called once per frame
    void Update()
    {
        if(enemy_State == EnemyState.PATROL)
        {
            patrol();
        }
        if(enemy_State == EnemyState.CHASE)
        {
            chase();
        }
        if(enemy_State ==EnemyState.ATTACK)
        {
            attack();
        }
    }

    void patrol() { 
    navAgent.isStopped = false;
    navAgent.speed = Walk_Speed;

        patrol_timer += Time.deltaTime;
        if (patrol_timer > patrol_for_this_time)
        {
            SetNewRandomDestination();
            patrol_timer = 0f;
        }
        if(navAgent.velocity.sqrMagnitude > 0)
        {
            Enemy_Animator.walk(true);
        }
        else
        {
            Enemy_Animator.walk(false);
        }
        if(Vector3.Distance(transform.position,target.position)<=chase_distance)
        {
            Enemy_Animator.walk(false );
            enemy_State = EnemyState.CHASE;

            enemy_Audio.PLay_Scream_Sound();
        }
    }
    
    void chase() {
        navAgent.isStopped = false;
        navAgent.speed = Run_Speed;
        navAgent.SetDestination(target.position);

        if (navAgent.velocity.sqrMagnitude > 0)
        {
            Enemy_Animator.Run(true);
        }
        else
        {
            Enemy_Animator.Run(false);
        }

        if (Vector3.Distance(transform.position, target.position) <= Attack_Distance)
        {
            Enemy_Animator.Run(false);
            Enemy_Animator.walk(false);
            enemy_State = EnemyState.ATTACK;
            if(chase_distance!=Current_Chase_Distance)
            {
                chase_distance = Current_Chase_Distance;
            }
        }
        else if(Vector3.Distance(transform.position,target.position)>chase_distance)
        {
            Enemy_Animator.Run(false);
            enemy_State=EnemyState.PATROL;
            patrol_timer = patrol_for_this_time;
            if(chase_distance!=Current_Chase_Distance)
            {
                chase_distance = Current_Chase_Distance;
            }
        }
    }

    void attack()
    {
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;
        Attack_timer+=Time.deltaTime;
        if (Attack_timer > Wait_Before_attack)
        {
            Enemy_Animator.Attack();
            Attack_timer = 0f;
            //attack sound played
            enemy_Audio.Attack_sound();

        }
        if(Vector3.Distance(transform.position,target.position)>Attack_Distance+chase_After_Attack_Distance)
        {
            enemy_State = EnemyState.CHASE;
        }
    } 
    
    void SetNewRandomDestination()
    {
        float random_radius = Random.Range(patrol_Radius_Min, patrol_Radius_Max);
        Vector3 Randir = Random.insideUnitSphere * random_radius;
        Randir += transform.position;
        NavMeshHit NavHit;
        NavMesh.SamplePosition(Randir, out NavHit, random_radius, -1);
        navAgent.SetDestination(NavHit.position);
    }

    public void turn_on_AttackPoint()
    {
        attack_point.SetActive(true);
    }

    public void turn_off_AttackPoint()
    {
        if (attack_point.activeInHierarchy)
        {
            attack_point.SetActive(false);
        }
    }

    public EnemyState Enemy_State { get; set; }



}











