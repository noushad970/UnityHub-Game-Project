using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCoinAndHighScore : MonoBehaviour
{
    public Text totalcoin;
    public Text highScore;
    
    private void Start()
    {
        //for coin collect
        if (PlayerPrefs.HasKey("Coinsum"))
        {
            CollectCoin.coins = PlayerPrefs.GetInt("Coinsum");
        }
        else
        {
            PlayerPrefs.SetInt("Coinsum", CollectCoin.coins);
            PlayerPrefs.Save();
        }
        totalcoin.GetComponent<Text>().text = "" + CollectCoin.coins;

        //highScore
        if (PlayerPrefs.HasKey("HighScores"))
        {
            LevelDistance.highScore = PlayerPrefs.GetInt("HighScores");
        }
        else
        {
            PlayerPrefs.SetInt("HighScores", LevelDistance.highScore);
            PlayerPrefs.Save();
        }
        highScore.GetComponent<Text>().text = LevelDistance.highScore.ToString();
    }
    private void Update()
    {
        totalcoin.GetComponent<Text>().text = "" + CollectCoin.coins;
        if (LevelDistance.disRun > PlayerPrefs.GetInt("HighScores"))
        {

            LevelDistance.highScore = LevelDistance.disRun;
        }
        PlayerPrefs.SetInt("HighScores", LevelDistance.highScore);
        PlayerPrefs.Save();
        highScore.GetComponent<Text>().text = LevelDistance.highScore.ToString();
    }
}
//
