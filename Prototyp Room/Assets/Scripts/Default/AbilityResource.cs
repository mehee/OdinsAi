using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityResource : Resource
{
	protected virtual void Awake()
	{
		Value = Maximum;
	}
}
