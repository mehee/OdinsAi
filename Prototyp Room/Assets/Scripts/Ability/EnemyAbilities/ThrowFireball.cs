﻿using UnityEngine;
using AbilitySystem;

public class ThrowFireball : EnemyAbility
{
	ObjectPool fireballs;

	[SerializeField]
	public Damage damage;

	protected override void SetUp()
	{
		Fireball fireball;
		fireballs = GetComponent<ObjectPool>();
		foreach(PoolObject po in fireballs.Instances)
		{
			fireball = po as Fireball;
			fireball.stats = owner.stats;
			fireball.damage = damage;
		}
	} 

	protected override void OnActivation()
	{
		var fireball = fireballs.Dispatch() as Fireball;
		if(fireball == null)
		{
			Debug.LogError("No balls left");
			return;
		}
		fireball.transform.position = transform.position;
		fireball.direction = direction;
	}
}
