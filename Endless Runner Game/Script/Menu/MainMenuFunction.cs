using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour
{
    // Start is called before the first frame update

    public GameOver isOver;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        isOver.Gameover = false;
        SceneManager.LoadScene(1);
    }
    public void Option()
    {
       //option screen
    }
    public void Shop()
    {
        //Shop screen
    }
    public void About()
    {
        //About screen
    }
    public void Quit()
    {
        Application.Quit();
    }
}
