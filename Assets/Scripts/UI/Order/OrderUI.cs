using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderUI : MonoBehaviour
{
    [SerializeField] private Transform spawnItemOrderPosition;
    [SerializeField] private ItemOrder itemOrder;

    private List<ItemOrder> currentListOrder;

    public void UpdateListOrder(int currentCoin)
    {
        if (currentListOrder == null || currentListOrder.Count <= 0) return;
        foreach (var itemOrder in currentListOrder)
        {
            itemOrder.CheckEnoughCoinToByObject(currentCoin);
        }
    }

    public void Init(List<PlacedObjectTypeSO> placedObjectTypeSOList)
    {
        currentListOrder = new List<ItemOrder>();
        foreach (var placedSO in placedObjectTypeSOList)
        {
            var item = Instantiate(itemOrder, spawnItemOrderPosition);
            item.Init(placedSO, GridBuildingSystem.Ins.SetplaceObjectTypeSO);
            item.gameObject.SetActive(true);

            currentListOrder.Add(item);
        }
    }
}
