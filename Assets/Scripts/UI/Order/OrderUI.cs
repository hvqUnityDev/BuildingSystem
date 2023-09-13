using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderUI : MonoBehaviour
{
    [SerializeField] private Transform spawnItemOrderPosition;
    [SerializeField] private ItemOrder itemOrder;

    public void Init(List<PlacedObjectTypeSO> placedObjectTypeSOList)
    {
        foreach (var placedSO in placedObjectTypeSOList)
        {
            var item = Instantiate(itemOrder, spawnItemOrderPosition);
            item.Init(placedSO, GridBuildingSystem.Ins.SetplaceObjectTypeSO);
            
            item.gameObject.SetActive(true);
        }
    }
}
