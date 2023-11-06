using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData {

    public int coins;
    public int PreviousScore;

    public GameData(GameOver playerstat)
    {
        PreviousScore = playerstat.PreviousScore;
        coins = playerstat.coins;
    }
   
}
