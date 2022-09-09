using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color placeableColor = Color.white;
    [SerializeField] private Color nonPlaceableColor = Color.gray;

    private Waypoint waypoint;
    private TextMeshPro label;
    private Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
        waypoint = GetComponentInParent<Waypoint>();
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
        if (waypoint.IsPlaceable)
        {
            label.color = placeableColor;
        }
        else
        {
            label.color = nonPlaceableColor;
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

    private void ToggleLabels()
    {
        label.renderer.enabled = !label.renderer.enabled;
        
    }
}