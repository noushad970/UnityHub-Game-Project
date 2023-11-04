using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    public GameObject disDisplay;
    public GameObject disEndDisplay;
    private int disRun=0;
    public bool addingDis=false;
    public PlayerController playerController;
    float timer=0.001f;
    public bool gameStart = false;
   

    private void Update()
    {
         
        if (!addingDis && playerController.gameStart)
        {
            addingDis = true;
            StartCoroutine(AddingDis());
        }

    }
    IEnumerator AddingDis()
    {
        
        if (timer < 0.000001f)
            timer = 0.000001f;
        else
            timer -= 0.000001f;
        disRun +=1;
        disDisplay.GetComponent<Text>().text = "" + disRun;
        disEndDisplay.GetComponent<Text>().text = "" + disRun;
        yield return new WaitForSeconds(timer);
        addingDis=false;
    }
}
