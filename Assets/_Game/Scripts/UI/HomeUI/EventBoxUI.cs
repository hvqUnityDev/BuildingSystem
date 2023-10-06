using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EventBoxUI : MonoBehaviour {
    [SerializeField] private List<Sprite> listSpr;

    [SerializeField] private Image imgContent;
    [SerializeField] private Image imgFade;
    private void Start() {
        ChangeContent();
    }

    private void ChangeContent() {
        Sprite spr = listSpr[Random.Range(0, listSpr.Count)];
        imgFade.DOFade(1, 1f).OnComplete(() => {
            imgContent.sprite = spr;
            imgFade.DOFade(0, 0.5f);
        });
        
        Invoke(nameof(ChangeContent), 7f);
    }
}
