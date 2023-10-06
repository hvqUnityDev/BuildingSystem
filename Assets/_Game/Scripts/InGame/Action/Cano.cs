using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cano : ActorBase {
	[SerializeField] private Vector3 dirMove = Vector3.left;
	[SerializeField] private bool isCanMove = true;

	public override void Init(PlacedObjectTypeSO placedObjectTypeSo) {
		base.Init(placedObjectTypeSo);
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

	protected override void SeeSomeThing() {
		base.SeeSomeThing();
		isCanMove = false;
		if (hit.transform.gameObject.TryGetComponent(out ActorBase actor)) {
			actor.Attacked(dame);
		}
	}

	protected override void DontSeeAnyThing() {
		base.DontSeeAnyThing();
	}

	protected override void Dead() {
		base.Dead();
		isCanMove = false;
		gameObject.SetActive(false);
	}

	private void OnTriggerEnter(Collider other) {
		if (other.TryGetComponent(out Bullet bullet)) {
			Attacked(bullet.dame);
			bullet.DestroySelf();
		}
	}
}