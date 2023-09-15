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
    [SerializeField] private Image imgItemOrder;
    [SerializeField] private Color colorAvailable;
    [SerializeField] private Color colorUnavailable;

    private PlacedObjectTypeSO placedObjectTypeSo;
    public void Init(PlacedObjectTypeSO placedObjectTypeSo, Action<PlacedObjectTypeSO> OnChangePlacedObject)
    {
        this.placedObjectTypeSo = placedObjectTypeSo;
        txtName.text = this.placedObjectTypeSo.nameString;
        btnItemOrder.onClick.AddListener(() =>
        {
            if(GameController.Ins.GetCurrentCoin() >= placedObjectTypeSo.price)
            {
                OnChangePlacedObject?.Invoke(this.placedObjectTypeSo);
            }
        });
    }

    public void CheckEnoughCoinToByObject(int currentCoin)
    {
        if (currentCoin >= placedObjectTypeSo.price)
        {
            imgItemOrder.color = colorAvailable;
        }
        else
        {
            imgItemOrder.color = colorUnavailable;
        }
    }
}
