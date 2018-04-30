using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Enables game objects to recieve
	Effects and remove effects */
public class EffectStatus: MonoBehaviour 
{
	List<Effect> activeEffects;

	void Update()
	{
		foreach(Effect effect in activeEffects)
		{
			if(!effect.IsPermanent)
			{
				if(effect.RemainingDuration() == 0)
				{
					activeEffects.Remove(effect);
				}
			}
			if((Time.unscaledTime - effect.LastActivationTime) 
				>= effect.Interval)
			{
				effect.Apply(gameObject);
				effect.UpdateLastActivationTime();
			}
		}
	}

	public void LogEffect(Effect effect)
	{
		activeEffects.Add(effect);
	}
}
