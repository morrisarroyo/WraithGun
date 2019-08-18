
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Waypoint Path", menuName = "Waypoint Path")]
public class WaypointPath : ScriptableObject
{
    public List<Vector3> waypoints;

    public LinkedList<Vector3> GetPathLinkedList()
    {
        LinkedList<Vector3> path = new LinkedList<Vector3>();
        
        foreach (Vector3 waypoint in waypoints)
        {
            path.AddLast(waypoint);
        }

        return path;
    }
}