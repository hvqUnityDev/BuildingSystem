
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] private Vector3 dir;
    [SerializeField] private float speed = 10f;
    void Update() {
        transform.Translate(dir * Time.deltaTime * speed);
    }
}
