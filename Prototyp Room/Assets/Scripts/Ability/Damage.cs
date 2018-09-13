using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
	public class Damage
	{
		[Range(0, float.MaxValue)]
		public float baseValue;
		[Range(0, float.MaxValue)]
		public float modifier = 1f; 
		[Range(0, float.MaxValue)] 
		public float strengthScaling = 0f; 
		[Range(0, float.MaxValue)] 
		public float intelligenceScaling = 0f;

		public void InflictToTarget(Stats stats, Health targetHealth)
		{
			float rawDamage = baseValue;
			rawDamage += stats.Strength * strengthScaling;
			rawDamage += stats.Intelligence * intelligenceScaling;
			rawDamage *= modifier;
			targetHealth.Reduce(rawDamage);
		}
	}
}
