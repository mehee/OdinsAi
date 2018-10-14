using UnityEngine;
using AbilitySystem;

[RequireComponent(typeof(CircleCollider2D))]
public class SlamGround : EnemyAbility
{
	public Damage damage;
	public Color startingColor;
	public Color finishColor;
	CircleCollider2D hitbox;
	SpriteRenderer spriteRenderer;

	protected override void SetUp()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		hitbox = GetComponent<CircleCollider2D>();
	}

	protected override void OnActivation()
	{
		spriteRenderer.enabled = true;
		spriteRenderer.color = startingColor;
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
			hitbox.enabled = true;
		}
	}

	protected override void CleanUp()
	{
		hitbox.enabled = false;
		spriteRenderer.enabled = false;
	}

	protected override void AffectTargetsHit(Transform target)
	{
		var health = target.GetComponent<Health>();
		damage.InflictToTarget(owner.stats, health);
	}
}
