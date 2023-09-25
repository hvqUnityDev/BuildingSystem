using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GunNormal : TowerBase {
    
	[SerializeField] private Transform spawnBullet;
	[SerializeField] private Bullet bullet;
    
    protected override void HandleAttack() {
	    Instantiate(bullet, spawnBullet.position, quaternion.identity);
    }
}
