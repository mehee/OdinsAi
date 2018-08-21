using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Throw a hatchet in the direction of
	the mouse. Hatchets can be picked up by
	walking through them. */
public class ThrowHatchet : Ability
{
	[SerializeField] float speed;
	ObjectPool pool;

	void Start()
	{
		pool = GetComponent<ObjectPool>();
	}

    public override void Activate()
    {
		RemainingCooldown = Cooldown;
		Hatchet thrown = pool.Dispatch() as Hatchet;
		thrown.transform.position = transform.position;
		thrown.currentPosition = transform.position;
		AlignWithMouse();
		thrown.Velocity = speed * direction;
		thrown.collider.enabled = true;
    }

	public override bool ReadyForActivation()
	{
		if(pool.IsEmpty())
			return false;
		if(OffCoolDown() && (pool.Instances.Count > 0))
			return true;
		return false;
	}
}
