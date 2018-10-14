using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
	public abstract class EnemyAbility : Ability
	{
		/** Prolong the duration of the ability 
			with an initial startup phase. 
			Useful for delaying hitbox activation. */
		[SerializeField] 
		protected int startupFrames = 0;
		
		protected override void FinishIfDurationOver()
		{
			if(frameCount == durationInFrames + startupFrames)
			{
				Finish(); 
			}
		}

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            SetUp();
        }

		void OnTriggerEnter2D(Collider2D other)
		{
			if(other is BoxCollider2D && other.tag == "Player")
			{
				AffectTargetsHit(other.transform);
			}
		}
    }
}
