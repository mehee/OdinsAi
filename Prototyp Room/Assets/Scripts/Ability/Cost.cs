using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
	[System.Serializable]
	public class Cost 
	{
		[SerializeField][Range(0, float.MaxValue)] 
		float baseValue = 0f;
		[Range(0, float.MaxValue)] public float modifier = 1f;

		public float Value
		{
			get { return baseValue * modifier; }
		}
	}
}
