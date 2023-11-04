using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour
{
    public static int coinCount;
    public GameObject coinCountDisplay;
    public GameObject coinEndCountDisplay;
    public PlayerController playerController;
    

    // Update is called once per frame
    void Update()
    {
        if(playerController.gameStart)
        coinCountDisplay.GetComponent<Text>().text = "" + coinCount;
        coinEndCountDisplay.GetComponent<Text>().text = "" + coinCount;
    }
}
