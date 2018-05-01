using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
/** An effect that can be
	applied in fixed intervals.
	Implements the prototype pattern
	to spread itself from its origin
	to the target. Make sure to properly
	implement the copy method in deriving 
	classes. Pay attention to differences
	between deep and shallow copies. */
public abstract class PersistentEffect : Effect 
{
	[SerializeField]
	private float interval;
	
	/** When the effect last changed
		its targets. Make sure to update
		this when calling Apply(). */
	public float LastApplied { get; set; }

	/** Time in seconds between effect applications. */
	public float Interval
	{
		get { return interval; }
		protected set { interval = value; }
	}

	public bool ReadyForApplication()
	{
		if((Time.time - LastApplied) >= interval)
			return true;
		return false;
	}

	/** Adds a copy of itself to the 'EffectStatus'-Component
		of each target and applies itself an initial time. */
	public override void CastOnTargets(List<GameObject> targets)
	{
		foreach(GameObject target in targets)
		{
			Apply(target);
			LastApplied = Time.unscaledTime;
			target.GetComponent<EffectStatus>().AddEffect(Clone());
		}
	}

	public abstract PersistentEffect Clone();
}
