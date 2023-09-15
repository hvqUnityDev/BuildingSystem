using System;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine;

public class Testing : MonoBehaviour
{
    // =================First==========================
    // private Grid<HeatMapGridObject> grid;
    // [SerializeField] private HeatMapBoolVisual heatMapBoolVisual;
    // [SerializeField] private HeatMapGenericVisual heatMapGenericVisual;
    //
    // private void Start()
    // {
    //     grid = new Grid<HeatMapGridObject>(20, 10, 10, new Vector3(-10,0), (Grid<HeatMapGridObject> g, int x, int y) => new HeatMapGridObject(g, x, y));
    //     heatMapGenericVisual.SetGrid(grid);
    // }
    //
    // private void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         HeatMapGridObject heatMapGridObject = grid.GetGridObject(UtilsClass.GetMouseWorldPosition());
    //         if (heatMapGridObject != null)
    //         {
    //             heatMapGridObject.AddValue(1);
    //         }
    //     }
    //
    //     if (Input.GetMouseButtonDown(1))
    //     {
    //         HeatMapGridObject heatMapGridObject = grid.GetGridObject(UtilsClass.GetMouseWorldPosition());
    //         if (heatMapGridObject != null)
    //         {
    //             heatMapGridObject.GetValueNormalized();
    //         }
    //     }
    // }
    
    // =================Second==========================
    private Pathfinding pathfinding;
    private void Start()
    {
        pathfinding = new Pathfinding(10, 10);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = UtilsClass.GetMouseWorldPosition();
            pathfinding.GetGrid().GetXZ(mouseWorldPosition, out int x, out int y);
            List<PathNode> path = pathfinding.FindPath(0, 0, x, y);
            if (path != null)
            {
                for (int i = 0; i < path.Count-1; i++)
                {
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i+1].x, path[i+1].y) * 10f + Vector3.one * 5f, Color.green);
                }
            }
        }
    }
}

public class HeatMapGridObject
{
    private const int Min = 0;
    private const int Max = 100;

    private Grid<HeatMapGridObject> grid;
    private int value;

    private int x, y;

    public HeatMapGridObject(Grid<HeatMapGridObject> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x;
        this.y = y;
    }

    public void AddValue(int addValue)
    {
        value = Mathf.Clamp(value += addValue, Min, Max);
        grid.TriggerGridObjectChanged(x,y);
    }

    public float GetValueNormalized()
    {
        return (float)value / Max;
    }
    
    public override string ToString()
    {
        return value.ToString();
    }
}
