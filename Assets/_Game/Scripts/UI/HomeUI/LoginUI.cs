using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LoginUI : BaseUIElement {
	[SerializeField] private TMP_InputField txtAccount;
	[SerializeField] private TMP_InputField txtPass;
	[SerializeField] private Button btnLogin;
	
	public override void OnAwake() {
		btnLogin.onClick.AddListener(CliclLogin);
	}
	
	private void CliclLogin() {
		var progress = UserDataController.Instance.GetData<Progress>(UserDataKeys.USER_PROGRESSION, out _);
		progress.isLogin = true;
		UserDataController.Instance.SetData(UserDataKeys.USER_PROGRESSION, progress);
		Hide();
	}

	
}
