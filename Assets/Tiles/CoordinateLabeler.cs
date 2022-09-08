using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
public class CoordinateLabeler : MonoBehaviour
{
    private TextMeshPro label;
    private Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }

    private void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
    }

    private void DisplayCoordinates()
    {
        Vector3 parentPos = transform.parent.position;
        float parentPosX = parentPos.x / UnityEditor.EditorSnapSettings.move.x;
        float parentPosY = parentPos.z / UnityEditor.EditorSnapSettings.move.z;
        coordinates.x = Mathf.RoundToInt(parentPosX);
        coordinates.y = Mathf.RoundToInt(parentPosY);
        label.text = $"{coordinates.x},{coordinates.y}";
    }

    private void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }
}