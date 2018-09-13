using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
	public class BaseAttack : Ability
	{
		Damage damage;
		new BoxCollider2D collider;

		/** This function will be automatically 
			called through Start(). Override
			to add further initialization logic. */
		public override void SetUp()
		{
			collider = GetComponent<BoxCollider2D>();
		}

		/** Override to add functionality to the activaton
			of the ability. */
		public override void OnActivation()
		{
			collider.enabled = true;
		}

		/** This function will be automatically
			called through Update(). It will not
			be called if the ability has finished. 
			Override this to extend the functionality 
			of the base classes Update() method. */
		public override void ResolveOngoingEffects()
		{
			
		}

		/** Used for cleanup when your ability finishes. 
			Override to add functionality. */
		public override void CleanUp()
		{
			collider.enabled = false;
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
