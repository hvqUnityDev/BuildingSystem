using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;
using UnityEngine.Serialization;

public class GridBuildingSystem : MonoBehaviour
{
    [SerializeField] private PlacedObjectTypeSO placedObjectTypeSO;
    [SerializeField] private LayerMask mouseColliderLayerMark;
    private Grid<GridObject> grid;

    private void Awake()
    {
        int gridWidth = 10, gridHeight = 10;
        float cellSize = 10f;
        
        grid = new Grid<GridObject>(gridWidth, gridHeight, cellSize, Vector3.zero, (Grid<GridObject> g, int x, int y) => new GridObject(g, x, y));
        grid.SetParent(transform);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            grid.GetXZ(GetMouseWorldPosition(), out int x, out int z);
            var listGrid = placedObjectTypeSO.GetGridPositionList(new Vector2Int(x, z), Dir.Down);
            
            var gridObject = grid.GetGridObject(x, z);
            
            
            if (gridObject.CanBuild())
            {
                Transform obj  = Instantiate(placedObjectTypeSO.prefabs, grid.GetWorldPosition(x, z), Quaternion.identity).transform;
                foreach (var position in listGrid)
                {
                    grid.GetGridObject(position.x, position.y).SetTransform(obj);
                }
            }
            else
            {
                UtilsClass.CreateWorldTextPopup("Cannot build here !", GetMouseWorldPosition());
            }
            
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 999f, mouseColliderLayerMark))
        {
            return hit.point;
        }
        
        return  Vector3.zero;
    }
}

