using System;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;

public class Grid<TGridObject> 
{
    public const int HEAT_MAP_MAX_VALUE = 100;
    public const int HEAT_MAP_MIN_VALUE = 0;
    
    public event EventHandler<OnGridValueChangedEventArgs> OnGridValueChanged;

    public class OnGridValueChangedEventArgs : EventArgs
    {
        public int x;
        public int z;
    }
    
    private int width;
    private int height;
    private float cellSize;
    private Vector3 originPosition;
    private TGridObject[,] gridArray;
    private TextMesh[,] debugTextArray;
    private Transform parent;

    public void SetParent(Transform parent)
    {
        this.parent = parent;
        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                debugTextArray[x,z].transform.SetParent(parent);
            }
        }
    }

    public Grid(int width, int height, float cellSize, Vector3 originPosition, Func<Grid<TGridObject>, int, int, TGridObject> createGridObject)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;
        this.originPosition = originPosition;

        gridArray = new TGridObject[width, height];
        debugTextArray = new TextMesh[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                gridArray[x, z] = createGridObject(this, x ,z);
            }
        }

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int z = 0; z < gridArray.GetLength(1); z++)
            {
                debugTextArray[x,z] = UtilsClass.CreateWorldText(gridArray[x, z]?.ToString(), null, GetWorldPosition(x, z) + new Vector3(cellSize, 0, cellSize) * 0.5f, 20, Color.white,
                    TextAnchor.MiddleCenter);
                
                Debug.DrawLine(GetWorldPosition(x,z), GetWorldPosition(x,z+1),Color.white, 100f);
                Debug.DrawLine(GetWorldPosition(x,z), GetWorldPosition(x+1,z),Color.white, 100f);
                
            }
        }
        
        Debug.DrawLine(GetWorldPosition(0,height), GetWorldPosition(width,height),Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width,height),Color.white, 100f);

        OnGridValueChanged += (object sender, OnGridValueChangedEventArgs eventArgs) =>
        {
            debugTextArray[eventArgs.x, eventArgs.z].text = gridArray[eventArgs.x, eventArgs.z]?.ToString();
        };
        
    }

    public int GetWidth()
    {
        return width;
    }

    public int GetHeight()
    {
        return height;
    }

    public float GetCellSize()
    {
        return cellSize;
    }

    public Vector3 GetWorldPosition(int x, int z)
    {
        return new Vector3(x, 0, z) * cellSize + originPosition;
    }

    public void SetGridObject(int x, int z, TGridObject value)
    {
        if (x >= 0 && z >= 0 && x < width && z < height)
        {
            gridArray[x, z] = value;
            debugTextArray[x, z].text = gridArray[x, z].ToString();
            TriggerGridObjectChanged(x, z);
        }
    }

    public void TriggerGridObjectChanged(int x, int z)
    {
        OnGridValueChanged?.Invoke(this, new OnGridValueChangedEventArgs(){x = x, z = z});
    }

    public void GetXZ(Vector3 worldPosition, out int x, out int z)
    {
        x = Mathf.FloorToInt((worldPosition - originPosition).x / cellSize);
        z = Mathf.FloorToInt((worldPosition - originPosition).z / cellSize);
    }

    public void SetGridObject(Vector3 worldPosition, TGridObject value)
    {
        int x, z;
        GetXZ(worldPosition, out x, out z);
        SetGridObject(x, z, value);
    }

    public TGridObject GetGridObject(Vector3 worldPosition)
    {
        int x, z;
        GetXZ(worldPosition, out x, out z);
        return GetGridObject(x, z);
    }

    public TGridObject GetGridObject(int x, int z)
    {
        if (x >= 0 && z >= 0 && x < width && z < height)
        {
            return gridArray[x, z];
        }

        return default(TGridObject);
    }

    public bool CheckCanBuildInList(List<Vector2Int> list) {
        foreach (var vector in list) {
            if (vector.x < 0 || vector.y < 0 || vector.x >= width || vector.y >= height) {
                return false;
            }
        }

        return true;
    }
}
