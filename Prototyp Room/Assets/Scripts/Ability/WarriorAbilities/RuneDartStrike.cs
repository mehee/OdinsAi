using UnityEngine;

namespace AbilitySystem
{
    [RequireComponent(typeof(BoxCollider2D))]
	public class RuneDartStrike : PlayerAbility 
	{
		public Damage damage;
		public RuneDart dart;
		BoxCollider2D hitbox;

		protected override void SetUp()
		{
			hitbox = GetComponent<BoxCollider2D>();
			transform.GetChild(0).gameObject.SetActive(false);
		}

		protected override void OnActivation()
		{
			hitbox.enabled = true;
			transform.GetChild(0).gameObject.SetActive(true);
			var runeDart = Instantiate(dart);
			runeDart.direction = direction;
			runeDart.transform.position = transform.position;
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