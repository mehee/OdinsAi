using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
	/** Simple Timer to be used for cooldowns
		or object life time. */
	public class Timer : MonoBehaviour
	{
		[Range(0, 600)][SerializeField] 
		float baseTime;
		[Range(0, 10)][SerializeField] 
		float modifier = 1f;
		[Range(0, int.MaxValue)] 
		float remaining;
		public bool IsActive { get; private set; }

		/** Returns the actual cooldown duration composed
			of the base cooldown and a modifier. */
		public float Duration
		{
			get
			{
				return baseTime * modifier;
			}
		}

        public float CooldownModifier
        {
            get
            {
                return modifier;
            }

            set
            {
                modifier = value;
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
		}

		void Update()
		{
			if(IsActive)
				ReduceRemainingTime();
		}
		
		void ReduceRemainingTime()
		{
			Remaining -= Time.deltaTime;
			if(Remaining <= (0 + epsilon))
				IsActive = false;
		}

		public void ReduceRemainingTimeBy(float seconds)
		{
			Remaining -= seconds;
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
