using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Ability : MonoBehaviour
{
	protected float cooldownTimer;
	protected AbilityResource resource;
	protected Vector2 direction;

	[SerializeField]
	protected AbilityInfo info;

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
			totalDamage *= info.damageModifier;
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
		resource = transform.parent.GetComponent<AbilityResource>();
	}

	protected virtual void Update()
	{
		if(cooldownTimer > 0)
		{
			cooldownTimer -= Time.deltaTime;
			if(cooldownTimer < 0)
				cooldownTimer = 0;
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
		AlignAbilityWithMouse();
		return true;
	}

	/** Ability gets rotated so that it aligns
		with the one of the 8 cardinal directions that
		the mouse is closest to. */
	protected void AlignAbilityWithMouse()
	{
		Vector3 difference = Camera.main.WorldToScreenPoint(Input.mousePosition)
			- transform.root.position;
		float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
		rotation /= 45;
		rotation = Mathf.Round(rotation) * 45;
		transform.rotation = Quaternion.Euler(0, 0, rotation - 90); 
		direction = transform.rotation * Vector3.forward;
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
