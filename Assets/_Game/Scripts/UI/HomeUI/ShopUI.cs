using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : BaseUIElement
{
	public override void OnAwake() {
		
	}

	[SerializeField] private SlotBag slot;
	[SerializeField] private ScrollRect scrollItem;
	[SerializeField] private ScrollRect scrollCoin;

	private void Start() {
		scrollItem.gameObject.SetActive(true);
		scrollCoin.gameObject.SetActive(false);
	}

	public void ShowItemShop() {
		scrollItem.gameObject.SetActive(true);
		scrollCoin.gameObject.SetActive(false);
	}

	public void ShowCoinShop() {
		scrollItem.gameObject.SetActive(false);
		scrollCoin.gameObject.SetActive(true);
	}
}
