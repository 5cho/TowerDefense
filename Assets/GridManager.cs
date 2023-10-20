using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
public class GridManager : MonoBehaviour
{
    public static GridManager Instance { get; private set; }

    [SerializeField] private Tilemap buildableLayer;
    [SerializeField] private Tile buildTile;

    [SerializeField] private int numberOfBuildingsAllowed = 3;
    private int currentNumberOfBuildings = 0;

    public event EventHandler OnBuilt;

    [SerializeField] private Transform selectedTower;

    private bool canBuild;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        SetCanBuild();
        if (Input.GetMouseButtonDown(0))
        {
            Build();
        }
    }
    private Vector2Int GetMouseGridPosition()
    {
        Vector3 mousePositionScreen = Input.mousePosition;
        Vector3 mousePositionWorld = Camera.main.ScreenToWorldPoint(mousePositionScreen);
        Vector2Int mouseGridPosition = new Vector2Int(Mathf.FloorToInt(mousePositionWorld.x), Mathf.FloorToInt(mousePositionWorld.y));
        return mouseGridPosition;
    }
    public void SetCanBuild()
    {
        if (!buildableLayer.HasTile(new Vector3Int(GetMouseGridPosition().x, GetMouseGridPosition().y, 0)))
        {
            canBuild = true;
        }
        else
        {
            canBuild = false;
        }
    }
    public bool GetCanBuild()
    {
        return canBuild;
    }
    public void Build()
    {
        if (canBuild && currentNumberOfBuildings < numberOfBuildingsAllowed)
        {
            Vector3Int gridSpawnPosition = new Vector3Int(GetMouseGridPosition().x, GetMouseGridPosition().y, 0);
            buildableLayer.SetTile(gridSpawnPosition, buildTile);
            Vector3 spawnOffset = new Vector3(0.5f, 0.25f, 0f);
            Instantiate(selectedTower, gridSpawnPosition + spawnOffset, Quaternion.identity);
            currentNumberOfBuildings++;
            OnBuilt?.Invoke(this, EventArgs.Empty);
            selectedTower = null;
        }
    }
    public void SetSelectedTower(Transform selectedTowerToSet)
    {
        selectedTower = selectedTowerToSet;
    }
    public int GetNumberOfBuildingsAvailable()
    {
        return numberOfBuildingsAllowed - currentNumberOfBuildings;
    }
}
