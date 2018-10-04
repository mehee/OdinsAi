﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySystem;

public class ThrowRuneOrb : PlayerAbility
{
	ObjectPool fireballs;

	protected override void SetUp()
	{
		Fireball fireball;
		fireballs = GetComponent<ObjectPool>();
		foreach(PoolObject po in fireballs.Instances)
		{
			fireball = po as Fireball;
			fireball.stats = owner.stats;
			Debug.Log("No owner: " + owner == null);
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
