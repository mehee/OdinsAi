using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySystem;

public class SpellCluster : EnemyAbility
{
	[SerializeField]
	float spawnRadius = 10f;

	[SerializeField]
	Damage damage;

	ObjectPool pool;

	protected override void SetUp()
	{
		pool = GetComponent<ObjectPool>();
		
		foreach(SpellBomb spellBomb in pool.Instances)
		{
			spellBomb.stats = owner.stats;
			spellBomb.damage = damage;
		}
	}

	// Deploy all the spell bombs randomly in a radius around
	// the caster.
	// SpellBombs will return themselves to the object pool!
	protected override void OnActivation()
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
