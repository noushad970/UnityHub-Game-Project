using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGlow : MonoBehaviour
{
    public PLayer player;
    public Missions missions;
    int x = 0;
    public GameObject saveUI;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            player.SavePlayer();
            StartCoroutine(SaveUI());
        }
        if(missions.mission2==false && missions.mission3 == false && missions.mission4 == false)
        {
            missions.mission1 = true;
            x++;
        }
        if(x==1)
        {
            player.playerMoney += 400;
        }
        
    }
    IEnumerator SaveUI()
    {
        saveUI.SetActive(true);
        yield return new WaitForSeconds(2);
        saveUI.SetActive(false);
    }
}
