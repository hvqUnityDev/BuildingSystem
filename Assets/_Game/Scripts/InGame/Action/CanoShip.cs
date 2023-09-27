using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanoShip : ActorBase {
    [SerializeField] private Vector3 dirMove = Vector3.left;
    protected override void HandleMove() {
        transform.Translate(dirMove * Time.deltaTime * speed);
    }
}
