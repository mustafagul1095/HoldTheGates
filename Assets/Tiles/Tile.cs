using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private bool isPlaceable = true;
    public bool IsPlaceable { get { return isPlaceable; } }
    
    [SerializeField] private Tower towerPrefab;

    private GridManager gridManager;
    private Pathfinder pathfinder;
    
    private Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    private void Start()
    {
        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);

            if (!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    private void OnMouseDown()
    {
        if (gridManager.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates))
        {
            var isPlaced = towerPrefab.CreateTower(towerPrefab, transform.position);
            if (isPlaced)
            {
                gridManager.BlockNode(coordinates);
                //pathfinder.NotifyReceivers();
            }
        }
    }
}
