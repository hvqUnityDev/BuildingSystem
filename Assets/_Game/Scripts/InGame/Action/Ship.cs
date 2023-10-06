using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : ActorBase
{
    [SerializeField] private bool isCanMove = true;
    private Vector3 dirMove = Vector3.left;
    protected override void SeeSomeThing() {
        base.SeeSomeThing();
        Debug.Log(gameObject.name +"seee");
    }

    private void Start() {
        ConvertRangeAttack();
    }

    private void ConvertRangeAttack() {
        if (dirMove == Vector3.left) {
            attackRange = -Mathf.Abs(attackRange);
        }
        else if (dirMove == Vector3.left) {
            attackRange = Mathf.Abs(attackRange);
        }
    }
    
    protected override void HandleMove() {
        if(isCanMove)
            transform.Translate(dirMove * Time.deltaTime * speed);
    }
    
    
}
