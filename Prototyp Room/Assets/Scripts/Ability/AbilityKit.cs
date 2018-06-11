using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityKit : MonoBehaviour 
{	
	[SerializeField]
	Ability[] abilities;
	List<Ability> abilityInstances;
	
	[SerializeField]
	float globalCooldown = 0.1f;
	float cooldownTimer;

	void Start()
	{
		abilityInstances = new List<Ability>(abilities.Length);
		foreach(Ability ability in abilities)
		{
			var instance = Instantiate(ability, transform) as Ability;
			abilityInstances.Add(instance);
		}
	}

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
		for(int i = 0; i < abilityInstances.Count; i++)
		{
			if(Input.GetButtonDown("Ability" + (i + 1)))
			{
				return abilityInstances[i];
			}
		}
		return null;
	}

	void Activate(Ability ability)
	{
		if(!ability.ReadyForActivation())
			return;
		ability.Activate();
		cooldownTimer = globalCooldown;
	}
}
