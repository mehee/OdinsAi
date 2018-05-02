using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InstantEffect : Effect
{
    public override void CastOnTargets(List<GameObject> targets)
    {
        foreach(GameObject target in targets)
		{
			Apply(target);
		}
    }
}
