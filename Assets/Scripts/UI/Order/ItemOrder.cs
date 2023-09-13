using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemOrder : MonoBehaviour
{
    [SerializeField] private TMP_Text txtName;
    [SerializeField] private Button btnItemOrder;

    private PlacedObjectTypeSO placedObjectTypeSo;
    public void Init(PlacedObjectTypeSO placedObjectTypeSo, Action<PlacedObjectTypeSO> OnChangePlacedObject)
    {
        this.placedObjectTypeSo = placedObjectTypeSo;
        txtName.text = this.placedObjectTypeSo.nameString;
        btnItemOrder.onClick.AddListener(() =>
        {
            OnChangePlacedObject?.Invoke(this.placedObjectTypeSo);
        });
    }
}
