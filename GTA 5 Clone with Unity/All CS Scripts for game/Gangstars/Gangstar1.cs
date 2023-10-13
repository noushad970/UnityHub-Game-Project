using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gangstar1 : MonoBehaviour
{
    [Header("Character info")]
    public float movingSpeed;
    public float runningSpeed;
    public float currentMovingSpeed;
    public float turningSpeed = 300f;
    public float stopSpeed = 1f;

    [Header("Destination Var")]
    public Vector3 destination;
    public bool destinationReached;

    [Header("Gangstar AI")]
    public GameObject playerBody;
    public LayerMask PlayerLayer;
    public float visionRadius;
    public float shootingRadius;
    public bool playerInvisionRadius;
    public bool playerInshootRadius;
    public Animator animator;
    private float characterHealth = 100f;
    float presentHealth;
    public GameObject BloodEffect;





    [Header("Gangstar shooting Var")]
    public float giveDamageOf = 3f;
    public float shootingRange = 100f;
    public GameObject ShootingRayCastArea;
    public float timebtwShoot;
    bool previouslyShoot;

    //public WantedLevel wantedLevelScript;
    public PLayer player;


    private void Start()
    {
        presentHealth = characterHealth;
        playerBody = GameObject.Find("Player");
        //wantedLevelScript = GameObject.FindObjectOfType<WantedLevel>();
        currentMovingSpeed = movingSpeed;
        player = GameObject.FindObjectOfType<PLayer>();

    }
    private void Update()
    {
        playerInvisionRadius = Physics.CheckSphere(transform.position, visionRadius, PlayerLayer);
        playerInshootRadius = Physics.CheckSphere(transform.position, shootingRadius, PlayerLayer);
        if (!playerInshootRadius && !playerInvisionRadius)
        {
            Walk();
        }
        if (!playerInshootRadius && playerInvisionRadius)
        {
            ChasePlayer();
        }
        if (playerInshootRadius && playerInvisionRadius)
        {

            ShootPlayer();
        }

    }
    void Walk()
    {

        //  currentMovingSpeed = movingSpeed;
        if (transform.position != destination)
        {
            Vector3 destinationDirection = destination - transform.position;
            destinationDirection.y = 0;
            float destinationDistance = destinationDirection.magnitude;

            if (destinationDistance >= stopSpeed)
            {
                //turning
                destinationReached = false;
                Quaternion targetRotation = Quaternion.LookRotation(destinationDirection);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turningSpeed * Time.deltaTime);

                //Move AI
                transform.Translate(Vector3.forward * currentMovingSpeed * Time.deltaTime);
                animator.SetBool("Walk", true);
                animator.SetBool("Run", false);
                animator.SetBool("Shoot", false);

            }

            else
            {
                destinationReached = true;
            }
        }
    }
    public void LocateDestination(Vector3 destination)
    {
        this.destination = destination;
        destinationReached = false;
    }
    void ChasePlayer()
    {
        transform.position += transform.forward * currentMovingSpeed * Time.deltaTime;
        transform.LookAt(playerBody.transform);

        animator.SetBool("Walk", false);
        animator.SetBool("Run", true);
        animator.SetBool("Shoot", false);

        currentMovingSpeed = runningSpeed;
    }



    public void ShootPlayer()
    {
        currentMovingSpeed = 0f;

        transform.LookAt(playerBody.transform);
        //extra
        // transform.Translate(Vector3.forward * currentMovingSpeed * Time.deltaTime);
        animator.SetBool("Walk", false);
        animator.SetBool("Run", false);
        animator.SetBool("Shoot", true);
        if (!previouslyShoot)
        {
            RaycastHit hit;
            if (Physics.Raycast(ShootingRayCastArea.transform.position, ShootingRayCastArea.transform.forward, out hit, shootingRange))
            {
                Debug.Log("Shooting" + hit.transform.name);
                PlayerController playerBody = hit.transform.GetComponent<PlayerController>();
                if (playerBody != null)
                {
                    playerBody.playerHitDamage(giveDamageOf);
                    //those two lines are for hiting effect while hit the object
                    GameObject bloodObjectGo = Instantiate(BloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(bloodObjectGo, 1.0f);
                }
            }
            previouslyShoot = true;
            Invoke(nameof(ActiveShooting), timebtwShoot);



        }
    }
    private void ActiveShooting()
    {
        previouslyShoot = false;
    }

    public void characterDamage(float takeDamage)
    {
        presentHealth -= takeDamage;
        if (presentHealth <= 0)
        {
            animator.SetBool("Die", true);
            CharacterDie();

        }
    }
    private void CharacterDie()
    {
        currentMovingSpeed = 0f;
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        player.currentKills += 1;
        shootingRange = 0f;
        Object.Destroy(gameObject, 3.0f);
        player.playerMoney += 10;
    }
}
