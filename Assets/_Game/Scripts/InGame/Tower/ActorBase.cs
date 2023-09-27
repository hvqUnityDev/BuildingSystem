using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorBase : MonoBehaviour {
    protected float nextTimeNormalAttack, delayAttack, hp, dame;
    private bool isInit = false;
    public virtual void Init(PlacedObjectTypeSO placedObjectTypeSo) {
        isInit = true;
        delayAttack = placedObjectTypeSo.delayAttack;
        hp = placedObjectTypeSo.maxHp;
        dame = placedObjectTypeSo.dame;
        
        nextTimeNormalAttack = Time.time + placedObjectTypeSo.delayAttack;
    }
    
    private void Update() {
        if (!isInit) return;

        if (nextTimeNormalAttack < Time.time) {
            HandleAttack();
            nextTimeNormalAttack += delayAttack;
        }
    }

    protected virtual void HandleAttack() {
    }
    
    public virtual void UseBooster() {
    }
    
    public virtual void Attacked(float dame) {
        hp -= dame;
        if (hp <= 0)
        {
            Dead();
        }
    }

    protected virtual void Dead()
    {
        
    }
}
