using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStates : MonoBehaviour
{
    [SerializeField]
    private Image health_stat, Stamina_stat;
    public void HealthStates(float HealthValue)
    {
        HealthValue /= 100f;
        health_stat.fillAmount = HealthValue;
    }
    public void StaminaStates(float StaminaValue)
    {
        StaminaValue /= 100f;
        Stamina_stat.fillAmount = StaminaValue;
    }
}
