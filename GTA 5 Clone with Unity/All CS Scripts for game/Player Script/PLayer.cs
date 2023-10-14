using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour
{
    [Header("PlayerInfo")]
    public int playerMoney;
    public int currentKills;
    [Header("PlayerInventory")]
    public Missions missions;
    public Inventory inventory;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void SavePlayer()
    {
        SaveSystem.savePlayer(this);
    }
    
    public void LoadPlayer()
    {

        PlayerData data = SaveSystem.LoadPlayer();

        playerMoney = data.playerMoney;
        Vector3 position;

        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];

        transform.position = position;

        inventory.isWeapon1picked = data.isWeapon1Picked;
        inventory.isWeapon2picked = data.isWeapon2Picked;
        inventory.isWeapon3picked = data.isWeapon3Picked;
        inventory.isWeapon4picked = data.isWeapon4Picked;

        missions.mission1=data.mission1;
        missions.mission2=data.mission2;
        missions.mission3=data.mission3;    
        missions.mission4=data.mission4;



    }
}
