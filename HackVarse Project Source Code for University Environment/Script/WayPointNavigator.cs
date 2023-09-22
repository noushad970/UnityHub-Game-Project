using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointNavigator : MonoBehaviour
{
    [Header("NPC Character")]
    public CharacterNavigator character;
    public WayPoint currentWaypoint;

    private void Awake()
    {
        character = GetComponent<CharacterNavigator>();
    }

    private void Start()
    {
        character.LocateDestination(currentWaypoint.GetPosition());
    }

    private void Update()
    {
        if (character.destinationReached)
        {
            currentWaypoint = currentWaypoint.nextWayPoint;
            character.LocateDestination(currentWaypoint.GetPosition());
        }
    }

}
