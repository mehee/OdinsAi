using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Holds all abilites a character
	has at its disposal. */
public class AbilitySet : MonoBehaviour 
{
	AudioClip notReadySound;

	float lastActivationTime;

	[SerializeField]
	float globalCooldown = 0.05f;

	public List<Ability> abilities;

	void Awake()
	{
		lastActivationTime = -globalCooldown;
		foreach(Ability ability in abilities)
		{
			ability.InstantiateHitbox(gameObject.transform);
		}
	}

	/** Tries to use Ability at the
		specified index in the AbilitySet. 
		Returns true if activation was successful. */
	public bool UseAbilityAtIndex(int index)
	{
		Ability ability = abilities[index];
		// TODO: properly integrate resource here
		if(Time.time - lastActivationTime < globalCooldown)
		{
			return false;
		}

		if(ability.ReadyForActivation(50))
		{
			ability.Activate();
			return true;
		}

		return false;
	}
}
