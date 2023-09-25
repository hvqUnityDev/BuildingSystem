using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu()]
public class PlacedObjectTypeSO : ScriptableObject
{
    [Header("Info to Spawn")]
    public string nameString;
    public Transform prefabs;
    public Transform visual;
    public int width;
    public int height;
    public int price;

    public static Dir GetNextDir(Dir dir)
    {
        switch (dir)
        {
            default:
            case Dir.Down: return Dir.Left;
            case Dir.Left: return Dir.Up;
            case Dir.Up: return Dir.Right;
            case Dir.Right: return Dir.Down;
        }
    }

    public int GetRotationAngle(Dir dir)
    {
        switch (dir)
        {
            default:
            case Dir.Down: return 0;
            case Dir.Left: return 90;
            case Dir.Up: return 180;
            case Dir.Right: return 270;
        }
    }

    public Vector2Int GetRotationOffset(Dir dir)
    {
        switch (dir)
        {
            default:
            case Dir.Down: return new Vector2Int(0, 0);
            case Dir.Left: return new Vector2Int(0, width);
            case Dir.Up: return new Vector2Int(width, height);
            case Dir.Right: return new Vector2Int(height, 0);
        }
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

    [Header("Info to Combat")]
    public float delayAttack;
    public float maxHp;
    public float dame;
}

public enum Dir
{
    Down,
    Up,
    Left,
    Right
}
