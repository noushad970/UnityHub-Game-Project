using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 8f;
    private float LeftRightSpeed = 10f;
    public bool gameStart=false;
    static public bool CanMove=false;
    public bool isJumping=false;
    public bool ComingDown=false;
    public GameObject playerObject;
    public Animator animator;
    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(waitfor6Sec());
    }
    void Update()
    {
        if(gameStart)
        {
            movement();
            playerJump();
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
                transform.Translate(Vector3.up * Time.deltaTime * -6, Space.World);
            }
        }

    }
    IEnumerator JumpSequence()
    {
        yield return new WaitForSeconds(.45f);
        ComingDown = true;
        yield return new WaitForSeconds(.45f);
        isJumping = false;
        ComingDown=false;
        animator.SetBool("Jump", false);


    }
    
    
}
