using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ability
{
	/** Base class for all abilities. */
	[RequireComponent(typeof(Cooldown))]
	public abstract class Ability : MonoBehaviour
	{
		Cooldown cooldown;
		Cost cost;
		bool finished = true;

		protected AbilityResource resource;
		protected int frameCount = 0;
		[Range(0, 1000)]
		public int durationInFrames = 0;
		new public string name;
		[TextArea(1, 5)]
		public string description;

		[HideInInspector] public Character owner;

		public Sprite icon;
		public AudioClip sound;

		public bool Finished
		{
			get { return finished; }
		}

		/** Tells the ability to finish and
			cease resovling its effects. */
		public void Finish()
		{
			finished = true;
			frameCount = 0;
			CleanUp();
		}

		void Start()
		{
			GetComponent<Cooldown>();
			SetUp();
		}

		void Update()
		{
			if(!finished)
			{
				frameCount++;
				ResolveOngoingEffects();
				FinishIfDurationOver();
			}
		}

		/** Use instead of Instantiate()! */
		public Ability CreateInstance(Character owner)
		{	
			var abilityInstance = Instantiate(this);
			abilityInstance.owner = owner;
			abilityInstance.transform.parent = owner.transform;
			abilityInstance.resource = owner.GetComponent<AbilityResource>();
			return abilityInstance;
		}

		public void Activate()
		{
			finished = false;
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

		

		/** Finishes the ability once enough frames have passed. */
		protected virtual void FinishIfDurationOver()
		{
			if(frameCount == durationInFrames)
				Finish(); 
		}

		/** This function will be automatically 
			called through Start(). Override
			to add further initialization logic. */
		public virtual void SetUp()
		{

		}

		/** Override to add functionality to the activaton
			of the ability. */
		public virtual void OnActivation()
		{

		}

		/** This function will be automatically
			called through Update(). It will not
			be called if the ability has finished. 
			Override this to extend the functionality 
			of the base classes Update() method. */
		public virtual void ResolveOngoingEffects()
		{

		}

		/** Used for cleanup code in case
			your ability gets interrupted. 
			Override to add functionality. */
		public virtual void CleanUp()
		{

		}
	}
}
