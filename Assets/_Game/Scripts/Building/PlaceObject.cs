using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaceObject : MonoBehaviour
{
    public static PlaceObject Create(Vector3 worldPosition, Vector2Int origin, Dir dir, PlacedObjectTypeSO placedObjectTypeSo)
    {
        Transform placeObjectTransform = Instantiate(placedObjectTypeSo.prefabs, worldPosition,
            Quaternion.Euler(0, placedObjectTypeSo.GetRotationAngle(dir), 0));

        PlaceObject placeObject = placeObjectTransform.GetComponent<PlaceObject>();

        placeObject._placedObjectTypeSo = placedObjectTypeSo;
        placeObject.origin = origin;
        placeObject.dir = dir;

        return placeObject;
    }
    
    private PlacedObjectTypeSO _placedObjectTypeSo;
    private Vector2Int origin;
    private Dir dir;

    public List<Vector2Int> GetGridPositionList()
    {
        return _placedObjectTypeSo.GetGridPositionList(origin, dir);
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }
}
