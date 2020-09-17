using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    Vector2Int gridPos;
    const int gridSize = 10;
    // Start is called before the first frame update
    public Vector2 GetGridPos(){
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x/gridSize),
            Mathf.RoundToInt(transform.position.z/gridSize)
        );
    }
    public int GetGridSize(){
        return gridSize;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
