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

	/** Triggers the consequences that
		the effect has on the target.
		(e.g. damage). */
    public abstract void Apply();

    public float RemainingDuration
    {
        get { return remainingDuration; }
		set { remainingDuration = value; }
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

	/** Puts a copy of itself onto 
		the target transforms GameObject. 
		Override to handle conflicts with
		other status effects of the same type. */
	public virtual void Attach(Transform target)
	{
		var instance = Instantiate(this);
		instance.transform.parent = target.transform;
	}
}