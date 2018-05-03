using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect : MonoBehaviour 
{
	protected float creationTime;

	[SerializeField]
	protected float baseDuration;
	[SerializeField]
	protected float durationModifier;
	protected float remainingDuration;
	[SerializeField]
	/** Amount of seconds between
		effect applications. */
	protected float interval;
	protected float lastApplicationTime;

    public float RemainingDuration
    {
        get { return remainingDuration; }
    }

    public float DurationModifier
    {
        get
        {
            return durationModifier;
        }

        set
        {
            durationModifier = value;
        }
    }

	public float Duration
	{
		get { return baseDuration * durationModifier; }
	}

	protected virtual void Awake()
	{
		creationTime = Time.time;
		lastApplicationTime = -Duration;
	}

    public virtual void Apply()
	{

	}
}
