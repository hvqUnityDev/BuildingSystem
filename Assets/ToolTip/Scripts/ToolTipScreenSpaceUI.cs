using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ToolTipScreenSpaceUI : MonoBehaviour {
    [SerializeField] private RectTransform canvasRectTransform;
    
    private RectTransform bgRectTransform, rectTransform;
    private TextMeshProUGUI textMeshPro;

    private void Awake() {
        bgRectTransform = transform.Find("background").GetComponent<RectTransform>();
        textMeshPro = transform.Find("txt").GetComponent<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();
        SetText("Hello World!");
        TestTooltip();
    }

    private void SetText(string tooltipText) {
        textMeshPro.SetText(tooltipText);
        textMeshPro.ForceMeshUpdate();

        Vector2 paddingSize = new Vector2(8, 8);
        Vector2 textSize = textMeshPro.GetRenderedValues(false);
        bgRectTransform.sizeDelta = textSize + paddingSize;
    }

    private void TestTooltip() {
        SetText("Testing tooltip...");

        FunctionPeriodic.Create(() => {
            string abc = "qwertyuipoASDFGHJKL";
            string text = "Sub...";
            for (int i = 0; i < Random.Range(5, 100); i++) {
                text += abc[Random.Range(0, abc.Length)];
            }

            SetText(text);
        }, .5f);
    }

    private void Update() {

        Vector3 anchoredPosition = Input.mousePosition / canvasRectTransform.localScale.x;
        if (anchoredPosition.x + bgRectTransform.rect.width > canvasRectTransform.rect.width) {
            anchoredPosition.x = canvasRectTransform.rect.width - bgRectTransform.rect.width;
        }
        
        if (anchoredPosition.y + bgRectTransform.rect.height > canvasRectTransform.rect.height) {
            anchoredPosition.y = canvasRectTransform.rect.height - bgRectTransform.rect.height;
        }
        
        rectTransform.anchoredPosition = anchoredPosition;
    }
}
