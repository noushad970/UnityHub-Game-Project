using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoCount : MonoBehaviour
{
    public Text ammunationText;
    public Text magText;

    public static AmmoCount Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void UpdateAmmo(int presentAmmunition)
    {
        ammunationText.text = "" + presentAmmunition;

    }
    public void updateMagText(int mag)
    {
        magText.text = "" + mag;
    }


}
