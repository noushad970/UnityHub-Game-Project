using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Missions : MonoBehaviour
{
    public bool mission1;
    public bool mission2;
    public bool mission3;
    public bool mission4;

    public Text missionText;
    private void Update()
    {
        if(mission1==false && mission2==false && mission3 == false && mission4 == false )
        {
            //UI
            missionText.text = "Locate Your House and Save game";
        }
        if (mission1 == true && mission2 == false && mission3 == false && mission4 == false)
        {
            //UI
            missionText.text = "Meet frank at police station";
        }
        if (mission1 == true && mission2 == true && mission3 == false && mission4 == false)
        {
            //UI
            missionText.text = "Find weapon at home";
        }
        if (mission1 == true && mission2 == true && mission3 == true && mission4 == false)
        {
            //UI
            missionText.text = "Find Gonzalve and take revenge";
        }
        if (mission1 == true && mission2 == true && mission3 == true && mission4 == true)
        {
            //UI
            missionText.text = "All mission completed successfully";
        }
    }
}
