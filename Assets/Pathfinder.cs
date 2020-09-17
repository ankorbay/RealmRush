using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pathfinder : MonoBehaviour
{   
    [SerializeField] WayPoint startWaypoint, endWaypoint;
    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    // Start is called before the first frame update
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
    }

    private void ColorStartAndEnd(){
        startWaypoint.SetTopColor(Color.yellow);
        endWaypoint.SetTopColor(Color.red);
    }

    private void LoadBlocks(){
        var waypoints = FindObjectsOfType<WayPoint>();
        foreach (WayPoint waypoint in waypoints)
        {   
            var gridPos = waypoint.GetGridPos();

            if (grid.ContainsKey(gridPos))
            {
                Debug.LogWarning("Skipping " + gridPos);
            } 
            else 
            {
                grid.Add(gridPos,waypoint);
                waypoint.SetTopColor(Color.black);
            }
        }
        print(grid.Count);
    }
}
