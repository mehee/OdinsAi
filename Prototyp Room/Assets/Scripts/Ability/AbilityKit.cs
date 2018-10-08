using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
	/** The set of abilities the player posesses. 
		Makes sure abilities are only activated when
		the ones before are finished. */
	public class AbilityKit : MonoBehaviour 
	{	
		[SerializeField]
		List<PlayerAbility> abilities;
		List<PlayerAbility> abilityInstances;
		
		[SerializeField]
		float globalCooldown = 0.1f;
		float cooldownTimer;

		public List<PlayerAbility> MyAbilities
		{
			get {return abilities;}
		}

		private Character owner;
		private PlayerAbility previous;

		void Start()
		{	
			owner = GetComponent<Character>();
			abilityInstances = new List<PlayerAbility>(abilities.Count);
			for(int i = 0; i < abilities.Count; i++)
			{
				var instance = abilities[i].CreateInstance(owner) as PlayerAbility;
				instance.transform.localPosition = Vector3.zero;
				instance.transform.localScale = Vector2.one;
				instance.associatedButton = "Ability" + (i + 1);
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

			PlayerAbility activated = GetActivatedAbility();
			if(activated)
				Activate(activated);
		}

		/** Make sure that for every ability
			there is a corresponding button
			set in 'Preferences->Input'!
			
			Returns null if there was no input. */
		PlayerAbility GetActivatedAbility()
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

		void Activate(PlayerAbility ability)
		{
			if(!ability.ReadyForActivation())
				return;
			ability.Activate();
			cooldownTimer = globalCooldown;
		}

		public void SwapSkill(PlayerAbility ability,int slot)
		{
			Destroy(abilityInstances[slot]);
			abilities[slot] = ability;
			var instance = ability.CreateInstance(owner) as PlayerAbility;
			instance.associatedButton = "Ability" + (slot + 1);
			instance.transform.position = transform.position;
			abilityInstances[slot] = instance;
		}
	}
}
