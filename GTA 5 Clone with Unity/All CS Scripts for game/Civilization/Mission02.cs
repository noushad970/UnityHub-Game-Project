using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission02 : MonoBehaviour
{
    public PLayer player;
    public Missions missions;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (missions.mission1 == true && missions.mission3 == false && missions.mission4 == false)
            {
                missions.mission2 = true;
                player.playerMoney += 600;
            }
        }
    }
}
