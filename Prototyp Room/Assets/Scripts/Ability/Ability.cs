using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
	/** Base class for all abilities. */
	[RequireComponent(typeof(Timer))]
	public abstract class Ability : MonoBehaviour
	{
		// Inspector Variables

		new public string name;
		[TextArea(1, 5)]
		public string description;
		[Range(1, 1000)]
		public int durationInFrames = 1;

		/** Define an orbit to achieve more believable
			hitbox placement on characters whose sprite
			width and height differ significantly. */
		[SerializeField]
		protected AbilityOrbit orbit;

		// Hidden Variables

		[HideInInspector] 
		public Character owner;

		[HideInInspector]
		public Vector2 direction;

		protected AudioSource audioSource;
		protected bool finished = true;
		protected int frameCount = 0;

		/** Determines the roughness of the ellipse gizmo. */
		int ellipseGizmoSections = 36;
		

		public bool Finished
		{
			get { return finished; }
		}

		/** Tells the ability to finish and
			cease resovling its effects. */
        public virtual void Finish()
		{
			finished = true;
			frameCount = 0;
			CleanUp();
		}

		/** Use instead of Instantiate()! */
        public virtual Ability CreateInstance(Character owner)
		{	
			var abilityInstance = Instantiate(this);
			abilityInstance.owner = owner;
			abilityInstance.transform.SetParent(owner.transform);
			abilityInstance.transform.localPosition = Vector3.zero;
			return abilityInstance;
		}

		public virtual void Activate()
		{
			finished = false;
			if(orbit.orbiting)
				SelectPositionOnOrbit();
			if(audioSource)
				audioSource.Play();
			OnActivation();
		}

		protected void SelectPositionOnOrbit()
        {
			Vector2 position;
			float radiansRotation = -transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
			position.x = transform.parent.position.x + orbit.orbitRadii.x * Mathf.Sin(radiansRotation);
			position.y = transform.parent.position.y + orbit.orbitRadii.y * Mathf.Cos(radiansRotation);
			transform.position = position;
        }
		
		protected virtual void FinishIfDurationOver()
		{
			if(frameCount == durationInFrames)
			{
				Finish(); 
			}
		}

		/** This function will be automatically 
			called through Start(). Override
			to add further initialization logic. */
		protected virtual void SetUp()
		{

		}

		/** Override to add functionality to the activaton
			of the ability. */
		protected virtual void OnActivation()
		{

		}

		/** This function will be automatically
			called through Update(). It will not
			be called if the ability has finished. 
			Override this to extend the functionality 
			of the base classes Update() method. */
		protected virtual void ResolveOngoingEffects()
		{

		}

		/** Called once the ability is finished. 
			Override to add functionality. */
		protected virtual void CleanUp()
		{

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
            DrawOrbitOutline();
        }

        void DrawOrbitOutline()
        {
            if (orbit.orbiting)
            {
                var orbitVertices = new Vector2[ellipseGizmoSections];
                for (int i = 0; i < ellipseGizmoSections; i++)
                {
                    float angle = ((float)i / ellipseGizmoSections) * 360 * Mathf.Deg2Rad;
                    if (transform.parent)
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

                for (int i = 0; i < ellipseGizmoSections - 1; i++)
                {
                    Gizmos.DrawLine(orbitVertices[i], orbitVertices[i + 1]);
                }
                Gizmos.color = Color.green;
                Gizmos.DrawLine(orbitVertices[0], orbitVertices[ellipseGizmoSections - 1]);
            }
        }
	}
}
