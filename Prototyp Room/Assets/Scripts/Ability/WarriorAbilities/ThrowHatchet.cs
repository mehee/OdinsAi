using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowHatchet : Ability
{
	[SerializeField]
	Hatchet hatchetPrefab;

	[SerializeField]
	int amountHatchets = 2;
	[HideInInspector]
	public int currentAmountHatchets;

	[SerializeField]
	float speed;

	protected override void Start()
	{
		base.Start();
		currentAmountHatchets = amountHatchets;	
	}

    public override void Activate()
    {
		RemainingCooldown = Cooldown;
		Hatchet thrown = Instantiate(hatchetPrefab, transform.position, rotation);
		thrown.owner = this;
		AlignWithMouse();
		thrown.Velocity = speed * direction;
		Debug.Log(thrown.Velocity);
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
