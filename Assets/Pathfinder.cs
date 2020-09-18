using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pathfinder : MonoBehaviour
{   
    [SerializeField] WayPoint startWaypoint, endWaypoint;
    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    Queue<WayPoint> queue = new Queue<WayPoint>();
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    // Start is called before the first frame update
    
    private void Awake(){
        ColorStartAndEnd();
    }
    void Start()
    {
        LoadBlocks();
        ColorStartAndEnd();
        PathFind();
        // ExploreNeighbours();
    }
    private void HaltIfEndFound(WayPoint searchCenter){
        if(searchCenter == endWaypoint){
            print("Search stopped");
            return;
        }
    }
    private void PathFind(){

        queue.Enqueue(startWaypoint);

        while (queue.Count > 0)
        {
            var serchCenter = queue.Dequeue();
            print("Searching from the " + serchCenter);
            HaltIfEndFound(serchCenter);
        }
    }
    private void ExploreNeighbours(){
        foreach (var direction in directions)
        {   
            Vector2Int explorationCoords = startWaypoint.GetGridPos() + direction;
            try
            {
                grid[explorationCoords].SetTopColor(Color.white);
            }
            catch
            {

            }
        }
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
        // print(grid.Count);
    }
}
