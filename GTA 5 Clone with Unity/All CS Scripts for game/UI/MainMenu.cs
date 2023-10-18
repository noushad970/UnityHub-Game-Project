using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public bool continueGame=false;
    public bool StartGame=false;
    public Animator animator;

    public static MainMenu instance;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        instance = this;
    }

    public void onContinueButton()
    {
        Debug.Log("Continue");
        continueGame = true;
        SceneManager.LoadScene("Town");
    }
    public void onStartButton()
    {
        Debug.Log("Starting");
        StartGame = true;
        SceneManager.LoadScene("Town");
        //animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("PlayerController");
    }
    public void onQuitButton()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
