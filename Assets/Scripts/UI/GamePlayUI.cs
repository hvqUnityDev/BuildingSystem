using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayUI : MonoBehaviour
{
    public static GamePlayUI Ins;
    
    [SerializeField] private TMP_Text txtCoin;
    [SerializeField] private OrderUI orderUI;

    private void Awake()
    {
        Ins = this;
    }

    public void SetCoin(int currentCoin)
    {
        txtCoin.text = currentCoin.ToString();
        orderUI.UpdateListOrder(currentCoin);
    }


    public void InitOrder(List<PlacedObjectTypeSO> placedObjectTypeSOList)
    {
        orderUI.Init(placedObjectTypeSOList);
    }
}
