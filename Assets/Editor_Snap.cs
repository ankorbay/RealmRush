﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Editor_Snap : MonoBehaviour
{
    // Update is called once per frame
    [Range(1f,20f)][SerializeField] float gridSize = 10f;
    void Update()
    {
        Vector3 snapPos;

        snapPos.x = Mathf.RoundToInt(transform.position.x/gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z/gridSize) * gridSize;

        transform.position = new Vector3(snapPos.x,0f, snapPos.z);
    }
}