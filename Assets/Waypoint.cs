using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Waypoint nextWaypoint;
    public Waypoint link;
    public Waypoint link_nr2;

    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, 0.1f);
    }

}
