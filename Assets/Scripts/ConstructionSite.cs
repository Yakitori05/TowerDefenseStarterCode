using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ConstructionSite
{
    public Vector3Int TilePosition { get; set; } // Tile Position of the construction site
    public Vector3 WorldPosition { get; set; } // World Position of the construction site
    public SiteLevel Level { get; private set; } // Level of the construction site
    public TowerType TowerType { get; private set; } // Type of tower on the construction site

    private GameObject tower; // Reference to the tower GameObject placed on this construction site
    public System.Action<GameObject> onDestroyTowerCallback;

    public ConstructionSite(Vector3Int tilePosition, Vector3 worldPosition, System.Action<GameObject> onDestroyTower)
    {
        // Assign the tilePosition and adjust the worldPosition's y value by adding 0.5
        this.TilePosition = tilePosition;
        this.WorldPosition = worldPosition + new Vector3(0, 0.5f, 0);
        this.Level = SiteLevel.Onbebouwd; // Assuming starting level is Empty
        this.TowerType = TowerType; // Assuming no tower type initially
        this.tower = null; // No tower initially placed
        this.onDestroyTowerCallback = onDestroyTower;
    }

    public void SetTower(GameObject towerPrefab, SiteLevel level, TowerType type)
    {
        // Check if there's already a tower placed on this site
        if (tower != null)
        {
            onDestroyTowerCallback?.Invoke(tower);
        }        

        TowerPlacementManager.Instance.InstantiateTower(towerPrefab, WorldPosition, level, type);

        // Assign the level and type of the tower
        this.Level = level;
        this.TowerType = type;
    }


}
