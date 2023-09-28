using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ActorBase : MonoBehaviour {
    protected float nextTimeNormalAttack, delayAttack, hp, dame, speed;
    [SerializeField] protected float attackRange;
    [SerializeField] protected Transform pointRay;
    private bool isInit = false;
    private Ray ray;
    private LayerMask layerEnemies;
    private RaycastHit hit;

    public virtual void Init(PlacedObjectTypeSO placedObjectTypeSo) {
        isInit = true;
        delayAttack = placedObjectTypeSo.delayAttack;
        hp = placedObjectTypeSo.maxHp;
        dame = placedObjectTypeSo.dame;
        attackRange = placedObjectTypeSo.attackRange;
        speed = placedObjectTypeSo.speed;
        layerEnemies = placedObjectTypeSo.layerEnemies;
        
        nextTimeNormalAttack = Time.time + placedObjectTypeSo.delayAttack;
        ray = new Ray(pointRay.position, Vector3.right);

    }
    
    private void Update() {
        if (!isInit) return;

        if (nextTimeNormalAttack < Time.time) {
            HandleAttack();
            nextTimeNormalAttack += delayAttack;
        }

        HandleMove();
    }
    
    protected virtual void HandleMove() {
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
    
    protected virtual void HandleAttack()
    {
        if (Physics.Raycast(ray,out hit, attackRange, layerEnemies)) {
            SeeSomeThing();
        }
        else {
            DontSeeSomeThing();
        }
    }
    
    protected virtual void SeeSomeThing(){
        Debug.DrawRay(pointRay.position, Vector3.right * hit.distance, Color.yellow);
    }
    
    protected virtual void DontSeeSomeThing(){
        Debug.DrawRay(pointRay.position, Vector3.right * attackRange, Color.white);
    }
}
