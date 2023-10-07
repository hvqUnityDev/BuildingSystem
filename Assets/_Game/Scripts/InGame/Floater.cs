using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Floater : MonoBehaviour {
    public Rigidbody rigidbody;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;

    private void Start() {
        nextTimeAdd += Random.Range(5, 10);
    }

    private void FixedUpdate() {
        if (transform.position.y < 0f) {
            float displacementMultiplier =
                Mathf.Clamp01(-transform.position.y / depthBeforeSubmerged) * displacementAmount;
            rigidbody.AddForce(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacementMultiplier, 0f), ForceMode.Acceleration);
            
        }
    }

    private float nextTimeAdd = 0;
    private void Update() {
        if (nextTimeAdd < Time.time) {
            nextTimeAdd += Random.Range(5, 10);
            AddForceSome();
        }
    }

    [ContextMenu("AddForce")]
    public void AddForceSome() {
        rigidbody.AddForce(new Vector3(0, -80, 0));
    }
}
