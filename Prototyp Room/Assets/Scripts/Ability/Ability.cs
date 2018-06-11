using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Ability : MonoBehaviour
{
    private float remainingCooldown;

    protected Character owner;

	// Rotation and direction of the ability
	// are clamped to the eight cardinal directions
	protected Quaternion rotation;
	protected Vector2 direction;

	new public string name;
	[TextArea(2, 5)]
	public string description;

	[SerializeField]
	float baseCooldown;
	[SerializeField]
	float baseCost;
	[SerializeField]
	float baseDamage;

	public float cooldownModifier;
	public float costModifier;
	public float damageModifier;

	public float strengthScaling;
	public float intelligenceScaling;

	public int startupFrames;
	public int activeFrames;
	public int recoveryFrames;

	public Sprite icon;
	public AudioClip sound;

	public float Damage
	{
		get
		{
			float strengthBonus = strengthScaling * owner.stats.Strength;
			float intBonus = intelligenceScaling * owner.stats.Intelligence; 
			return (baseDamage + strengthBonus + intBonus) * damageModifier;
		}
	}

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

    public float RemainingCooldown
    {
        get
        {
            return remainingCooldown;
        }

        set
        {
            remainingCooldown = value;
        }
    }

    public abstract void Activate();

	public virtual bool ReadyForActivation()
	{
		if(EnoughResources() && OffCoolDown())
			return true;
		return false;
	}

	public virtual bool EnoughResources()
	{
		if(owner.GetComponent<AbilityResource>().Value < Cost)
			return false;
		return true;
	}

	public bool OffCoolDown()
	{
		if(remainingCooldown == 0)
			return true;
		return false;
	}

	protected virtual void Start()
	{
		owner = GetComponentInParent<Character>();
	}

	protected virtual void Update()
	{
		if(remainingCooldown > 0)
		{
			remainingCooldown -= Time.deltaTime;
			if(remainingCooldown < 0)
				remainingCooldown = 0;
		}
	}

	protected void AlignWithMouse()
	{
		Vector2 rawDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		direction.x = Mathf.Round(rawDirection.x);
		direction.y = Mathf.Round(rawDirection.y);
		float angle = Mathf.Atan2(direction.x, direction.y);
		Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.forward);
		direction = direction.normalized;
	}
}
