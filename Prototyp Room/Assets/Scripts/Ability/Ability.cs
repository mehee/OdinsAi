using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Ability : MonoBehaviour
{
	float timeOfLastActivation;
	uint frameCounter = 0;
	
	new protected Collider2D collider;

	[SerializeField]
	protected AbilityInfo info;

	protected abstract void OnTriggerEnter2D(Collider2D other);

	public float Cooldown
	{
		get
		{
			return info.baseCooldown * info.cooldownModifier;
		}
	}

	public float Cost
	{
		get
		{
			return info.baseCost * info.costModifier;
		}
	}

	public float Damage
	{
		get
		{
			return info.baseDamage * info.damageModifier;
		}
	}

	protected virtual void Awake()
	{
		collider = GetComponent<Collider2D>();
		collider.enabled = false;
	}

	protected virtual void Update()
	{
		if(frameCounter > info.framesActive)
		{
			collider.enabled = false;
			frameCounter = 0;
		}

		if(collider.enabled)
		{
			frameCounter++;
		}
	}

	public virtual void Activate(float resource)
	{
		if(!ReadyForActivation(resource))
		{
			// TODO: Replace with proper sounds and UI message!
			Debug.Log("Ability not ready");
			return;
		}
	}
	

	/** The overloaded variant of this function
		takes in a float out-parameter for getting
		the remaining time if needed. */
	public bool CooldownReady()
	{
		float currentTime = Time.time;
		if(currentTime - timeOfLastActivation > Cooldown)
			return true;
		return false;
	}

	public bool CooldownReady(out float remainingTime)
	{
		float currentTime = Time.time;
		float difference = currentTime - timeOfLastActivation;
		remainingTime = Cooldown - difference;
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
