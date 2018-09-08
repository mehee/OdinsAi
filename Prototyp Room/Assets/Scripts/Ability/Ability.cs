using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Base class for all abilities. Remember
	to call Disable() once your Ability
	has finished. */
public abstract class Ability : MonoBehaviour
{
    float remainingCooldown;
	bool finished = true;

	// Direction of the ability
	// is clamped to the eight cardinal directions.
	protected Vector2 direction;
	protected AbilityResource resource;
	protected int frameCount = 0;

	new public string name;
	[TextArea(2, 5)]
	public string description;

	[SerializeField] float baseCooldown;
	[SerializeField] float baseCost;
	[SerializeField] float baseDamage;


	[HideInInspector] public Character owner;
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

	public bool Finished
	{
		get { return finished; }
	}

	/** Tells the ability to finish and
		cease resovling its effects. */
	public void Finish()
	{
		finished = true;
		frameCount = 0;
	}

	void Start()
	{
		SetUp();
	}

	/** Counts down the cooldown.
		Override if more functionality is wanted. */
	void Update()
	{
		if(remainingCooldown > 0)
		{
			remainingCooldown -= Time.deltaTime;
			if(remainingCooldown < 0)
				remainingCooldown = 0;
		}

		if(!finished)
		{
			frameCount++;
			ResolveOngoingEffects();
			FinishIfDurationOver();
		}
	}

	/** Use instead of Instantiate()! */
	public Ability CreateInstance(Character owner)
	{	
		var abilityInstance = Instantiate(this);
		abilityInstance.owner = owner;
		abilityInstance.transform.parent = owner.transform;
		abilityInstance.resource = owner.GetComponent<AbilityResource>();
		return abilityInstance;
	}

    public void Activate()
	{
		finished = false;
		OnActivation();
	}

	public virtual bool ReadyForActivation()
	{
		if(EnoughResources() && OffCoolDown())
			return true;
		return false;
	}

	public virtual bool EnoughResources()
	{
		if(resource.Value < Cost)
			return false;
		return true;
	}

	public bool OffCoolDown()
	{
		if(remainingCooldown == 0)
			return true;
		return false;
	}

	/** Rotate the transform so that it
		faces the mouse. */
	protected void AlignWithMouse()
	{
		Vector2 rawDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		direction.x = Mathf.Round(rawDirection.x);
		direction.y = Mathf.Round(rawDirection.y);
		float angle = Mathf.Atan2(direction.x, direction.y);
		direction = direction.normalized;
		transform.up = direction;
	}

	/** This function will be automatically 
		called through Start(). Override
		to add further initialization logic. */
	protected virtual void SetUp()
	{

	}

	/** Override to add functionality to the activaton
		of the ability. */
	protected virtual void OnActivation()
	{

	}

	/** This function will be automatically
		called through Update(). It will not
		be called if the ability has finished. 
		Override this to extend the functionality 
		of the base classes Update() method. */
	protected virtual void ResolveOngoingEffects()
	{

	}

	/** Used for cleanup code in case
		your ability gets interrupted. 
		Override to add functionality. */
	protected virtual void CleanUp()
	{

	}

	/** Finishes the ability once enough frames have passed. */
	protected virtual void FinishIfDurationOver()
	{
		if(frameCount == startupFrames + activeFrames + recoveryFrames)
			Finish(); 
	}
}
