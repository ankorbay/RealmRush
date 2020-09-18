using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pathfinder : MonoBehaviour
{   
    [SerializeField] WayPoint startWaypoint, endWaypoint;
    Dictionary<Vector2Int, WayPoint> grid = new Dictionary<Vector2Int, WayPoint>();
    Queue<WayPoint> queue = new Queue<WayPoint>();
    WayPoint searchCenter;

    bool isRunning = true;
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    // Start is called before the first frame update
    
    void Start()
    {
        LoadBlocks();
        PathFind();
        ColorStartAndEnd();
    }
    private void HaltIfEndFound(){
        if(searchCenter == endWaypoint){
            isRunning = false;
        }
    }
    private void PathFind(){

        queue.Enqueue(startWaypoint);

        while (queue.Count > 0 && isRunning)
        {
            searchCenter = queue.Dequeue();
            searchCenter.isExplored = true;
            HaltIfEndFound();
            ExploreNeighbours();
        }
    }
    private void ExploreNeighbours(){
        if(!isRunning) return;
        
        foreach (var direction in directions)
        {   
            Vector2Int neighbourCoords = searchCenter.GetGridPos() + direction;
            try
            {   
                QueueNewNeibours(neighbourCoords);
            }
            catch
            {

            }
        }
    }

    private void QueueNewNeibours(Vector2Int neighbourCoords){
        WayPoint neighbour = grid[neighbourCoords];
        if(!neighbour.isExplored || queue.Contains(neighbour)) 
        {
            queue.Enqueue(neighbour);
            neighbour.exploredFrom = searchCenter;
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
                // waypoint.SetTopColor(Color.black);
            }
        }
        // print(grid.Count);
    }
}
