using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private bool isPlaceable = true;
    public bool IsPlaceable { get { return isPlaceable; } }
    
    [SerializeField] private Tower towerPrefab; 

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            var isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !isPlaced;
        }
    }
}
