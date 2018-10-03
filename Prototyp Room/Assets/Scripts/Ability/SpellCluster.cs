using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySystem;

public class SpellCluster : Ability
{
	ObjectPool pool;
	float spawnRadius = 5f;

	public override void SetUp()
	{
		pool = GetComponent<ObjectPool>();
		
		foreach(SpellBomb spellBomb in pool.Instances)
		{
			spellBomb.stats = owner.stats;
		}
	}

	// Deploy all the spell bombs randomly in a radius around
	// the caster.
	// SpellBombs will return themselves to the object pool!
	public override void OnActivation()
	{
		float xMin = transform.position.x - spawnRadius;
		float xMax = transform.position.x + spawnRadius;
		float yMin = transform.position.y - spawnRadius;
		float yMax = transform.position.y + spawnRadius;
		Vector2 randomPosition;

		for(int i = 0; i < pool.Instances.Count; i++)
		{
			var bomb = pool.Dispatch();
			randomPosition.x = Random.Range(xMin, xMax);
			randomPosition.y = Random.Range(yMin, yMax);
			if(!bomb)
				Debug.LogError("No bomb retrieved");
			bomb.transform.position = randomPosition;
		}
	}
}
