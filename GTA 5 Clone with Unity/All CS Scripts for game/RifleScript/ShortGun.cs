using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortGun : MonoBehaviour
{
    //player movement wiht rifle variable

    [Header("PlayerMovement")]
    public float playerSpeed = 1.1f;
    public float playerSprint = 5f;
    [Header("Player Animation & Gravity")]
    public CharacterController cC;
    public float gravity = -9.81f;
    public Animator animator;

    [Header("Player Jumping and velocity")]
    public float turnCalmTime = 0.1f;
    private float turnCalmVelocity;
    Vector3 velocity;
    public Transform surfacecheck;//is grounded
    bool OnSurface;
    public float surfaceDistance = 0.4f;
    public LayerMask surfaceMask;
    public float jumrange = 1f;


    [Header("Player Scripth Camera")]
    public Transform playerCamera;

    //rifle shooting variable

    [Header("Rifle Things")]
    public Camera cam;
    public float giveDamage = 10f;
    public float ShootingRange = 100f;
    public ParticleSystem muzzleSpark;
    public GameObject MetalEffect;//effect will shown on where the bullet will hit
    public float firecharge = 10f;
    private float nextTimeToFire = 0f;
    public Transform Hand;
    public Transform playerTransform;
    public bool ismoving = false;

    [Header("Rifle Sound")]
    public GunSound gunSound;
    //  public HandGun2 handgun2;

    [Header("megazine reload and ammo")]
    private int MaxiAmmu = 25;
    public int mag = 10;
    private int PresentAmmu;
    public float ReloadTime = 3.0f;
    private bool IsReloading = false;
    bool ShotGunActive = true;
    public GameObject BloodEffect;

    [Header("Ammo Out")]
    public GameObject AmmuOutText;
    Gangstar1 gangstar1;
    Boss boss1;


    private void Awake()
    {
        transform.SetParent(Hand);
        Cursor.lockState = CursorLockMode.Locked;
        PresentAmmu = MaxiAmmu;
    }
    private void Update()
    {
        if (ShotGunActive == true)
        {
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("ShortGunAnimator");
        }


        if (IsReloading)
            return;
        if (PresentAmmu <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (ismoving == false)
        {
            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                animator.SetBool("Shoot", true);
                nextTimeToFire = Time.time + 1f / firecharge;
                shoot();
                gunSound.playShotGunSound();

            }
            
        }
        else
        {
            animator.SetBool("Shoot", false);
        }
        
        Surface();
        playerMove();
        Jump();
        sprint();
    }
    void shoot()
    {
        //Ammo UI
        AmmoCount.Instance.updateMagText(mag);
        AmmoCount.Instance.UpdateAmmo(PresentAmmu);

        PresentAmmu--;
        if (PresentAmmu == 0)
        {
            mag--;

        }
        if (mag <= 0)
        {
            //show ammu out text;
            StartCoroutine(ShowAmmuOut());
            return;
        }
        muzzleSpark.Play();
        RaycastHit hitInfo;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitInfo, ShootingRange))
        {

            Debug.Log(hitInfo.transform.name);
            PoliceOfficers policeOfficers = hitInfo.transform.GetComponent<PoliceOfficers>();
            Gangstar1 gangstar1= hitInfo.transform.GetComponent<Gangstar1>();
            AICharObject objchar = hitInfo.transform.GetComponent<AICharObject>();
            Object obj = hitInfo.transform.GetComponent<Object>();
            Boss boss1= hitInfo.transform.GetComponent<Boss>();
            if (obj != null)
            {
                obj.ObjectHitDamage(giveDamage);
                //those two lines are for giving effect after hiting the target.
                GameObject gameObjectGo = Instantiate(MetalEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(gameObjectGo, 1f);
            }
            else if (objchar != null)
            {
                objchar.ObjectHitDamage(giveDamage);
                //those two lines are for giving effect after hiting the target.
                GameObject gameObjectGo = Instantiate(BloodEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(gameObjectGo, 1f);
            }
            //give damage to police officers
            else if (policeOfficers != null)
            {
                policeOfficers.characterDamage(giveDamage);
                //those two lines are for giving effect after hiting the target.
                GameObject bloodObjectGo = Instantiate(BloodEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(bloodObjectGo, 1f);
            }
            //give damage to gangstar
            else if (gangstar1 != null)
            {
                gangstar1.characterDamage(giveDamage);
                //those two lines are for giving effect after hiting the target.
                GameObject bloodObjectGo = Instantiate(BloodEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(bloodObjectGo, 1f);
            }
            else if (boss1 != null)
            {
                boss1.characterHitDamage(giveDamage);
                //those two lines are for giving effect after hiting the target.
                GameObject bloodObjectGo = Instantiate(BloodEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(bloodObjectGo, 1f);
            }

        }
    }
    IEnumerator Reload()
    {
        playerSpeed = 0f;
        playerSprint = 0f;
        IsReloading = true;
        gunSound.PlayreloadSound();
        animator.SetBool("Reload", true);
        yield return new WaitForSeconds(ReloadTime);
        animator.SetBool("Reload", false);
        PresentAmmu = MaxiAmmu;
        IsReloading = false;
        playerSprint = 3f;
        playerSpeed = 1.1f;
    }
    IEnumerator ShowAmmuOut()
    {
        AmmuOutText.SetActive(true);
        yield return new WaitForSeconds(5f);
        AmmuOutText.SetActive(false);
    }


    //player movement all function

    void Surface()
    {
        OnSurface = Physics.CheckSphere(surfacecheck.position, surfaceDistance, surfaceMask);
        if (OnSurface && velocity.y < 0)
            velocity.y = -2f;
        //gravity
        velocity.y += gravity * Time.deltaTime;
        cC.Move(velocity * Time.deltaTime);
    }
    void playerMove()
    {


        if (Input.GetKey(KeyCode.DownArrow) && OnSurface)
        {
            playerSpeed = -1.1f;
        }
        else
            playerSpeed = 1.1f;
        float horizontal_move = Input.GetAxisRaw("Horizontal");
        float Vertical_move = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal_move, 0f, Vertical_move).normalized;

        if (direction.magnitude >= 0.1f)
        {

            ismoving = true;
           // handgun2.ismoving = true;
            animator.SetBool("WalkForward", true);
            animator.SetBool("RunForward", false);
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(playerTransform.eulerAngles.y, targetAngle, ref turnCalmVelocity, turnCalmTime);
            playerTransform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 movedirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            cC.Move(movedirection.normalized * playerSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("WalkForward", false);
            animator.SetBool("RunForward", false);

            ismoving = false;
           // handgun2.ismoving = false;
        }

    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && OnSurface)
        {
            velocity.y = Mathf.Sqrt(jumrange * -2 * gravity);
            animator.SetBool("IdleAim", false);
            animator.SetTrigger("Jump");


        }
        else
        {
            animator.SetBool("IdleAim", true);
            animator.ResetTrigger("Jump");


        }

    }
    void sprint()
    {
        if (Input.GetKey(KeyCode.RightShift) && OnSurface && (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow)))
        {
            float horizontal_move = Input.GetAxisRaw("Horizontal");
            float Vertical_move = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal_move, 0f, Vertical_move).normalized;

            if (direction.magnitude >= 0.1f)
            {
                animator.SetBool("RunForward", true);
                animator.SetBool("WalkForward", false);
                float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(playerTransform.eulerAngles.y, targetAngle, ref turnCalmVelocity, turnCalmTime);
                playerTransform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 movedirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                cC.Move(movedirection.normalized * playerSprint * Time.deltaTime);

                ismoving = true;
              //  handgun2.ismoving = true;
            }
            else
            {
                animator.SetBool("RunForward", false);
                animator.SetBool("WalkForward", false);

                ismoving = false;
            }
        }
    }
}
