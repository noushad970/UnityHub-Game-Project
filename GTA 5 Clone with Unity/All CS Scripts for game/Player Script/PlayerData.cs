using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int playerMoney;
    public float[] position;
    public bool isWeapon1Picked;
    public bool isWeapon2Picked;
    public bool isWeapon3Picked;
    public bool isWeapon4Picked;
    public bool mission1;
    public bool mission2;
    public bool mission3;
    public bool mission4;

    public PlayerData(PLayer player)
    {
        playerMoney = player.playerMoney;
        position= new float[3];
        position[0]=player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        isWeapon1Picked = player.inventory.isWeapon1picked;
        isWeapon2Picked=player.inventory.isWeapon2picked;
        isWeapon3Picked=player.inventory.isWeapon3picked;
        isWeapon4Picked=player.inventory.isWeapon4picked;

        mission1 = player.missions.mission1;
        mission2 = player.missions.mission2;
        mission3 = player.missions.mission3;
        mission4 = player.missions.mission4;

        Debug.Log("Mission Saved");
        
    }

}
