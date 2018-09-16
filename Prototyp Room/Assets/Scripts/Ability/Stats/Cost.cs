using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
	[System.Serializable]
	public class Cost
	{
		[SerializeField]
		float baseValue = 0f;
		[SerializeField][Range(0, 10)]
		float modifier = 1f;

		public float Value
		{
			get { return baseValue * modifier; }
		}
	}
}