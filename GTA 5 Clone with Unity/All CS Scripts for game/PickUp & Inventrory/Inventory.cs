using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [Header("Item slots")]
    public GameObject weapon1;
    public bool isWeapon1picked=false;
    public bool isWeapon1Active=false ;
    public Animator animator;

    public GameObject weapon2;
    public bool isWeapon2picked = false;
    public bool isWeapon2Active = false;

    public GameObject weapon3;
    public bool isWeapon3picked = false;
    public bool isWeapon3Active = false;

    public GameObject weapon4;
    public bool isWeapon4picked = false;
    public bool isWeapon4Active = false;

    [Header("Weapons to use")]
    public GameObject handgun1;
    public GameObject handgun2;
    public GameObject uzi1;
    public GameObject uzi2;
    public GameObject shortGun;
    public GameObject Basooka;
    [Header("Scripts")] 
    public PlayerController playerScript;
    public ShortGun Shortgun;
    public HandGun HandGun;
    public HandGun2 HandGun2;
    public UZI1 UZI1;
    public UZI2 UZI2;
    public Basooka basooka;

    [Header("Inventory")]
    public GameObject inventoryPanel;
    bool ispause=false;
    public SwitchCamera switchCamera;
    public GameObject AimCam;
    public GameObject ThirdPersonCam;
    public PlayerController playerController;
    

    
    void Update()
    {
        if(Input.GetKeyDown("1")&& isWeapon1picked==true)
        {
            isWeapon1Active = true;
            isWeapon2Active=false;
            isWeapon3Active=false;  
            isWeapon4Active=false;
            rifleActive();
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("HandGunAnimator");
        }
        else if (Input.GetKeyDown("2") && isWeapon2picked == true)
        {
            isWeapon2Active = true;
            isWeapon1Active = false;
            isWeapon3Active = false;
            isWeapon4Active = false;
            rifleActive();
        }
        else if (Input.GetKeyDown("3") && isWeapon3picked == true)
        {
            isWeapon3Active = true;
            isWeapon2Active = false;
            isWeapon1Active = false;
            isWeapon4Active = false;
            rifleActive();
        }
        else if (Input.GetKeyDown("4") && isWeapon4picked == true)
        {
            isWeapon4Active = true;
            isWeapon2Active = false;
            isWeapon3Active = false;
            isWeapon1Active = false;
            rifleActive();
            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("LauncherAnimation");
        }
        else if (Input.GetKeyDown("5")&&(isWeapon4Active == true || isWeapon3Active == true || isWeapon2Active == true || isWeapon1Active == true))
        {
            isWeapon4Active = false;
            isWeapon2Active = false;
            isWeapon3Active = false;
            isWeapon1Active = false;
            // playerController.isActivePlayer = true;
            playerController.GetComponent<PlayerController>().enabled=true;
           // rifleActive();

            animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("PlayerController");
            handgun1.SetActive(false); handgun2.SetActive(false);
            shortGun.SetActive(false);
            Basooka.SetActive(false);
            uzi1.SetActive(false);
            uzi2.SetActive(false);

            playerScript.GetComponent<PlayerController>().enabled = true;
            shortGun.GetComponent<ShortGun>().enabled = false;
            uzi1.GetComponent<UZI1>().enabled = false;
            uzi2.GetComponent<UZI2>().enabled = false;
            basooka.GetComponent<Basooka>().enabled = false;
            handgun1.GetComponent<HandGun>().enabled = false;
            handgun2.GetComponent<HandGun2>().enabled = false;

        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            showinventory();
            if(isWeapon1picked==true)
            {
                weapon1.SetActive(true);
            }
            if (isWeapon2picked == true)
            {
                weapon2.SetActive(true);
            }
            if (isWeapon3picked == true)
            {
                weapon3.SetActive(true);
            }
            if (isWeapon4picked == true)
            {
                weapon4.SetActive(true);
            }
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            hideinventory();
        }
    }
    void rifleActive()
    {
        if(isWeapon1Active==true) { 
        handgun1.SetActive(true); handgun2.SetActive(true);
            shortGun.SetActive(false);
            Basooka.SetActive(false);
            uzi1.SetActive(false);
            uzi2.SetActive(false);

            playerScript.GetComponent<PlayerController>().enabled = false;
            shortGun.GetComponent<ShortGun>().enabled = false;
            uzi1.GetComponent<UZI1>().enabled = false;
            uzi2.GetComponent<UZI2>().enabled = false;
            basooka.GetComponent<Basooka>().enabled = false;
            handgun1.GetComponent<HandGun>().enabled = true;
            handgun2.GetComponent<HandGun2>().enabled = true;

           
        }
        else if (isWeapon2Active == true)
        {
            handgun1.SetActive(false); handgun2.SetActive(false);
            shortGun.SetActive(true);
            Basooka.SetActive(false);
            uzi1.SetActive(false);
            uzi2.SetActive(false);

            playerScript.GetComponent<PlayerController>().enabled = false;
            shortGun.GetComponent<ShortGun>().enabled = true;
            uzi1.GetComponent<UZI1>().enabled = false;
            uzi2.GetComponent<UZI2>().enabled = false;
            basooka.GetComponent<Basooka>().enabled = false;
            handgun1.GetComponent<HandGun>().enabled = false;
            handgun2.GetComponent<HandGun2>().enabled = false;


        }
        else if (isWeapon3Active == true)
        {
            handgun1.SetActive(false); handgun2.SetActive(false);
            shortGun.SetActive(false);
            Basooka.SetActive(false);
            uzi1.SetActive(true);
            uzi2.SetActive(true);

            playerScript.GetComponent<PlayerController>().enabled = false;
            shortGun.GetComponent<ShortGun>().enabled = false;
            uzi1.GetComponent<UZI1>().enabled = true;
            uzi2.GetComponent<UZI2>().enabled = true;
            basooka.GetComponent<Basooka>().enabled = false;
            handgun1.GetComponent<HandGun>().enabled = false;
            handgun2.GetComponent<HandGun2>().enabled = false;


        }
        else if (isWeapon4Active == true)
        {
            handgun1.SetActive(false); handgun2.SetActive(false);
            shortGun.SetActive(false);
            Basooka.SetActive(true);
            uzi1.SetActive(false);
            uzi2.SetActive(false);

            playerScript.GetComponent<PlayerController>().enabled = false;
            shortGun.GetComponent<ShortGun>().enabled = false;
            uzi1.GetComponent<UZI1>().enabled = false;
            uzi2.GetComponent<UZI2>().enabled = false;
            basooka.GetComponent<Basooka>().enabled = true;
            handgun1.GetComponent<HandGun>().enabled = false;
            handgun2.GetComponent<HandGun2>().enabled = false;


        } 
    }
    void showinventory()
    {
        switchCamera.GetComponent<SwitchCamera>().enabled = false;
        AimCam.SetActive(false );
        ThirdPersonCam.SetActive(false );
        inventoryPanel.SetActive(true);
        Time.timeScale = 0f;
        ispause = true;
    }
    void hideinventory()
    {
        switchCamera.GetComponent<SwitchCamera>().enabled = true;
        AimCam.SetActive(true);
        ThirdPersonCam.SetActive(true);
        inventoryPanel.SetActive(false);
        Time.timeScale = 1f;
        ispause = false;
    }
}
