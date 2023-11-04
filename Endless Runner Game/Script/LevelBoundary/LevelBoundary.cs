using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    public static float Leftside=-3.5f;
    public static float Rightside=3.5f;
    public float internalLeftSide;
    public float internalRightSide;
    // Update is called once per frame
    void Update()
    {
        internalLeftSide = Leftside;
        internalRightSide = Rightside;
    }
}
