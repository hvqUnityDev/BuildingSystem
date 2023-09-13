using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayUI : MonoBehaviour
{
    [SerializeField] private TMP_Text txtCoin;
    private int coin;

    public void SetCoin(int value)
    {
        coin = value;
        txtCoin.text = coin.ToString();
    }
    
    
    
}
