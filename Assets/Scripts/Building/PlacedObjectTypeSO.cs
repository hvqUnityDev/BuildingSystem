using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu()]
public class PlacedObjectTypeSO : ScriptableObject
{
    public string nameString;
    public Transform prefabs;
    public Transform visual;
    public int width;
    public int height;

    public static Dir GetNextFir(Dir dir)
    {
        Debug.Log("TODO");
        return dir;
    }

    public int GetRotationAngle(Dir dir)
    {
        Debug.Log("TODO");
        return 0;
    }

    public Vector2Int GetRotationOffset(Dir dir)
    {
        Debug.Log("TODO");
        return new Vector2Int();
    }

    public List<Vector2Int> GetGridPositionList(Vector2Int offset, Dir dir)
    {
        List<Vector2Int> gridPositionlist = new List<Vector2Int>();
        switch (dir)
        {
            default:
            case Dir.Down:
            case Dir.Up:
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        gridPositionlist.Add(offset + new Vector2Int(x, y));
                    }
                }

                break;
            case Dir.Left:
            case Dir.Right:
                for (int x = 0; x < height; x++)
                {
                    for (int y = 0; y < width ; y++)
                    {
                        gridPositionlist.Add(offset + new Vector2Int(x, y));
                    }
                }

                break;

        }
        return gridPositionlist;
    }
}

public enum Dir
{
    Down,
    Up,
    Left,
    Right
}
