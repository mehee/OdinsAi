using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySystem;

public class HookThrow : Ability 
{
	ChainHook hook;

	public override void OnActivation() 
	{
		hook.gameObject.SetActive(true);
	}

	public override void SetUp()
	{
		hook = Instantiate(hook);
		hook.transform.SetParent(transform);
		hook.owner = this;
		hook.gameObject.SetActive(false);
	}

	public override void ResolveOngoingEffects()
	{

	}

	public override void CleanUp()
	{
		hook.gameObject.SetActive(false);
	}
}
