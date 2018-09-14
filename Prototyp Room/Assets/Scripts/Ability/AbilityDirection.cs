using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbilitySystem
{
	public class AbilityDirection : MonoBehaviour 
	{
		[SerializeField]
		bool alignedToMouse = false;
		[SerializeField]
		bool orbiting = true;
		[SerializeField]
		Vector2 orbitRadii;
		Vector2 direction;
		
		int ellipseGranularity = 36;

        public Vector2 Direction
        {
            get
            {
                return direction;
            }

            private set
            {
                direction = value;
            }
        }

        /** Rotate the transform so that it
			faces the mouse. */
        void AlignWithMouse()
		{
			Vector2 rawDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
			rawDirection.Normalize();
			direction.x = Mathf.Round(rawDirection.x);
			direction.y = Mathf.Round(rawDirection.y);
		}

		// Update is called once per frame
		void Update () 
		{
			if(alignedToMouse)
				AlignWithMouse();

			RotateTransform();

			if(orbiting)
				SelectPositionOnOrbit();
		}

		void RotateTransform()
		{
			transform.up = direction;
		}

        void SelectPositionOnOrbit()
        {
			Vector2 position;
			float radiansRotation = -transform.rotation.eulerAngles.z * Mathf.Deg2Rad;
			position.x = transform.parent.position.x + orbitRadii.x * Mathf.Sin(radiansRotation);
			position.y = transform.parent.position.y + orbitRadii.y * Mathf.Cos(radiansRotation);
			transform.position = position;
        }

		void OnDrawGizmosSelected()
		{
			if(orbiting)
			{
				var orbitVertices = new Vector2[ellipseGranularity];
				for(int i = 0; i < ellipseGranularity; i++)
				{
					float angle = ((float)i / ellipseGranularity) * 360 * Mathf.Deg2Rad;
					if(transform.parent)
					{
						orbitVertices[i].x = transform.parent.position.x + (orbitRadii.x * Mathf.Sin(angle)); 
						orbitVertices[i].y = transform.parent.position.y + (orbitRadii.y * Mathf.Cos(angle)); 
					}
					else
					{
						orbitVertices[i].x = transform.position.x + (orbitRadii.x * Mathf.Sin(angle)); 
						orbitVertices[i].y = transform.position.y + (orbitRadii.y * Mathf.Cos(angle)); 
					}
				}

				for(int i = 0; i < ellipseGranularity - 1; i++)
				{
					Gizmos.DrawLine(orbitVertices[i], orbitVertices[i + 1]);
				}
				Gizmos.color = Color.green;
				Gizmos.DrawLine(orbitVertices[0], orbitVertices[ellipseGranularity - 1]);
			}
		}
	}
}
