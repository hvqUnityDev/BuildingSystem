
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] private Vector3 dir;
    [SerializeField] private float speed = 10f;
    private bool isShow = false;
    void Update() {
        if(isShow)
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private Transform target;
    public float dame { get; private set; }

    public void SetTarget(Transform target) {
        isShow = true;
        this.target = target;
        transform.LookAt(target);
    }
    public void SetDame(float dame) {
        this.dame = dame;
    }

    public void DestroySelf() {
        isShow = false;
        gameObject.SetActive(false);
    }
}
