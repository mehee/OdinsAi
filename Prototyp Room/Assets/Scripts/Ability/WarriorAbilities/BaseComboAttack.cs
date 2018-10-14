using UnityEngine;

namespace AbilitySystem
{
    [RequireComponent(typeof(BoxCollider2D))]
	public class BaseComboAttack : PlayerAbility 
	{
		public Damage damage;
		new BoxCollider2D collider;

		protected override void SetUp()
		{
			collider = GetComponent<BoxCollider2D>();
			collider.enabled = false;
			transform.GetChild(0).gameObject.SetActive(false);
		}

		protected override void OnActivation()
		{
			collider.enabled = true;
			transform.GetChild(0).gameObject.SetActive(true);
		}

		protected override void CleanUp()
		{
			collider.enabled = false;
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