using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
	/** Base class for all abilities. */
	[RequireComponent(typeof(Cooldown), typeof(Cost))]
	public abstract class Ability : MonoBehaviour
	{
		Cooldown cooldown;
		bool finished = true;
		/** Determines the roughness of the ellipse gizmo. */
		int ellipseGizmoSections = 36;
		
		protected AbilityResource resource;
		protected int frameCount = 0;
		
		new public string name;
		[TextArea(1, 5)]
		public string description;

		[SerializeField]
		Cost cost;

		[Range(0, 1000)]
		public int durationInFrames = 0;

		
		public Sprite icon;
		public AudioClip sound;

		public bool alignedToMouse = false;

		[SerializeField]
		AbilityOrbit orbit;

		[HideInInspector] 
		public Character owner;
		[HideInInspector]
		public Vector2 direction;
		[HideInInspector]
		public string associatedButton;
		

		public bool Finished
		{
			get { return finished; }
		}

        public Cooldown Cooldown
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
			cooldown = GetComponent<Cooldown>();
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

		void OnDrawGizmosSelected()
		{
			if(orbit.orbiting)
			{
				var orbitVertices = new Vector2[ellipseGizmoSections];
				for(int i = 0; i < ellipseGizmoSections; i++)
				{
					float angle = ((float)i / ellipseGizmoSections) * 360 * Mathf.Deg2Rad;
					if(transform.parent)
					{
						orbitVertices[i].x = transform.parent.position.x +
							(orbit.orbitRadii.x * Mathf.Sin(angle)); 
						orbitVertices[i].y = transform.parent.position.y + 
							(orbit.orbitRadii.y * Mathf.Cos(angle)); 
					}
					else
					{
						orbitVertices[i].x = transform.position.x + 
							(orbit.orbitRadii.x * Mathf.Sin(angle)); 
						orbitVertices[i].y = transform.position.y + 
							(orbit.orbitRadii.y * Mathf.Cos(angle)); 
					}
				}

				for(int i = 0; i < ellipseGizmoSections - 1; i++)
				{
					Gizmos.DrawLine(orbitVertices[i], orbitVertices[i + 1]);
				}
				Gizmos.color = Color.green;
				Gizmos.DrawLine(orbitVertices[0], orbitVertices[ellipseGizmoSections - 1]);
			}
		}

		/** Use instead of Instantiate()! */
		public Ability CreateInstance(Character owner)
		{	
			var abilityInstance = Instantiate(this);
			abilityInstance.owner = owner;
			abilityInstance.transform.SetParent(owner.transform);
			abilityInstance.resource = owner.GetComponent<AbilityResource>();
			return abilityInstance;
		}

		public void Activate()
		{
			finished = false;
			if(alignedToMouse)
				AlignWithMouse();
			if(orbit.orbiting)
				SelectPositionOnOrbit();
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

		public void AlignWithMouse()
		{
			Vector2 rawDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
			rawDirection.Normalize();
			direction.x = Mathf.Round(rawDirection.x);
			direction.y = Mathf.Round(rawDirection.y);
			transform.up = direction;
		}

		void SelectPositionOnOrbit()
        {
			Vector2 position;
			float radiansRotation = -transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
			position.x = transform.parent.position.x + orbit.orbitRadii.x * Mathf.Sin(radiansRotation);
			position.y = transform.parent.position.y + orbit.orbitRadii.y * Mathf.Cos(radiansRotation);
			transform.position = position;
        }

		/** Finishes the ability once enough frames have passed. */
		protected virtual void FinishIfDurationOver()
		{
			if(frameCount == durationInFrames)
			{
				Debug.Log("Duration over.");
				Finish(); 
			}
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
