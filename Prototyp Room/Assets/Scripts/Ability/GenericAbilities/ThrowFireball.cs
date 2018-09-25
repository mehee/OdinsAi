using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySystem;

public class ThrowFireball : Ability
{
	ObjectPool fireballs;

	public override void SetUp()
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

	public override void OnActivation()
	{
		var fireball = fireballs.Dispatch() as Fireball;
		if(fireball == null)
			return;
		fireball.transform.position = transform.position;
		fireball.direction = direction;
	}
}
