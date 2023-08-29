using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;
using UnityEngine.Serialization;

public class GridBuildingSystem : MonoBehaviour
{
    [SerializeField] private List<PlacedObjectTypeSO> placedObjectTypeSOList;
    
    private PlacedObjectTypeSO placedObjectTypeSO;
    [SerializeField] private LayerMask mouseColliderLayerMark;
    private Grid<GridObject> grid;
    private Dir dir = Dir.Down;

    private void Awake()
    {
        int gridWidth = 10, gridHeight = 10;
        float cellSize = 10f;
        
        grid = new Grid<GridObject>(gridWidth, gridHeight, cellSize, Vector3.zero, (Grid<GridObject> g, int x, int y) => new GridObject(g, x, y));
        grid.SetParent(transform);
        placedObjectTypeSO = placedObjectTypeSOList[0];
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            grid.GetXZ(GetMouseWorldPosition(), out int x, out int z);
            var listGrid = placedObjectTypeSO.GetGridPositionList(new Vector2Int(x, z), dir);
            var gridObject = grid.GetGridObject(x, z);
            
            if (gridObject.CanBuild())
            {
                Vector2Int rotationOffset = placedObjectTypeSO.GetRotationOffset(dir);
                Vector3 placeObjectWorldPosition =
                    grid.GetWorldPosition(x, z) + new Vector3(rotationOffset.x, 0, rotationOffset.y) * grid.GetCellSize();

                Transform obj  
                    = Instantiate(
                        placedObjectTypeSO.prefabs, 
                        placeObjectWorldPosition, 
                        Quaternion.Euler(0, placedObjectTypeSO.GetRotationAngle(dir), 0)).transform;
                
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

        if (Input.GetKeyDown(KeyCode.R))
        {
            dir = PlacedObjectTypeSO.GetNextDir(dir);
            UtilsClass.CreateWorldTextPopup("" + dir, GetMouseWorldPosition());
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) { placedObjectTypeSO = placedObjectTypeSOList[0]; }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { placedObjectTypeSO = placedObjectTypeSOList[1]; }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { placedObjectTypeSO = placedObjectTypeSOList[2]; }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { placedObjectTypeSO = placedObjectTypeSOList[3]; }
        if (Input.GetKeyDown(KeyCode.Alpha5)) { placedObjectTypeSO = placedObjectTypeSOList[4]; }
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

