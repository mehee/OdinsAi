using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySystem;

[RequireComponent(typeof(CircleCollider2D))]
public class SlamGround : EnemyAbility
{
	public Damage damage;
	public Color startingColor;
	public Color finishColor;
	new CircleCollider2D collider;
	SpriteRenderer spriteRenderer;

	protected override void SetUp()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		collider = GetComponent<CircleCollider2D>();
	}

	protected override void OnActivation()
	{
		spriteRenderer.color = startingColor;
		spriteRenderer.enabled = true;
	}

	protected override void ResolveOngoingEffects()
	{
		if(frameCount <= startupFrames)
		{
			float interpolationFactor = (float) frameCount / startupFrames;
			spriteRenderer.color = Color.Lerp(startingColor,
				finishColor, interpolationFactor);
		}

		if(frameCount == startupFrames)
		{
			collider.enabled = true;
		}
	}

	protected override void CleanUp()
	{
		collider.enabled = false;
		spriteRenderer.enabled = false;
	}

	protected override void AffectTargetsHit(Transform target)
	{
		var health = target.GetComponent<Health>();
		damage.InflictToTarget(owner.stats, health);
	}
}
