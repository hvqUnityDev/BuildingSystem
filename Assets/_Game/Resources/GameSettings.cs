using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[Serializable]
[CreateAssetMenu(fileName = "GameSettings", menuName = "GAME/GameSettings")]
public class GameSettings : ScriptableObject {
#if UNITY_EDITOR
	[UnityEditor.MenuItem("GAME/GameSettings")]
	private static void OpenGameSettings() {
		UnityEditor.Selection.activeObject = GameSettings.Ins;
	}

	[UnityEditor.MenuItem("GAME/ClearAllData", priority = 1000)]
	private static void ClearAllData() {
		PlayerPrefs.DeleteAll();
	}
#endif
	private static GameSettings _ins;

	public static GameSettings Ins {
		get {
			if (_ins != null) return _ins;
			_ins = Resources.Load<GameSettings>("GameSettings");
			if (_ins == null) Debug.LogError("Cannot found GameSettings in Resources folder");
			return _ins;
		}
	}

	[SerializeField] private LayerMask layerBullet;

	public LayerMask LayerBullet => layerBullet;
}