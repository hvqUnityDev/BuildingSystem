using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField] private TMP_Text txtCoin;
    [SerializeField] private OrderUI orderUI;

    [SerializeField] private List<PlacedObjectTypeSO> placedObjectTypeSOList;
    private int coin;

    private void Start()
    {
        orderUI.Init(placedObjectTypeSOList);
    }

    public void SetCoin(int value)
    {
        coin = value;
        txtCoin.text = coin.ToString();
    }
    
    
    
}
