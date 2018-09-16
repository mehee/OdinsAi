using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
	[RequireComponent(typeof(BoxCollider2D))]
	public class BaseComboAttack : Ability 
	{
		public Damage damage;
		new BoxCollider2D collider;

		public override void SetUp()
		{
			collider = GetComponent<BoxCollider2D>();
		}

		public override void OnActivation()
		{
			collider.enabled = true;
			transform.GetChild(0).gameObject.SetActive(true);
			Debug.Log(gameObject.name + " was activated.");
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