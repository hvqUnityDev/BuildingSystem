using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NormalGun : ActorBase {
    
	[SerializeField] private Transform spawnBullet, pointRay;
	[SerializeField] private LayerMask layerEnemies;
	[SerializeField] private Bullet bullet;
    
    protected override void HandleAttack()
    {
	    Ray ray = new Ray(pointRay.position, Vector3.forward);

	    if (Physics.Raycast(ray,out RaycastHit hit, attackRange, layerEnemies))
	    {
		    Debug.Log(hit.collider.name);
		    Instantiate(bullet, spawnBullet.position, quaternion.identity);
	    }
    }

    private void OnDrawGizmos() {
	    Debug.DrawRay(pointRay.position, Vector3.right * attackRange);
    }
}
