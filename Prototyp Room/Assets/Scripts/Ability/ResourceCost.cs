using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
	[System.Serializable]
	public class ResourceCost
	{
		[SerializeField][Range(0, 1000)] 
		float baseValue = 0f;
		[Range(0, 10f)] public float modifier = 1f;

		public float Value
		{
			get { return baseValue * modifier; }
		}
	}
}
