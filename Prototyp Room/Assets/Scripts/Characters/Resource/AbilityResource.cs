using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityResource : Resource
{
	[SerializeField]
	protected float changeInterval;
	[SerializeField]
	protected float changeAmount;
	protected float intervalTimer;

	protected virtual void Awake()
	{
		Value = Maximum;
	}

	protected virtual void Update()
	{
		if(intervalTimer > 0)
		{
			intervalTimer -= Time.deltaTime;
			if(intervalTimer < 0)
				intervalTimer = 0;
		}

		if(intervalTimer == 0)
		{
			Replenish(changeAmount);
			intervalTimer = changeInterval;
		}
	}
}
