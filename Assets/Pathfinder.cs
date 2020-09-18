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

    private List<WayPoint> path = new List<WayPoint>();
    bool isRunning = true;
    Vector2Int[] directions = {
        Vector2Int.up,
        Vector2Int.right,
        Vector2Int.down,
        Vector2Int.left
    };
    // Start is called before the first frame update

    public List<WayPoint> GetThePath(){
        LoadBlocks();
        ColorStartAndEnd(); // todo consider moving out
        BreadthFirstSearch();
        CreatePath();
        return path;
    }
    private void CreatePath(){
        path.Add(endWaypoint);
        WayPoint previous = endWaypoint.exploredFrom;

        while (previous != startWaypoint)
        {
            path.Add(previous);
            previous = previous.exploredFrom;
        };
        path.Add(startWaypoint);
        path.Reverse();
    }
    private void HaltIfEndFound(){
        if(searchCenter == endWaypoint){
            isRunning = false;
        }
    }
    private void BreadthFirstSearch(){

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
            if(grid.ContainsKey(neighbourCoords)){
                QueueNewNeibours(neighbourCoords);
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
