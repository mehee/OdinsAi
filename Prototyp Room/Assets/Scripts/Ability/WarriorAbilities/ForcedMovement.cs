using UnityEngine;
using AbilitySystem;

[RequireComponent(typeof(BoxCollider2D))]
public class ForcedMovement : PlayerAbility
{
	public Damage damage;
	public float pushStrengh = 30f;
	public Force push;

	BoxCollider2D hitbox;
	
	protected override void SetUp()
	{
		hitbox = GetComponent<BoxCollider2D>();
		push.strength = pushStrengh;
	}

	protected override void OnActivation()
	{
		transform.GetChild(0).gameObject.SetActive(true);
		hitbox.enabled = true;
	}

	protected override void CleanUp()
	{
		transform.GetChild(0).gameObject.SetActive(false);
		hitbox.enabled = false;
	}

	protected override void AffectTargetsHit(Transform target)
	{
		push.direction = direction;
		push.Attach(target);
		var health = target.GetComponent<Health>();
		damage.InflictToTarget(owner.stats, health);
	}
}