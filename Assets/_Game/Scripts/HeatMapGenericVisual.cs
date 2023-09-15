using System;
using UnityEngine;

public class HeatMapGenericVisual : MonoBehaviour
{
    private Grid<HeatMapGridObject> grid;
    private MeshFilter meshFilter;
    private bool updateMesh;
    
    public HeatMapGenericVisual(Grid<HeatMapGridObject> grid, MeshFilter meshFilter)
    {
        this.grid = grid;
        this.meshFilter = meshFilter;
        UpdateheatMapVisual();

        grid.OnGridValueChanged += Grid_OnGridValueChanged;
    }
    
    private void Grid_OnGridValueChanged(object sender, Grid<HeatMapGridObject>.OnGridValueChangedEventArgs e)
    {
        UpdateheatMapVisual();
    }

    private void LateUpdate()
    {
        if (updateMesh)
        {
            updateMesh = false;
            UpdateheatMapVisual();
        }
    }

    public void UpdateheatMapVisual()
    {

        Vector3[] vertices;
        Vector2[] uv;
        int[] triangles;   
            
        MeshUtils.CreateEmptyMeshArrays(grid.GetWidth() * grid.GetHeight(), out vertices, out uv, out triangles);

        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                int index = x * grid.GetHeight() + y;
                Vector3 baseSize = new Vector3(1, 1) * grid.GetCellSize();
                HeatMapGridObject gridvValue = grid.GetGridObject(x, y);  
                //grid.SetGridObject(x, y, gridvValue);
                float gridValueNormalized = gridvValue.GetValueNormalized();
                Vector2 gridValueUV = new Vector2(gridValueNormalized, 0f);
                MeshUtils.AddToMeshArrays(vertices, uv, triangles, index, grid.GetWorldPosition(x, y), 0f, baseSize, gridValueUV,gridValueUV);
            }
        }
            
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;

        meshFilter.mesh = mesh;
    }

    public void SetGrid(Grid<HeatMapGridObject> grid)
    {
        this.grid = grid;
        this.meshFilter = GetComponent<MeshFilter>();
        UpdateheatMapVisual();

        grid.OnGridValueChanged += Grid_OnGridValueChanged;
    }
}