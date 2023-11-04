using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarterCounDown : MonoBehaviour
{
    public GameObject fadedScreen;
    public GameObject Count3;
    public GameObject Count2;
    public GameObject Count1;
    public GameObject GoCount;
    public AudioSource countDownSound;
    public AudioSource goSound;
    void Start()
    {
        StartCoroutine(CountSequence());
    }
    IEnumerator CountSequence()
    {
        fadedScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        Count3.SetActive(true);
        countDownSound.Play();
        yield return new WaitForSeconds(1f);
        Count2.SetActive(true);
        yield return new WaitForSeconds(1f);
        Count1.SetActive(true);
        yield return new WaitForSeconds(1f);
        GoCount.SetActive(true);
        goSound.Play();
        yield return new WaitForSeconds(1f);
        fadedScreen.SetActive(false);
        Count3.SetActive(false);
        Count2.SetActive(false); 
        GoCount.SetActive(false);
        Count1.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
