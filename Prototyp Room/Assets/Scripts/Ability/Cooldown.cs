using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
	public class Cooldown : MonoBehaviour
	{
		[Range(0f, float.MaxValue)] float baseCooldown;
		[Range(0f, float.MaxValue)] float cooldownModifier = 1f;
		[Range(0f, float.MaxValue)] float remaining;
		public bool IsActive { get; private set; }

		/** Returns the actual cooldown duration composed
			of the base cooldown and a modifier. */
		public float Duration
		{
			get
			{
				return baseCooldown * cooldownModifier;
			}
		}

        public float CooldownModifier
        {
            get
            {
                return cooldownModifier;
            }

            set
            {
                cooldownModifier = value;
            }
        }

        public float Remaining
        {
            get
            {
                return remaining;
            }

            set
            {
                remaining = value;
				if(remaining <= 0)
					IsActive = false;
            }
        }

        const float epsilon = 0.00001f;

		void Start()
		{
			Remaining = Duration;
			IsActive = false;
		}

		void Update()
		{
			if(IsActive)
				ReduceRemainingTime();
		}
		
		public void ReduceRemainingTime()
		{
			Remaining -= Time.deltaTime;
			if(Remaining <= (0 + epsilon))
				IsActive = false;
		}

		/** This will (re)start the cooldown. */
		public void StartTimer()
		{
			IsActive = true;
			Remaining = Duration;
		}
	}
}
