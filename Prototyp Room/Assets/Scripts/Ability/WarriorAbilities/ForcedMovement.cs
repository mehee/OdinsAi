using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySystem;

[RequireComponent(typeof(BoxCollider2D))]
public class ForcedMovement : PlayerAbility
{
	public Damage damage;
	public float pushStrengh = 30f;
	public Force push;

	new BoxCollider2D collider;
	
	protected override void SetUp()
	{
		collider = GetComponent<BoxCollider2D>();
		push.strength = pushStrengh;
	}

	protected override void OnActivation()
	{
		transform.GetChild(0).gameObject.SetActive(true);
		collider.enabled = true;
	}

	protected override void CleanUp()
	{
		transform.GetChild(0).gameObject.SetActive(false);
		collider.enabled = false;
	}

	protected override void AffectTargetsHit(Transform target)
	{
		push.direction = direction;
		push.Attach(target);
		var health = target.GetComponent<Health>();
		damage.InflictToTarget(owner.stats, health);
	}
}