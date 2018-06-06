using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeThrow : Ability 
{
	[SerializeField]
	float projectileSpeed;
	[SerializeField]
	float flightDistance;

	[SerializeField]
	ThrowingAxe axe;
	ThrowingAxe[] axes;

	[SerializeField]
	int maximumAmountAxes = 2;
	public int currentAmountAxes;

	[SerializeField]
	float pickupDistance;

	// If the player distances himself
	// too far from an axe, the axe gets
	//returned to him.
	[SerializeField]
	float resetDistance;
	

	void Start()
	{
		axes = new ThrowingAxe[maximumAmountAxes];
		axe.FlightDistance = flightDistance;
		for(int i = 0; i < maximumAmountAxes; i++)
		{
			axes[i] = Instantiate(axe);
			axes[i].transform.parent = transform;
			axes[i].enabled = false;
		}
	}

	protected override void Update()
	{
		base.Update();
	}

	public override bool Activate()
	{
		if(currentAmountAxes == 0)
			return false;

		if(!base.Activate())
			return false;

		currentAmountAxes -= 1;

		return true;
	}

	/** Returns axes at certain distances
		back to the player. */
	void GatherAxes()
	{
		float distance;
		foreach(ThrowingAxe axe in axes)
		{
			distance = (axe.transform.position 
				- transform.position).magnitude;
			if((distance <= pickupDistance || distance > resetDistance)
				&& axe.Velocity == Vector2.zero)
			{
				currentAmountAxes++;
				axe.enabled = false;
				axe.transform.position = transform.position;
			}
		}
	}

	void Throw()
	{
		ThrowingAxe thrown = axes[currentAmountAxes - 1];
		thrown.Velocity = direction * projectileSpeed;
		thrown.Damage = Damage;
		thrown.enabled = true;
	}
}