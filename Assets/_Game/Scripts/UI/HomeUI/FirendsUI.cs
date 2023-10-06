using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirendsUI : MonoBehaviour {
    private bool isShow = false;
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject bg;

    public void ClickSelection() {
        _animator.SetTrigger("triggerShow");
        isShow = !isShow;
        bg.SetActive(isShow);
    }
}
