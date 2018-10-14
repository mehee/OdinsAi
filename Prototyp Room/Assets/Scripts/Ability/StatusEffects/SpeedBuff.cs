using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : StatusEffect
{
	public float speedModifier = 1.5f;
	Movement modifiedMovement;

	public override void Attach(Transform target)
	{
		var instance = Instantiate(this);
		instance.transform.parent = target.transform;
		instance.modifiedMovement = instance.transform.parent.GetComponent<Movement>();
		instance.Apply();
	}

    public override void Apply()
    {
		modifiedMovement.MovementSpeed *= speedModifier;
    }

	void Update()
	{
		if(!lifeTime.IsActive)
		{
			modifiedMovement.MovementSpeed /= speedModifier;
			Destroy(gameObject);
		}
	}
}
