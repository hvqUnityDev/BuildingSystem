using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {
    [SerializeField] private GameObject loaderCanvas;
    [SerializeField] private Image progressBar;

    private const string BUILDINGSCENE = "BuildingScene";
    private const string HOMEUI = "HomeUI";
    public void ClickPlayGame() {
        LoadSceneWithName(BUILDINGSCENE);
    }

    public void ClickBackHome() {
        LoadSceneWithName(HOMEUI);
    }

    public async void LoadSceneWithName(string name) {
        var scene = SceneManager.LoadSceneAsync(name);
        scene.allowSceneActivation = false;

        loaderCanvas.SetActive(true);
        do {
            await Task.Delay(100);
            progressBar.fillAmount = scene.progress;

        } while (scene.progress < 0.9f);
        
        scene.allowSceneActivation = true;
    }
}

