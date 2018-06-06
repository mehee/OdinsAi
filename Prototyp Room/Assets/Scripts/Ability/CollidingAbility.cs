using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidingAbility : Ability 
{
	new protected Collider2D collider;
	uint frameCounter = 0;

	protected override void Awake()
	{
		base.Awake();
		collider = GetComponent<Collider2D>();
		collider.enabled = false;
	}	

	protected override void Update()
	{
		base.Update();

		if(frameCounter > info.framesActive)
		{
			collider.enabled = false;
			frameCounter = 0;
		}

		if(collider.enabled)
		{
			frameCounter++;
		}
	}

	public override bool Activate()
	{
		if(!base.Activate())
			return false;

		collider.enabled = true;
		return true;
	}
}
