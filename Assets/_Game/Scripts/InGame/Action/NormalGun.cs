using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NormalGun : ActorBase {
    
	[SerializeField] private Transform spawnBullet;
	[SerializeField] private Bullet bullet;

	protected override void SeeSomeThing() {
		base.SeeSomeThing();
		Instantiate(bullet, spawnBullet.position, quaternion.identity);
	}
}
