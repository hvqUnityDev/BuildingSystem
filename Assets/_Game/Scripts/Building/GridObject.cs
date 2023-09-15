using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject : MonoBehaviour
{
    private Grid<GridObject> grid;
    private int x;
    private int z;
    private PlaceObject placeObject;
    public GridObject(Grid<GridObject> grid, int x, int z)
    {
        this.grid = grid;
        this.x = x;
        this.z = z;
    }

    public void SetPlaceObject(PlaceObject placeObject)
    {
        this.placeObject = placeObject;
        grid.TriggerGridObjectChanged(x, z);
    }

    public override string ToString()
    {
        return x + "," + z + "\n" + placeObject;
    }

    public bool CanBuild()
    {
        return placeObject == null;
    }

    public void ClearPlaceObject()
    {
        this.placeObject = null;
        grid.TriggerGridObjectChanged(x, z);
    }

    public PlaceObject GetPlaceObject()
    {
        return placeObject;
    }
}
