using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowHatchet : Ability
{
	[SerializeField]
	Hatchet hatchetPrefab;
	Hatchet[] hatchets;

	[SerializeField]
	int amountHatchets = 2;
	int currentAmountHatchets;

	[SerializeField]
	float speed;

	protected override void Start()
	{
		base.Start();
		currentAmountHatchets = amountHatchets;	
		hatchets = new Hatchet[amountHatchets];

		for(int i = 0; i < amountHatchets; i++)
		{
			hatchets[i] = Instantiate(hatchetPrefab);
			hatchets[i].transform.parent = transform;
		}
	}

    public override void Activate()
    {
		RemainingCooldown = Cooldown;
		Hatchet thrown = hatchets[currentAmountHatchets-1];
		thrown.GetComponent<Rigidbody2D>().velocity = speed * direction;
		thrown.GetComponent<Collider2D>().enabled = true;
		currentAmountHatchets--;	
    }

	public override bool ReadyForActivation()
	{
		if(OffCoolDown() && (currentAmountHatchets > 0))
			return true;
		return false;
	}
}
