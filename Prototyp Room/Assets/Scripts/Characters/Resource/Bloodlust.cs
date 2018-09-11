using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Bloodlust is the warriors resource that reduces
	itself constantly instead of regenerating. */
public class Bloodlust : AbilityResource
{
	[SerializeField]

	void Start()
	{
		Value = 0;
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
		}
	}
}
