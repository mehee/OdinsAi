using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ability
{
	public class AbilityKit : MonoBehaviour 
	{	
		[SerializeField]
		List<Ability> abilities;
		List<Ability> abilityInstances;
		
		[SerializeField]
		float globalCooldown = 0.1f;
		float cooldownTimer;

		private Character owner;
		private Ability previous;

		void Start()
		{	
			owner = GetComponent<Character>();
			abilityInstances = new List<Ability>(abilities.Count);
			foreach(Ability ability in abilities)
			{
				var instance = ability.CreateInstance(owner);
				instance.transform.position = transform.position;
				abilityInstances.Add(instance);
			}

			if(abilities.Count != abilityInstances.Count)
			{
				Debug.LogError("Not all abilities initialized for: " + owner.name);
			}

			previous = abilityInstances[0];
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

			if(!previous.Finished)
				return;

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
			ability.gameObject.SetActive(true);
			ability.Activate();
			cooldownTimer = globalCooldown;
		}
	}
}
