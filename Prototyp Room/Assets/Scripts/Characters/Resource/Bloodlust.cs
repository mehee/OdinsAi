﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Bloodlust is the warriors resource that reduces
	itself constantly instead of regenerating. */
public class Bloodlust : AbilityResource
{
	BloodlustRadius radius;
	[SerializeField]
	float bloodlustPerEnemy;

	void Start()
	{
		Value = 0;
		radius = GetComponentInChildren<BloodlustRadius>();
	}

	protected override void Update()
	{
		if(intervalTimer > 0)
		{
			intervalTimer -= Time.deltaTime;
			if(intervalTimer < 0)
				intervalTimer = 0;
		}

		if(intervalTimer == 0)
		{
			Reduce(changeAmount);
			Replenish(radius.GetAmountOfBleedingEnemies() * bloodlustPerEnemy);
			intervalTimer = changeInterval;
		}
	}
}
