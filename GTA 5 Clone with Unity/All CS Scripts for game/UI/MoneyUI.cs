using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public PLayer player;
    public Text moneyAmmountText;

    private void Update()
    {
        moneyAmmountText.text = " " + player.playerMoney;
    }
}
