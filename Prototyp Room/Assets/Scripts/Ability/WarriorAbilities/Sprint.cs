using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySystem;

public class Sprint : PlayerAbility 
{
    [SerializeField]
	SpeedBuff buff;

    protected override void OnActivation()
    {
        buff.Attach(owner.gameObject.transform);
    }
}
