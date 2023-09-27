using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GunNormal : ActorBase {
    
	[SerializeField] private Transform spawnBullet;
	[SerializeField] private Bullet bullet;
    
    protected override void HandleAttack()
    {
	    Ray ray = new Ray(spawnBullet.position, Vector3.forward);
	    if (Physics.Raycast(ray,out RaycastHit hit))
	    {
		    Debug.Log(hit.collider.name);
		    Instantiate(bullet, spawnBullet.position, quaternion.identity);
	    }
    }
}
