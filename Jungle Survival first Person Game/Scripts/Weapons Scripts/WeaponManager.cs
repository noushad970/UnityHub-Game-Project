using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private WeaponHandler[] Weapons;

    private int Current_Weapon_Index;
    // Start is called before the first frame update
    void Start()
    {
        Current_Weapon_Index = 0;
        //the below code will show the index position weapon in the game;
        Weapons[Current_Weapon_Index].gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            turnOnSelectedWeapon(0);
            
            //the below code will show the index position weapon in the game;
            //Weapons[Current_Weapon_Index].gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            turnOnSelectedWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            turnOnSelectedWeapon(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            turnOnSelectedWeapon(3);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            turnOnSelectedWeapon(4);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {

            turnOnSelectedWeapon(5);
        }



    }
    void turnOnSelectedWeapon(int weaponIndex)
    {
        if(Current_Weapon_Index == weaponIndex) { return; }
        Weapons[Current_Weapon_Index].gameObject.SetActive(false);
        Weapons[weaponIndex].gameObject.SetActive(true); 
        Current_Weapon_Index = weaponIndex;
    }

    public WeaponHandler GetCurrentSelectedWeapon()
    {
        return Weapons[Current_Weapon_Index];
    }

}
