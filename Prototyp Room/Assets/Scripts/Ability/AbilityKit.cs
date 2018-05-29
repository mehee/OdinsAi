using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityKit : MonoBehaviour 
{	
	Ability[] abilities;
	
	[SerializeField]
	float globalCooldown = 0.1f;
	float cooldownTimer;

	void Update () 
	{
		if(cooldownTimer != 0)
		{
			cooldownTimer -= Time.deltaTime;
			if(cooldownTimer < 0)
				cooldownTimer = 0;
			return;
		}

		Ability activated = GetActivatedAbility();
		if(activated)
			Activate(activated);
	}

	/** Make sure that for every ability
		there is a corresponding button
		set in 'Preferences->Input'!
		
		Returns null if there was no input. */
	Ability GetActivatedAbility()
	{
		for(int i = 0; i < abilities.Length; i++)
		{
			if(Input.GetButtonDown("Ability" + (i + 1)))
			{
				return abilities[i];
			}
		}
		return null;
	}

	void Activate(Ability ability)
	{
		bool ready = ability.Activate();
		if(!ready)
			return;
		cooldownTimer = globalCooldown;
	}
}
