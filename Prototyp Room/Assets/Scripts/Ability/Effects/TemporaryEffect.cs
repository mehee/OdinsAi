using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/** A type of persisten effect that
	only persists for a set duration. */
public abstract class TemporaryEffect : PersistentEffect
{
	[SerializeField]
	float baseDuration;
	
	public float durationModifier = 1f;

	public float Duration
	{
		get
		{
			return baseDuration * durationModifier;
		}
	}

	public virtual float RemainingDuration()
	{
		float remaining = durationModifier - 
			(Time.time - LastApplied);
		if(remaining <= 0)
			return 0;
		else
			return remaining;
	}
}
