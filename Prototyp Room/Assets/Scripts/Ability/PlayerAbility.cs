﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AbilitySystem
{
	public abstract class PlayerAbility : Ability, IDescribable
	{
		public enum Playstyle{warrior, mage}
		// Inspector Variables

		[SerializeField]
		Cost cost;
		public Sprite icon;
		public bool alignedToMouse = false;

		public Playstyle playstyle;
		
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
			direction.x = rawDirection.x;
			direction.y = rawDirection.y;
			transform.up = direction;
		}


		//Color HexCodes
		//0084D9 BLUE	mage
		//FF3D00 RED	warrior
		//CB5D00 Orange Rage

		// Tooltips
		public virtual string GetDescription()
		{
			string baseString = string.Format("");
			switch (playstyle)
			{
				case Playstyle.warrior:
					baseString = string.Format("<b>{0}</b>\n<i>Cost: <color=#CB5D00>{1}</color> Rage</i>\n{2}\n\nPlaystyle: <color=#FF3D00>{3}</color>", name, cost.Value, description, playstyle);
					break;
				case Playstyle.mage:
					baseString = string.Format("<b>{0}</b>\n<i>Cost: <color=#CB5D00>{1}</color> Rage</i>\n{2}\n\nPlaystyle: <color=#0084D9>{3}</color>", name, cost.Value, description, playstyle);
					break;
			}
			return  baseString;
		}
	}
}