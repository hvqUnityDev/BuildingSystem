using UnityEngine;

public class ActorBase : MonoBehaviour {
    protected float nextTimeNormalAttack, delayAttack, hp, dame, speed;
    [SerializeField] protected float attackRange;
    [SerializeField] protected Transform pointRay;
    [SerializeField] private bool isInit = false;
    protected Ray ray;
    [SerializeField] private LayerMask layerEnemies;
    protected RaycastHit hit;
    [SerializeField] protected bool isCanAttack; 
    public virtual void Init(PlacedObjectTypeSO placedObjectTypeSo) {
        isInit = true;
        delayAttack = placedObjectTypeSo.delayAttack;
        hp = placedObjectTypeSo.maxHp;
        dame = placedObjectTypeSo.dame;
        attackRange = placedObjectTypeSo.attackRange;
        speed = placedObjectTypeSo.speed;
        layerEnemies = placedObjectTypeSo.layerEnemies;
        
        nextTimeNormalAttack = Time.time + placedObjectTypeSo.delayAttack;
        if(pointRay)
            ray = new Ray(pointRay.position, Vector3.right);
        else {
            Debug.Log($"{gameObject.name} not have pointRay");
        }
        isCanAttack = true;
    }
    
    protected void Update() {
        if (!isInit) return;

        HandleAttack();
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
    
    protected virtual void HandleAttack() {
        if (Physics.Raycast(ray, out hit, attackRange, layerEnemies) && pointRay) {
            Debug.Log(hit.rigidbody.gameObject.name);
            if (nextTimeNormalAttack < Time.time && isCanAttack) {
                SeeSomeThing();
                nextTimeNormalAttack = Time.time + delayAttack;
            }
        }
        else {
            DontSeeAnyThing();
        }
    }
    
    protected virtual void SeeSomeThing(){
        if(pointRay)
            Debug.DrawRay(pointRay.position, Vector3.right * hit.distance, Color.yellow);
    }
    
    protected virtual void DontSeeAnyThing(){
        if(pointRay)
            Debug.DrawRay(pointRay.position, Vector3.right * attackRange, Color.blue);
    }

    public void SetRotation(Vector3 rotation) {
        transform.rotation = Quaternion.Euler(rotation);
    }
}
