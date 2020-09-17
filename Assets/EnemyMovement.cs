using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{   
    [SerializeField] List<WayPoint> path;
    // Start is called before the first frame update
    void Start()
    {
        print("Starting patrol");
        StartCoroutine(PrintAllWaypoints());
    }

    IEnumerator PrintAllWaypoints(){
        foreach (WayPoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            print("Visiting position " + waypoint);
            yield return new WaitForSeconds(1f);
        }
        print("Patrol is over");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
