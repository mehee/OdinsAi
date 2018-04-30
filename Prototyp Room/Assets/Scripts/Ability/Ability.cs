using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class Ability : ScriptableObject 
{
	float timeOfLastActivation;

	[SerializeField]
	float baseCooldown;
	[SerializeField]
	float baseCost;

	public string description;
	public Sprite icon;
	public AnimationClip animation;
	public AudioClip sound;
	public float cooldownModifier;
	public float costModifier;
	public List<Hitbox> hitboxes;
	public List<Effect> effects;

	public float Cooldown
	{
		get
		{
			return baseCooldown * cooldownModifier;
		}
	}

	public float Cost
	{
		get
		{
			return baseCost * costModifier;
		}
	}

	public abstract void Activate();

	/** The overloaded variant of this function
		takes in a float out-parameter for getting
		the remaining time if needed. */
	public bool CooldownReady()
	{
		float currentTime = Time.unscaledTime;
		if(currentTime - timeOfLastActivation > Cooldown)
			return true;
		return false;
	}

	public bool CooldownReady(out float remainingTime)
	{
		float currentTime = Time.unscaledTime;
		float difference = currentTime - timeOfLastActivation;
		remainingTime = costModifier - difference;
		if(remainingTime < 0)
		{
			remainingTime = 0;
			return true;
		}
		else
			return false;
	}

	public virtual bool ReadyForActivation(float availableResources)
	{
		if(!CooldownReady())
			return false;
		else if(availableResources < Cost)
			return false;
		return true;
	}
}
