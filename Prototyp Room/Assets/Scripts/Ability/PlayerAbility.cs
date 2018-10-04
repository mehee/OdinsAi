using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
	public abstract class PlayerAbility : Ability 
	{
		// Inspector Variables

		[SerializeField]
		Cost cost;
		public Sprite icon;
		public bool alignedToMouse = false;
		
		// Hidden Variables

		[HideInInspector]
		public string associatedButton;

		protected AbilityResource resource;

		Timer cooldown;
		
		public Timer Cooldown
        {
            get
            {
                return cooldown;
            }
        }

        public Cost Cost
        {
            get
            {
                return cost;
            }
        }

		void Start()
		{
			cooldown = GetComponent<Timer>();
			if(!cooldown)
				Debug.LogError("Cooldown not found");
			audioSource = GetComponent<AudioSource>();
			SetUp();
		}

		public override void Finish()
		{
			finished = true;
			frameCount = 0;
			cooldown.StartTimer();
			CleanUp();
		}

		public override Ability CreateInstance(Character owner)
		{	
			var abilityInstance = base.CreateInstance(owner) as PlayerAbility;
			abilityInstance.resource = owner.GetComponent<AbilityResource>();
			return abilityInstance;
		}

		public override void Activate()
		{
			finished = false;
			if(alignedToMouse)
				AlignWithMouse();
			if(orbit.orbiting)
				SelectPositionOnOrbit();
			if(audioSource)
				audioSource.Play();
			OnActivation();
		}

		public virtual bool ReadyForActivation()
		{
			if(EnoughResources() && !cooldown.IsActive)
				return true;
			return false;
		}

		public virtual bool EnoughResources()
		{
			if(resource.Value < cost.Value)
				return false;
			return true;
		}

		/** Rotates the abilities transform so
			that it faces the mouse cursor. */
		protected void AlignWithMouse()
		{
			Vector2 rawDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
			rawDirection.Normalize();
			direction.x = Mathf.Round(rawDirection.x);
			direction.y = Mathf.Round(rawDirection.y);
			transform.up = direction;
		}
	}
}
