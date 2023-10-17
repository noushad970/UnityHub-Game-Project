using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickItemEffect : MonoBehaviour
{
    public Light light;
    public float lawlimit = .6f;
    public float maxlimit = 1.5f;
    public float effectincrease = 0.4f;
    private void Awake()
    {
        light = GetComponent<Light>();
        light.range = lawlimit;
    }

    void Update()
    {
        glowEffect();
    }
    void glowEffect()
    {

        light.range+= effectincrease * Time.deltaTime;
        if (light.range >= maxlimit)
            light.range = lawlimit;

    }

}
