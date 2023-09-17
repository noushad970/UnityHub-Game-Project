using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum WeaponAim
{
    NONE,
    SELF_AIM,
    AIM
}
public enum WeaponFireType
{
    SINGLE,
    MULTIPLE
}
public enum WeaponBulletType
{
    BULLET,
    ARROW,
    SPEAR,
    NONE
}

public class WeaponHandler : MonoBehaviour
{
    private Animator anim;
    public WeaponAim weapon_Aim;

    [SerializeField]
    private GameObject MuzzleFlash;
    [SerializeField]
    private AudioSource ShootSound, Reload_sound;

    public WeaponFireType weapon_FireType;
    public WeaponBulletType weapon_BulletType;
    public GameObject attack_point;
    // Start is called before the first frame update

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void shootAnimation()
    {
        anim.SetTrigger(animationTag.Shoot_Trigger);
    }
     
    public void aim(bool canAim)
    {
        anim.SetBool(animationTag.Aim_Parameter, canAim);
    }

    public void turn_on_MazzleFlash()
    {
        MuzzleFlash.SetActive(true);
    }
    public void turn_off_MazzleFlash()
    {
        MuzzleFlash.SetActive(false);
    }
    public void Play_shoot_sound()
    {
        ShootSound.Play();
    }

    public void Play_Reload_sound()
    {
        Reload_sound.Play();
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

}
