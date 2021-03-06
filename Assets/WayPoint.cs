﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{   
    [SerializeField] Color exploredColor;
    public bool isExplored = false;
    public WayPoint exploredFrom;
    Vector2Int gridPos;
    const int gridSize = 10;
    // Start is called before the first frame update
    public Vector2Int GetGridPos(){
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x/gridSize),
            Mathf.RoundToInt(transform.position.z/gridSize)
        );
    }
    public int GetGridSize(){
        return gridSize;
    }

    public void SetTopColor(Color color)
    {
        var topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
    }
}
