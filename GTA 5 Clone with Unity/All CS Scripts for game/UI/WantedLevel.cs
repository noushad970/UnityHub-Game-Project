using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WantedLevel : MonoBehaviour
{
    public PLayer player;
    public bool wantedLevel1;
    public GameObject level1Star;
    public bool wantedLevel2;
    public GameObject level2Star;
    public bool wantedLevel3;
    public GameObject level3Star;
    public bool wantedLevel4;
    public GameObject level4Star;
    public bool wantedLevel5;
    public GameObject level5Star;
    private void Update()
    {
        if(player.currentKills==2)
        {
            level1Star.SetActive(true);
            wantedLevel1 = true;
        }
        if(player.currentKills>=3)
        {
            level2Star.SetActive(true);
            wantedLevel2 = true;
        }
        if(player.currentKills>=5)
        {
            level3Star.SetActive(true);
            wantedLevel3 = true;
        }
        if(player.currentKills>=10)
        {
            level4Star.SetActive(true); 
            wantedLevel4 = true;
        }
        if(player.currentKills>=15) {  
            level5Star.SetActive(true);
        wantedLevel5 = true;
        }
        
    }
}
