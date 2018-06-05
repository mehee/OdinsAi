using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeThrow : Ability 
{
	[SerializeField]
	float projectileSpeed;

	[SerializeField]
	// Determines, how far the axe can fly.
	float maxDistance;

	[SerializeField]
	ThrowingAxe axe;
	ThrowingAxe[] axes;

	[SerializeField]
	int maximumAmountAxes = 2;
	public int currentAmountAxes;
	

	void Start()
	{
		axes = new ThrowingAxe[maximumAmountAxes];
		for(int i = 0; i < maximumAmountAxes; i++)
		{
			axes[i] = Instantiate(axe);
			axes[i].transform.parent = transform;
			axes[i].enabled = false;
		}
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
}