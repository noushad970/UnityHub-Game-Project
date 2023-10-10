using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceNPCWayPointNagivator02 : MonoBehaviour
{
    [Header("NPC Character")]
    public PoliceOfficerL2 character;
    public WayPoint currentWaypoint;
    int direction;
    private void Awake()
    {
        character = GetComponent<PoliceOfficerL2>();
    }

    private void Start()
    {
        direction = Mathf.RoundToInt(Random.Range(0f, 1f));
        character.LocateDestination(currentWaypoint.GetPosition());
    }

    private void Update()
    {
        if (character.destinationReached)
        {
            //bool shouldBranch = false;
            //if (currentWaypoint.brances != null && currentWaypoint.brances.Count > 0)
            //{
            //    shouldBranch = Random.Range(0f, 1f) <= currentWaypoint.branchRatio ? true : false;
            //}
            //if (shouldBranch)
            //{
            //    currentWaypoint = currentWaypoint.brances[Random.Range(0, currentWaypoint.brances.Count - 1)];
            //}
            //else
            //{
            //    if (direction == 0)
            //    {
            //        if (currentWaypoint.nextWayPoint != null)
            //        {
            //            currentWaypoint = currentWaypoint.nextWayPoint;
            //        }
            //        else
            //        {
            //            currentWaypoint = currentWaypoint.previousWayPoint;
            //            direction = 1;
            //        }
            //    }
            //    else if (direction == 1)
            //    {
            //        if (currentWaypoint.previousWayPoint != null)
            //        {
            //            currentWaypoint = currentWaypoint.previousWayPoint;
            //        }
            //        else
            //        {
            //            currentWaypoint = currentWaypoint.nextWayPoint;
            //            direction = 0;
            //        }
            //    }
            //}

            //character.LocateDestination(currentWaypoint.GetPosition());
            if (direction == 0)
            {
                if (currentWaypoint.nextWayPoint != null)
                {
                    currentWaypoint = currentWaypoint.nextWayPoint;
                }
                else
                {
                    currentWaypoint = currentWaypoint.previousWayPoint;
                    direction = 1;
                }
            }
            else if (direction == 1)
            {
                if (currentWaypoint.previousWayPoint != null)
                {
                    currentWaypoint = currentWaypoint.previousWayPoint;
                }
                else
                {
                    currentWaypoint = currentWaypoint.nextWayPoint;
                    direction = 0;
                }
            }



            character.LocateDestination(currentWaypoint.GetPosition());

        }
    }
}
