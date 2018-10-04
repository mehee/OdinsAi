using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
	[RequireComponent(typeof(BoxCollider2D))]
	public class RuneDartStrike : Ability 
	{
		public Damage damage;
		public RuneDart dart;
		new BoxCollider2D collider;

		protected override void SetUp()
		{
			collider = GetComponent<BoxCollider2D>();
		}

		protected override void OnActivation()
		{
			collider.enabled = true;
			transform.GetChild(0).gameObject.SetActive(true);
			var runeDart = Instantiate(dart);
			runeDart.direction = direction;
			runeDart.transform.position = transform.position;
		}

		public override void CleanUp()
		{
			collider.enabled = false;
			transform.GetChild(0).gameObject.SetActive(false);
		}

		public override bool EnoughResources()
		{
			return true;
		} 

		void OnTriggerEnter2D(Collider2D other)
		{
			if(other.gameObject.tag == "Enemy")
			{
				var health = other.gameObject.GetComponent<Health>();
				damage.InflictToTarget(owner.stats, health);
			}
		}
	}
}