using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputSimulator : MonoBehaviour
{
    public static void KeyDown(KeyCode key)
    {
        var keyEvent = new Event { type = EventType.KeyDown, keyCode = key };
    //    Input.eventHandler.HandleEvent(keyEvent, true);
    }

    public static void KeyUp(KeyCode key)
    {
        var keyEvent = new Event { type = EventType.KeyUp, keyCode = key };
    //    Input.eventHandler.HandleEvent(keyEvent, true);
    }
}
