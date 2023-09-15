using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Ins;
    private GamePlayUI gamePlayUI;
    private GridBuildingSystem buildingSystem;

    private int currentCoin, addCoin = 2;
    private float delayTime = 5f, nextTimeReceiveCoin;

    private void Awake()
    {
        Ins = this;
    }

    private void Start()
    {
        gamePlayUI = GamePlayUI.Ins;
        buildingSystem = GridBuildingSystem.Ins;
        nextTimeReceiveCoin = delayTime;
        currentCoin = 0;
        
        buildingSystem.OnDoneClickBuild += BuildingSystem_OnDoneClickBuild;
        gamePlayUI.InitOrder(buildingSystem.GetListPlacedObjectTypeSO());
        gamePlayUI.SetCoin(currentCoin);
    }
    
    private void BuildingSystem_OnDoneClickBuild()
    {
        var placedObjectSO = buildingSystem.GetCurrentPlacedObjectTypeSO();
        if(placedObjectSO)
        {
            currentCoin -= placedObjectSO.price;
            gamePlayUI.SetCoin(currentCoin);
        }
    }

    private void Update()
    {
        if (nextTimeReceiveCoin < Time.time)
        {
            currentCoin += addCoin;
            nextTimeReceiveCoin += delayTime;
            gamePlayUI.SetCoin(currentCoin);
        }
    }

    public int GetCurrentCoin()
    {
        return currentCoin;
    }
}
