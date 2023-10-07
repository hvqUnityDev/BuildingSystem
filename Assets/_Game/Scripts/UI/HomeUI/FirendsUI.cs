using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirendsUI : MonoBehaviour {
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject bg;

    public void ClickSelection() {
        _animator.SetTrigger("triggerShow");
    }
}
