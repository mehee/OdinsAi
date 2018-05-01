using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/** Contains all active Effects affecting
	this character and makes sure they are
applied and removed at the proper times. */
public class EffectStatus : MonoBehaviour 
{
	List<PersistentEffect> activeEffects;

	// Use this for initialization
	void Start () 
	{
		activeEffects = new List<PersistentEffect>();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		foreach(var effect in activeEffects)
		{
			if(effect is TemporaryEffect)
			{
				if((effect as TemporaryEffect).RemainingDuration() <= 0)
				{
					activeEffects.Remove(effect);
					continue;
				}
			}

			if(effect.ReadyForApplication())
				effect.Apply(gameObject);
		}
	}

	public void AddEffect(PersistentEffect effect)
	{
		// TODO: Add way to resolve conflicts
	// between effects of same type.
		activeEffects.Add(effect);
	}
}
