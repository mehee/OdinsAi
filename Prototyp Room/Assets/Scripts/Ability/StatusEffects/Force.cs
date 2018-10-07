using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : StatusEffect
{
	[HideInInspector]
	public float strength = 5f;

	[HideInInspector]
	public Vector2 direction;

	Movement targetMovement;

	public override void Attach(Transform target)
	{
		var instance = Instantiate(this);
		instance.transform.parent = target;
		instance.targetMovement = target.GetComponent<Movement>();
		instance.targetMovement.rooted = true;
	}

    public override void Apply()
    {
		transform.parent.position += (Vector3)(direction * strength * Time.deltaTime);
    }

    void Update()
	{
		Apply();

		if(!lifeTime.IsActive)
		{
			targetMovement.rooted = false;
			Destroy(gameObject);
		}
	}
}
