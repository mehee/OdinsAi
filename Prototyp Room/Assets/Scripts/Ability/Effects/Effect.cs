using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
/** An effect has changes behaviour
	or attributes of the targets its applied
	to over the course of its duration. It
	automatically vanishes after the duration
	ended. */
public abstract class Effect 
{
	[SerializeField]
	protected float baseMagnitude;
	
	[SerializeField]
	/** Determines the interval
		between applications of
		the effect. */
	public float Interval { get; private set; }

	[SerializeField]
	public bool IsPermanent
	{
		get
		{
			return IsPermanent;
		}
		protected set
		{
			IsPermanent = value;
		}
	}

	public float LastActivationTime { get; private set; }

	public float magnitudeModifier = 1f;

	/** Duration in seconds. */
	public float duration;
	public float creationTime;

	public Effect()
	{
		creationTime = Time.unscaledTime;
	}

	/** Changes targets based on the type and
		magnitude of the effect.
		The overloaded version lets you apply
		the effect with a modified magnitude. */
	public abstract void Apply(GameObject target);
	public abstract void Apply(GameObject target,
		float magnitudeModifier);

	public float RemainingDuration()
	{
		float remaining;
		remaining = duration - (Time.unscaledTime - creationTime);
		if(remaining <= 0.001f)
		{
			return 0f;
		}
		return remaining;
	}

	public void UpdateLastActivationTime()
	{
		LastActivationTime = Time.unscaledTime;
	}

	/** Adds a deep copy of self to the targets
		EffectStatus component so the effect can
		be applied several times. */
	public abstract void AddToTargets(List<GameObject> targets);
}
