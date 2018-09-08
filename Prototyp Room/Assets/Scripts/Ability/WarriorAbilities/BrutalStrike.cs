using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrutalStrike : Ability 
{
	new Collider2D collider;
	float lastDamageBonus;

	[SerializeField]
	float bonusPerBloodlustInterval;
	[SerializeField]
	float bloodlustInterval;

	int framesActive;

    public override void Activate()
    {
		RemainingCooldown = Cooldown;
		framesActive = 0;
		AlignWithMouse();
		transform.rotation = rotation;
		SetBonusDamage();
		collider.enabled = true;
    }

	protected void Start()
	{
		collider = GetComponent<Collider2D>();
	}

	protected override void Update()
	{
		base.Update();
		if(framesActive <= activeFrames)
		{
			framesActive++;
			if(framesActive > activeFrames)
			{
				collider.enabled = false;
			}
		}
	}

    void SetBonusDamage()
	{
		float bloodlust = owner.GetComponent<Bloodlust>().Value;
		float bonus = Mathf.Floor(bloodlust / bloodlustInterval) 
			* bonusPerBloodlustInterval;
		float bonusDelta = bonus - lastDamageBonus;
		damageModifier += bonusDelta;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Enemy")
		{
			
			
			other.GetComponent<Health>().Reduce(Damage);
		}
	}
}
