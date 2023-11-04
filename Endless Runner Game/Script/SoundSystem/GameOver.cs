using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
    public bool Gameover=false;
    public GameObject gameOverScore;
    public GameObject ScoreHide;
    private void Update()
    {
        if (Gameover)
        {
            StartCoroutine(wait1Sec());
           
        }
    }
    IEnumerator wait1Sec()
    {
        yield return new WaitForSeconds(3f);
        gameOverScore.SetActive(true);
        ScoreHide.SetActive(false);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}
