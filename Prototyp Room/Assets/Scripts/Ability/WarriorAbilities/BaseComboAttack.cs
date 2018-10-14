using UnityEngine;

namespace AbilitySystem
{
    [RequireComponent(typeof(BoxCollider2D))]
	public class BaseComboAttack : PlayerAbility 
	{
		public Damage damage;
		BoxCollider2D hitbox;

		protected override void SetUp()
		{
			hitbox = GetComponent<BoxCollider2D>();
			hitbox.enabled = false;
			transform.GetChild(0).gameObject.SetActive(false);
		}

		protected override void OnActivation()
		{
			hitbox.enabled = true;
			transform.GetChild(0).gameObject.SetActive(true);
		}

		protected override void CleanUp()
		{
			hitbox.enabled = false;
			transform.GetChild(0).gameObject.SetActive(false);
		}

		public override bool EnoughResources()
		{
			return true;
		} 

		protected override void AffectTargetsHit(Transform target)
		{
			var health = target.GetComponent<Health>();
			damage.InflictToTarget(owner.stats, health);
		}
	}
}