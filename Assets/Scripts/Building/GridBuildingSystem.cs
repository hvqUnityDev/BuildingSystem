using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;
using UnityEngine.Serialization;

public class GridBuildingSystem : MonoBehaviour
{
    public static GridBuildingSystem Ins;
    
    [SerializeField] private List<PlacedObjectTypeSO> placedObjectTypeSOList;

    private PlacedObjectTypeSO placedObjectTypeSO;
    [SerializeField] private LayerMask mouseColliderLayerMark;
    private Grid<GridObject> grid;
    private Dir dir = Dir.Down;

    private void Awake()
    {
        Ins = this;
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
            if (x < 0 || z < 0 || x >= grid.GetWidth() || z >= grid.GetHeight()) {
                if (x != -100 && z != -100)
                {
                    UtilsClass.CreateWorldTextPopup("Cannot build here !", GetMouseWorldPosition());
                }
                
                return;
            }

            if (!placedObjectTypeSO) return;
            
            var listGrid = placedObjectTypeSO.GetGridPositionList(new Vector2Int(x, z), dir);
            if (!grid.CheckCanBuildInList(listGrid) || !CheckCanBuildInList(listGrid)) {
                UtilsClass.CreateWorldTextPopup("Cannot build here !", GetMouseWorldPosition());
                return;
            }
            else {
                Vector2Int rotationOffset = placedObjectTypeSO.GetRotationOffset(dir);
                Vector3 placeObjectWorldPosition =
                    grid.GetWorldPosition(x, z) + new Vector3(rotationOffset.x, 0, rotationOffset.y) * grid.GetCellSize();

                PlaceObject placeObject = PlaceObject.Create(placeObjectWorldPosition, new Vector2Int(x, z), dir, placedObjectTypeSO);

                foreach (var position in listGrid)
                {
                    grid.GetGridObject(position.x, position.y).SetPlaceObject(placeObject);
                }

                DeselectObjectType();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            GridObject gridObject = grid.GetGridObject(GetMouseWorldPosition());
            PlaceObject placeObject = gridObject.GetPlaceObject();
            if (placeObject != null)
            {
                placeObject.DestroySelf();
                
                var listGrid = placeObject.GetGridPositionList();
                foreach (var position in listGrid)
                {
                    grid.GetGridObject(position.x, position.y).ClearPlaceObject();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            dir = PlacedObjectTypeSO.GetNextDir(dir);
            UtilsClass.CreateWorldTextPopup("" + dir, GetMouseWorldPosition());
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetplaceObjectTypeSO(placedObjectTypeSOList[0]); 
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetplaceObjectTypeSO(placedObjectTypeSOList[1]); 
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetplaceObjectTypeSO(placedObjectTypeSOList[2]); 
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetplaceObjectTypeSO(placedObjectTypeSOList[3]); 
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SetplaceObjectTypeSO(placedObjectTypeSOList[4]); 
        }
    }

    public void SetplaceObjectTypeSO(PlacedObjectTypeSO placedObjectTypeSo)
    {
        this.placedObjectTypeSO = placedObjectTypeSo;
        RefreshSelectedObjectType();
    }

    private bool CheckCanBuildInList(List<Vector2Int> listGrid) {
        foreach (var vector in listGrid) {
            var gridObject = grid.GetGridObject(vector.x, vector.y);
            if (!gridObject.CanBuild()) return false;
        }
        return true;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 999f, mouseColliderLayerMark))
        {
            return hit.point;
        }
        
        return  Vector3.one * -100;
    }
    
    private void DeselectObjectType() {
        placedObjectTypeSO = null; RefreshSelectedObjectType();
    }

    public event EventHandler OnSelectedChanged;
    private void RefreshSelectedObjectType() {
        OnSelectedChanged?.Invoke(this, EventArgs.Empty);
    }

    public Vector2Int GetGridPosition(Vector3 worldPosition) {
        grid.GetXZ(worldPosition, out int x, out int z);
        return new Vector2Int(x, z);
    }

    public Vector3 GetMouseWorldSnappedPosition() {
        Vector3 mousePosition = GetMouseWorldPosition();
        grid.GetXZ(mousePosition, out int x, out int z);

        if (placedObjectTypeSO != null) {
            Vector2Int rotationOffset = placedObjectTypeSO.GetRotationOffset(dir);
            Vector3 placedObjectWorldPosition = grid.GetWorldPosition(x, z) + new Vector3(rotationOffset.x, 0, rotationOffset.y) * grid.GetCellSize();
            return placedObjectWorldPosition;
        } else {
            return mousePosition;
        }
    }

    public Quaternion GetPlacedObjectRotation() {
        if (placedObjectTypeSO != null) {
            return Quaternion.Euler(0, placedObjectTypeSO.GetRotationAngle(dir), 0);
        } else {
            return Quaternion.identity;
        }
    }

    public PlacedObjectTypeSO GetPlacedObjectTypeSO() {
        return placedObjectTypeSO;
    }
}

