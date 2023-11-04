using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float moveAndroidSpeed = 20f;
    private float LeftRightSpeed = 10f;
    public bool gameStart=false;
    static public bool CanMove=false;
    public bool isJumping=false;
    public bool ComingDown=false;
    public GameObject playerObject;
    public Animator animator;
    public AudioSource jumpSound;
    // Assuming you have a reference to the GameObject's Transform

    // touch set up
    public float swipeThreshold = 30.0f; // Adjust this value as needed for sensitivity.

    private Vector2 touchStartPos;
    private Vector2 touchEndPos;

    // Set the Z-axis component to 0

    Transform objectTransform;
    // Update is called once per frame
    private void Start()
    {
        
        objectTransform = playerObject.transform;
        StartCoroutine(waitfor6Sec());
    }
    void Update()
    {
        float accelerationX = Input.acceleration.x;
        float moveDirection = accelerationX;
        animator.SetBool("Idle", true);
        if (gameStart)
        {
            if (this.gameObject.transform.position.x >= -4f && this.gameObject.transform.position.x <= 4f)
            {
                transform.Translate(Vector3.right * moveDirection * moveAndroidSpeed * Time.deltaTime);


            }
            if (playerObject.transform.position.x < -4f)
                playerObject.transform.position = new Vector3(-4f, playerObject.transform.position.y, playerObject.transform.position.z);
            if (playerObject.transform.position.x > 4f)
                playerObject.transform.position = new Vector3(4f, playerObject.transform.position.y, playerObject.transform.position.z);
            movement();
            playerJump();
            jumpAndroid();
            animator.SetBool("Idle", false);
        }
    }
    IEnumerator waitfor6Sec()
    {
        yield return new WaitForSeconds(6f);
        gameStart = true;
    }
    IEnumerator IncreaseMoveSpeed()
    {
        moveSpeed += 0.001f;
        yield return new WaitForSeconds(1f);
    }
    void movement()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelBoundary.Leftside)
            {
                transform.Translate(Vector3.left * Time.deltaTime * LeftRightSpeed);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < LevelBoundary.Rightside)
            {
                transform.Translate(Vector3.left * Time.deltaTime * LeftRightSpeed * -1);
            }

        }


        if (moveSpeed >= 30f)
            moveSpeed = 30f;
        else
            StartCoroutine(IncreaseMoveSpeed());

    }
    void playerJump()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.Space))
        {
            if (!isJumping)
            {
                jumpSound.Play();
                isJumping = true;
                animator.SetBool("Jump", true);
                StartCoroutine(JumpSequence());
                
            }
            
        }
        if (isJumping)
        {
            if (!ComingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 6, Space.World);
            }
            if (ComingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -6.4f, Space.World);
            }
        }

    }
    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(.55f);
        ComingDown = true;
        yield return new WaitForSeconds(.55f);
        isJumping = false;
        ComingDown=false;
        animator.SetBool("Jump", false);
        playerObject.transform.position= new Vector3(playerObject.transform.position.x,0 , playerObject.transform.position.z);


    }
    void jumpAndroid()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                touchEndPos = touch.position;

                float swipeDistance = Vector2.Distance(touchStartPos, touchEndPos);

                if (swipeDistance > swipeThreshold && touchEndPos.y > touchStartPos.y)
                {
                    // A swipe from down to up has been detected.
                    // You can call your function or perform an action here.
                    AndroidJump();
                }
            }
        }
    }
    void AndroidJump()
    {
        if (!isJumping)
        {
            jumpSound.Play();
            isJumping = true;
            animator.SetBool("Jump", true);
            StartCoroutine(JumpSequence());

        }
        if (isJumping)
        {
            if (!ComingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 6, Space.World);
            }
            if (ComingDown)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -6.4f, Space.World);
            }
        }

    }

    
}



