using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySystem;

public abstract class StatusEffect : MonoBehaviour 
{
	[HideInInspector]
	public Timer lifeTime;

	[SerializeField]
	/** Amount of seconds between
		effect applications. */
	protected float interval;

	protected float lastApplicationTime;

	/** Triggers the consequences that
		the effect has on the target.
		(e.g. damage). */
    public abstract void Apply();

	protected virtual void Awake()
	{
		lifeTime = GetComponent<Timer>();
		lastApplicationTime = -lifeTime.Duration;
	}

	/** Puts a copy of itself onto 
		the target transforms GameObject. 
		Override to handle conflicts with
		other status effects of the same type. */
	public virtual void Attach(Transform target)
	{
		var instance = Instantiate(this);
		instance.transform.parent = target.transform;
		instance.lifeTime.StartTimer();
	}
}