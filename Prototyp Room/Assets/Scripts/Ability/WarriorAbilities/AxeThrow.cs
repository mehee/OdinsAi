using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeThrow : Ability 
{
	[SerializeField]
	ThrowingAxe axe;
	ThrowingAxe[] axes;

	[SerializeField]
	int maximumAmountAxes = 2;
	int currentAmountAxes;


	void Start()
	{
		axes = new ThrowingAxe[maximumAmountAxes];
		for(int i = 0; i < maximumAmountAxes; i++)
		{
			axes[i] = Instantiate(axe);
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
