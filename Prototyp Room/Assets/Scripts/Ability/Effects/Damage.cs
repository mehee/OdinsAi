using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : Effect
{
	public Damage() : base()
	{

	}

	private Damage(float baseMagnitude) : base()
	{
		this.baseMagnitude = baseMagnitude;
	}

    public override void AddToTargets(List<GameObject> targets)
    {
        foreach(GameObject target in targets)
		{
			try
			{
				Effect copy = new Damage(baseMagnitude);
				target.GetComponent<EffectStatus>().LogEffect(copy);
			}
			catch
			{
				Debug.LogError("Object missing EffecStatus component!");
			}
		}
    }

    public override void Apply(GameObject target)
    {
        throw new System.NotImplementedException();
    }

    public override void Apply(GameObject target, float magnitudeModifier)
    {
        throw new System.NotImplementedException();
    }
}
