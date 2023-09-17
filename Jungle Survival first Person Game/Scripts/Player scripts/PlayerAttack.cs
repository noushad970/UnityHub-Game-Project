using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private WeaponManager weapon_manager;

    public float firerate = 15f;
    private float nextTimeToFire;
    public float Damage = 20f;

    private Animator ZoomCamAnim;
    private bool zoomed;
    private Camera MainCam;
    private GameObject crosshair;
    private bool is_Aiming;
    [SerializeField]
    private GameObject arrow_Prefab, Spear_Prefab;
    [SerializeField]
    private Transform arrow_Bow_startPosition;
     void Awake()
    {
        weapon_manager = GetComponent<WeaponManager>();
        ZoomCamAnim = transform.Find(Tags.Look_Root)
            .transform.Find(Tags.Zoom_Camera).GetComponent<Animator>();
        
        
        crosshair = GameObject.FindWithTag(Tags.Cross_hair);
        MainCam = Camera.main;
    }
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        weaponShoot();
        ZoomInAndOut();
        
    }

    void weaponShoot()
    {
        //this is for a gun or rifle which shoot more than one bullet at a time. such as machine gun;
        if(weapon_manager.GetCurrentSelectedWeapon().weapon_FireType==WeaponFireType.MULTIPLE)
        {
            if(Input.GetMouseButton(0) && Time.time > nextTimeToFire) {
            nextTimeToFire = Time.time + 1f/firerate;
            weapon_manager.GetCurrentSelectedWeapon().shootAnimation();
                bulletfired();  
            }
        }
        else
        {
            if(Input.GetMouseButtonDown(0))
            {
                if(weapon_manager.GetCurrentSelectedWeapon().tag==Tags.Axe_Tag) { 
                weapon_manager.GetCurrentSelectedWeapon().shootAnimation();
                }

                if (weapon_manager.GetCurrentSelectedWeapon().weapon_BulletType == WeaponBulletType.BULLET)
                {
                    weapon_manager.GetCurrentSelectedWeapon().shootAnimation();
                    bulletfired();
                }
                else
                {
                    if (is_Aiming)
                    {
                        weapon_manager.GetCurrentSelectedWeapon().shootAnimation();

                        if(weapon_manager.GetCurrentSelectedWeapon().weapon_BulletType==WeaponBulletType.ARROW)
                        {
                            throwBowOrArrow(true);////////////rt
                        }
                        else if (weapon_manager.GetCurrentSelectedWeapon().weapon_BulletType == WeaponBulletType.SPEAR)
                        {
                            throwBowOrArrow(false);
                        }
                    }
                }
            }
        }
    }
    void ZoomInAndOut()
    {
       // we are going to aim with our camera on the weapon
        if(weapon_manager.GetCurrentSelectedWeapon().weapon_Aim==WeaponAim.AIM)
        {
            if(Input.GetMouseButtonDown(1))
            {
                ZoomCamAnim.Play(animationTag.Zoom_In_Anim);
                crosshair.SetActive(false);
            }
            if (Input.GetMouseButtonUp(1))
            {
                ZoomCamAnim.Play(animationTag.Zoom_Out_Anim);
                crosshair.SetActive(true);
            }
        }
        if (weapon_manager.GetCurrentSelectedWeapon().weapon_Aim==WeaponAim.SELF_AIM)
        {

            if(Input.GetMouseButtonDown(1))
            {
                weapon_manager.GetCurrentSelectedWeapon().aim(true);
                is_Aiming = true;
            }

            if(Input.GetMouseButtonUp(1))
            {
                weapon_manager.GetCurrentSelectedWeapon().aim(false);
                is_Aiming = false;
            }
    
        }
    }
    void throwBowOrArrow(bool throwArrow)
    {
        if(throwArrow)
        {
            GameObject arrow = Instantiate(arrow_Prefab);
            arrow.transform.position = arrow_Bow_startPosition.position;
            arrow.GetComponent<ArrowAndBowScript>().launch(MainCam);
        }
        else
        {
            GameObject Spear = Instantiate(Spear_Prefab);
            Spear.transform.position = arrow_Bow_startPosition.position;
            Spear.GetComponent<ArrowAndBowScript>().launch(MainCam);
        }
    }


    void bulletfired()
    {
        RaycastHit hit;
        if(Physics.Raycast(MainCam.transform.position,MainCam.transform.forward,out hit))
        {
            if(hit.transform.tag==Tags.Enemy_Tag) {
                hit.transform.GetComponent<HealthScript>().ApplyDamage(Damage); 
                
            }
            
        }
    }
}























































