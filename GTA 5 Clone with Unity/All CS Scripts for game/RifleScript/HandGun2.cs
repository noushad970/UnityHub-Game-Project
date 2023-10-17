using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGun2 : MonoBehaviour
{
    [Header("Rifle Things")]
    public Camera cam;
    public float giveDamage = 10f;
    public float ShootingRange = 100f;
    public ParticleSystem muzzleSpark;
    public GameObject MetalEffect;//effect will shown on where the bullet will hit
    public float firecharge = 10f;
    private float nextTimeToFire = 0f;
    public Transform Hand;
    public bool ismoving = false;

    [Header("megazine reload and ammo")]
    private int MaxiAmmu = 25;
    public int mag = 10;
    private int PresentAmmu;
    public float ReloadTime = 3.0f;
    private bool IsReloading = false;

    [Header("Ammo Out")]
    public GameObject AmmuOutText;

    [Header("Rifle Sound")]
    public GunSound gunSound;


    private void Awake()
    {
        transform.SetParent(Hand);
        Cursor.lockState = CursorLockMode.Locked;
        PresentAmmu = MaxiAmmu;
    }
    private void Update()
    {
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
                nextTimeToFire = Time.time + 1f / firecharge;
                shoot();
                gunSound.playHandGunSound();

            }
        }
    }
    void shoot()
    {
        PresentAmmu--;
        //Ammo UI
        AmmoCount.Instance.updateMagText(mag);
        AmmoCount.Instance.UpdateAmmo(PresentAmmu);
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
            Object obj = hitInfo.transform.GetComponent<Object>();
            if (obj != null)
            {
                obj.ObjectHitDamage(giveDamage);
                GameObject gameObjectGo = Instantiate(MetalEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(gameObjectGo, 1f);
            }

        }
    }
    IEnumerator Reload()
    {
        IsReloading = true;

        yield return new WaitForSeconds(ReloadTime);
        PresentAmmu = MaxiAmmu;
        IsReloading = false;
    }
    IEnumerator ShowAmmuOut()
    {
        AmmuOutText.SetActive(true);
        yield return new WaitForSeconds(5f);
        AmmuOutText.SetActive(false);
    }
}
