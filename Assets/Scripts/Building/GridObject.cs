using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    private Grid<GridObject> grid;
    private int x;
    private int z;
    private Transform _transform;
    public GridObject(Grid<GridObject> grid, int x, int z)
    {
        this.grid = grid;
        this.x = x;
        this.z = z;
    }

    public void SetTransform(Transform transform)
    {
        _transform = transform;
        grid.TriggerGridObjectChanged(x, z);
    }

    public override string ToString()
    {
        return x + "," + z + "\n" + _transform;
    }

    public bool CanBuild()
    {
        return _transform == null;
    }
}
