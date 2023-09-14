using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildingGhost : MonoBehaviour
{
    private Transform visual;
    private PlacedObjectTypeSO _placedObjectTypeSO;

    private void Start()
    {
        RefreshVisual();
        GridBuildingSystem.Ins.OnSelectedChanged += Instance_OnSelectChange;
    }

    private void Instance_OnSelectChange(object sender, EventArgs e)
    {
        RefreshVisual();
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = GridBuildingSystem.Ins.GetMouseWorldSnappedPosition();
        targetPosition.y = 1;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 15f);

        transform.rotation = Quaternion.Lerp(transform.rotation, GridBuildingSystem.Ins.GetPlacedObjectRotation(),
            Time.deltaTime * 15f);
    }

    private void RefreshVisual()
    {
        if (visual != null)
        {
            Destroy(visual.gameObject);
            visual = null;
        }

        PlacedObjectTypeSO placeObjectSO = GridBuildingSystem.Ins.GetCurrentPlacedObjectTypeSO();
        if (placeObjectSO != null)
        {
            visual = Instantiate(placeObjectSO.visual, Vector3.zero, Quaternion.identity);
            visual.parent = transform;
            visual.localPosition = Vector3.zero;
            visual.localEulerAngles = Vector3.zero;
            SetLayerRecursive(visual.gameObject, 11);
        }
    }

    private void SetLayerRecursive(GameObject targetGameObject, int layer) {
        targetGameObject.layer = layer;
        foreach (Transform child in targetGameObject.transform) {
            SetLayerRecursive(child.gameObject, layer);
        }
    }
}
