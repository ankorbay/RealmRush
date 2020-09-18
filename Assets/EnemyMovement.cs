using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    
    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        List<WayPoint> path = pathfinder.GetThePath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<WayPoint> path){
        print("Starting patrol");
        foreach (WayPoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            print("Visiting position " + waypoint);
            yield return new WaitForSeconds(1f);
        }
        print("Patrol is over");
    }
}
