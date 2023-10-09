using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [Header("Item Info")]
    public int itemprice;
    public int itemradius;
    public string itemtags;
    private GameObject itemtopick;

    [Header("Player Infor")]
    public PLayer player;
    public Inventory inventory;
    public Missions missions;
    private void Start()
    {
        itemtopick = GameObject.FindWithTag(itemtags);   
    }
    private void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) <itemradius)
        {
           if(Input.GetKeyDown("f")) 
            {
                if(itemprice>player.playerMoney)
                {
                    Debug.Log("Not enough money");
                    
                }
                else
                {
                    //mission 3 completation
                    if (missions.mission1 == true && missions.mission2 == true && missions.mission4 == false)
                    {
                        missions.mission3 = true;
                        player.playerMoney += 800;
                    }
                    if (itemtags == "HandGunPickUp")
                    {
                        player.playerMoney -= itemprice;
                        inventory.weapon1.SetActive(true);
                        inventory.isWeapon1picked = true;
                        GameObject.FindWithTag("HandGunPickUp").SetActive(false);
                    }
                    else if (itemtags == "BasookaPickUp")
                    {
                        player.playerMoney -= itemprice;
                        inventory.weapon4.SetActive(true);
                        inventory.isWeapon4picked = true;
                       // GameObject.FindWithTag("HandGunPickUp").SetActive(false);
                    }
                    else if (itemtags == "UziPickUp")
                    {
                        player.playerMoney -= itemprice;
                        inventory.weapon3.SetActive(true);
                        inventory.isWeapon3picked = true;
                        GameObject.FindWithTag("UziPickUp").SetActive(false);
                    }
                    else if (itemtags == "ShortGunPickUp")
                    {
                        player.playerMoney -= itemprice;
                        inventory.weapon2.SetActive(true);
                        inventory.isWeapon2picked = true;
                    }
                    itemtopick.SetActive(false);
                }
                
            }
        }
    }
}
