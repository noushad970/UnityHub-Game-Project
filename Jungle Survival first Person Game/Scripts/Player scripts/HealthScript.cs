using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class HealthScript : MonoBehaviour
{
    private EnemyAnimator enemyAnim;
    private NavMeshAgent Navmash;
    private EnemyController enemyController;

    public float Health = 100f;
    public bool is_player, is_Canimal, is_Boar;
    private bool is_dead;
    private EnemyAudio enemyAudio;

    private PlayerStates playerStates;
    // Start is called before the first frame update
    void Awake()
    {
        if (is_Boar || is_Canimal)
        {
            enemyAnim = GetComponent<EnemyAnimator>();
            enemyController = GetComponent<EnemyController>();
            Navmash = GetComponent<NavMeshAgent>();
            enemyAudio = GetComponentInChildren<EnemyAudio>();
            //get enemy audio;
        }
        if (is_player)
        {
            playerStates = GetComponent<PlayerStates>();
        }



    }

    public void ApplyDamage(float damage){
        
        if(is_dead)
        { return; }
        Health-= damage;
        if (is_player)
        {
            playerStates.HealthStates(Health);
        }
        if (is_Boar || is_Canimal)
        {
            if(enemyController.Enemy_State==EnemyState.PATROL)
            {
                enemyController.chase_distance = 50f;
            }
        }
        if(Health<=0f)
        {
            Player_Died();
            is_dead = true;

        }
     }
    void Player_Died()
    {
        if (is_Canimal)
        {

            GetComponent<Animator>().enabled = false;
            GetComponent<BoxCollider>().isTrigger = false;
            GetComponent<Rigidbody>().AddTorque(-transform.forward * 5f);
            enemyController.enabled = false;
            Navmash.enabled = false;
            enemyAnim.enabled = false;
           // gameObject.IsDestroyed();
            //start coroutine
            StartCoroutine(DeadSound());
            //enemymanager spawn more enemy
            EnemyManager.instance.EnemyDied(true);
        }
        if (is_Boar)
        {
            Navmash.velocity = Vector3.zero;
            Navmash.isStopped = true;
            enemyController.enabled=false;

            enemyAnim.Dead();
            
            //start coroutine
            StartCoroutine(DeadSound());
            //enemymanager spawn more enemy

            EnemyManager.instance.EnemyDied(false);
        }
        if (is_player)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.Enemy_Tag);
            for(int i=0;i<enemies.Length;i++)
            {
                enemies[i].GetComponent<EnemyController>().enabled = false;
            }
            EnemyManager.instance.StopSpawning();
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<WeaponManager>().GetCurrentSelectedWeapon().gameObject.SetActive(false);

        }
        if(tag==Tags.Player_Tag)
        {
            Invoke("RestartGame", 3f);
        }
        else
        {
            Invoke("TurnOffGameObject", 3f);
        }

    }

    void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }

    IEnumerator DeadSound()
    {
        yield return new WaitForSeconds(0.3f);
        enemyAudio.PLay_Dead_Sound();
    }

}
