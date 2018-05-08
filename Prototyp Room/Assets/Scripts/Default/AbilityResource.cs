using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityResource : Resource
{
	[SerializeField]
	protected int regenInterval;
	[SerializeField]
	protected int regenAmount;

	protected virtual void Awake()
	{
		Value = Maximum;
	}

	protected override void Update()
	{
		
	}
}
