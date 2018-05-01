using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Effect : ScriptableObject
{
	[SerializeField]
	protected float baseMagnitude;	
	
	public float magnitudeModifier = 1f;

	public Effect()
	{
	}

	/** Changes targets based on the type and
		magnitude of the effect. */
	public virtual void Apply(GameObject target)
	{

	}

	public abstract void CastOnTargets(List<GameObject> targets);
}
