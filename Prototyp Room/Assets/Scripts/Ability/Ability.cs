﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Ability : MonoBehaviour
{
	float cooldownTimer;
	uint frameCounter = 0;
	AbilityResource resource;
	
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
			var stats = transform.root.GetComponent<Character>().stats;
			float totalDamage = info.baseDamage;
			totalDamage += info.strengthScaling * stats.Strength;
			totalDamage += info.intelligenceScaling * stats.Intelligence;
			return totalDamage;
		}
	}

    public float CooldownTimer
    {
        get
        {
            return cooldownTimer;
        }
        set
        {
            cooldownTimer = value;
        }
    }

    protected virtual void Awake()
	{
		collider = GetComponent<Collider2D>();
		collider.enabled = false;
		resource = transform.parent.GetComponent<AbilityResource>();
	}

	protected virtual void Update()
	{
		if(frameCounter > info.framesActive)
		{
			collider.enabled = false;
			frameCounter = 0;
		}

		if(cooldownTimer > 0)
		{
			cooldownTimer -= Time.deltaTime;
			if(cooldownTimer < 0)
				cooldownTimer = 0;
		}

		if(collider.enabled)
		{
			frameCounter++;
		}
	}

	public virtual bool Activate()
	{
		if(!ReadyForActivation())
		{
			// TODO: Replace with proper sounds and UI message!
			Debug.Log("Ability not ready");
			return false;
		}
		cooldownTimer = Cooldown;
		resource.Reduce(Cost);
		return true;
	}
	

	public virtual bool ReadyForActivation()
	{
		if(cooldownTimer > 0)
			return false;
		else if(resource.Value < Cost)
			return false;
		return true;
	}
}
