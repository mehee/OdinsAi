using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySystem;

public class HookThrow : Ability 
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

	public override void CleanUp()
	{
		hook.gameObject.SetActive(false);
	}
}
