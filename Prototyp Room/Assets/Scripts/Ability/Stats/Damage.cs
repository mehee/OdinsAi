using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
	[System.Serializable]
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

		float maxDamageDeviation = 10f;

		public void InflictToTarget(Stats stats, Health targetHealth)
		{
			float randomDeviation = Random.Range(-maxDamageDeviation, maxDamageDeviation);
			float rawDamage = baseValue;
			rawDamage += stats.Strength * strengthScaling;
			rawDamage += stats.Intelligence * intelligenceScaling;
			rawDamage *= modifier;
			rawDamage += (rawDamage * randomDeviation) / 100;
			rawDamage = Mathf.Round(rawDamage);
			targetHealth.Reduce(rawDamage);
		}
	}
}
