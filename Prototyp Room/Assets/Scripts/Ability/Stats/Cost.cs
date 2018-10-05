using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cost
{
	[SerializeField]
	float baseValue = 0f;
	[Range(0, 10)]
	public float modifier = 1f;

	public float Value
	{
		get { return baseValue * modifier; }
	}
}
