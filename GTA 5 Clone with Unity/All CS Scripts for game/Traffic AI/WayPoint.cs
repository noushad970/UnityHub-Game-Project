using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [Header("Waypoint Status")]
    public WayPoint previousWayPoint;
    public WayPoint nextWayPoint;

    [Range(0f, 5f)]
    public float waypointWidth;
    public List<WayPoint> brances =new List<WayPoint>();

    [Range(0f, 1f)]
    public float branchRatio = 0.5f;

    public Vector3 GetPosition()
    {
        Vector3 minbound= transform.position+transform.right*waypointWidth/2f;
        Vector3 maxbound = transform.position - transform.right * waypointWidth / 2f;
        
        return Vector3.Lerp(maxbound, minbound, Random.Range(0.2f,1f));
    }
}
