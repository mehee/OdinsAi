﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySystem;

// In development
public class HookThrow : PlayerAbility 
{
	ChainHook hook;

	protected override void OnActivation() 
	{
		hook.gameObject.SetActive(true);
	}

	protected override void SetUp()
	{
		hook = Instantiate(hook);
		hook.transform.SetParent(transform);
		hook.owner = this;
		hook.gameObject.SetActive(false);
	}

	protected override void ResolveOngoingEffects()
	{

	}

	protected override void CleanUp()
	{
		hook.gameObject.SetActive(false);
	}
}
