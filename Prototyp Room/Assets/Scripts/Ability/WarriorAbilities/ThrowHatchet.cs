﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySystem;
public class ThrowHatchet : PlayerAbility
{
	[SerializeField]
	Damage damage;

	ObjectPool pool;

	protected override void SetUp()
	{
		pool = GetComponent<ObjectPool>();

		if(!(pool.Instances is List<Hatchet>))
			Debug.LogError("Wrong type of PoolObject. This needs 'Hatchet'.");

		foreach(PoolObject poolObject in pool.Instances)
		{
			var hatchet = poolObject as Hatchet;
			hatchet.stats = owner.stats;
			hatchet.damage = damage;
		}
	}

	protected override void OnActivation()
	{
		var hatchet = pool.Dispatch() as Hatchet;
		hatchet.Direction = direction;
	}	
}
