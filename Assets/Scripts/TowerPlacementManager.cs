using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacementManager : MonoBehaviour
{
    public static TowerPlacementManager Instance {  get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);
    }

    public void InstantiateTower (GameObject towerPrefab, Vector3 position, SiteLevel level, TowerType type)
    {
        GameObject newTower = Instantiate(towerPrefab, position,Quaternion.identity);
    }


    private void onDestroyTower(GameObject tower)
    {
        GameObject.Destroy(tower);
    }
}
