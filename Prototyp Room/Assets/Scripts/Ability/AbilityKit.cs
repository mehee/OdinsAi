﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityKit : MonoBehaviour 
{	
	[SerializeField]
	List<Ability> abilities;
	List<Ability> abilityInstances;
	
	[SerializeField]
	float globalCooldown = 0.1f;
	float cooldownTimer;

	private Character owner;

	void Start()
	{	
		owner = GetComponent<Character>();
		abilityInstances = new List<Ability>(abilities.Count);
		foreach(Ability ability in abilities)
		{
			var instance = ability.CreateInstance(owner);
			abilityInstances.Add(instance);
		}

		if(abilities.Count != abilityInstances.Count)
		{
			Debug.LogError("Not all abilities initialized for: " + owner.name);
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
