using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] private Color nonPlaceableColor = Color.gray;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] private Color pathColor = Color.magenta;
    
    private TextMeshPro label;
    private Vector2Int coordinates = new Vector2Int();
    private GridManager gridManager;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
        label.renderer.enabled = true;
    }

    private void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
        SetCoordinateLabelColor();
        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleLabels();
        }
    }

    private void SetCoordinateLabelColor()
    {
        if (gridManager == null){return;}

        Node node = gridManager.GetNode(coordinates);
        
        if(node==null){return;}

        if (!node.isWalkable)
        {
            label.color = nonPlaceableColor;
        }
        else if (node.isPath)
        {
            label.color = pathColor;
        }
        else if (node.isExplored)
        {
            label.color = exploredColor;
        }
        else
        {
            label.color = defaultColor;
        }
    }
    private void DisplayCoordinates()
    {
        if(gridManager == null){return;}
        Vector3 parentPos = transform.parent.position;
        float parentPosX = parentPos.x / gridManager.UnityGridSize;
        float parentPosY = parentPos.z / gridManager.UnityGridSize;
        coordinates.x = Mathf.RoundToInt(parentPosX);
        coordinates.y = Mathf.RoundToInt(parentPosY);
        label.text = $"{coordinates.x},{coordinates.y}";
    }

    private void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }

    private void ToggleLabels()
    {
        label.renderer.enabled = !label.renderer.enabled;
        
    }
}