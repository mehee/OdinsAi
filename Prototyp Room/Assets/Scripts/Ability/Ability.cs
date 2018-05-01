using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Ability : ScriptableObject 
{
	float timeOfLastActivation;
	List<GameObject> targets;

	[SerializeField]
	float baseCooldown;
	[SerializeField]
	float baseCost;

	public float cooldownModifier = 1f;
	public float costModifier = 1f;

	public string description;
	public Sprite icon;
	public AnimationClip animation;
	public AudioClip sound;
	public List<Effect> effects;
	public Hitbox hitbox;

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

	public void Activate()
	{
		targets = hitbox.QueryTargets();
		foreach(Effect effect in effects)
		{
			effect.CastOnTargets(targets);
		}
	}

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

	public void InstantiateHitbox(Transform transform)
	{
		Instantiate<Hitbox>(hitbox, transform.position, 
			transform.rotation);
	}
}
