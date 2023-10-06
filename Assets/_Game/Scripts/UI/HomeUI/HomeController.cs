using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeController : MonoBehaviour {
    [SerializeField] private LoginUI loginUI;
    [SerializeField] private HomeUI homeUI;
    [SerializeField] private BagUI bagUI;
    [SerializeField] private ShopUI shopUI;

    private void Start() {
        HideAllUI();
        var progress = UserDataController.Instance.GetData<Progress>(UserDataKeys.USER_PROGRESSION, out _);
        if(!progress.isLogin)
            loginUI.Show();
        homeUI.Show();
    }

    private void HideAllUI() {
        loginUI.Hide();
        homeUI.Hide();
        bagUI.Hide();
        shopUI.Hide();
    }
}
