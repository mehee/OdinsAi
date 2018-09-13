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
		[SerializeField][Range(0, float.MaxValue)]
		Vector2 orbitRadii;
		Vector2 vector;
		Vector2[] orbitVertices;
		int ellipseGranularity = 36;

        public Vector2 Vector
        {
            get
            {
                return vector;
            }

            private set
            {
                vector = value;
            }
        }

        /** Rotate the transform so that it
			faces the mouse. */
        void AlignWithMouse()
		{
			Vector2 rawDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
			vector.x = Mathf.Round(rawDirection.x);
			vector.y = Mathf.Round(rawDirection.y);
			vector = vector.normalized;
		}

		void Awake()
		{
			orbitVertices = new Vector2[ellipseGranularity];
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
			transform.up = vector;
		}

        void SelectPositionOnOrbit()
        {
			Vector2 position;
			float radiansRotation = transform.rotation.z * Mathf.Deg2Rad;
			position.x = vector.x * orbitRadii.x * Mathf.Sin(radiansRotation);
			position.y = vector.y * orbitRadii.y * Mathf.Cos(radiansRotation);
			transform.position = position;
        }

		void OnDrawGizmos()
		{
			for(int i = 0; i < ellipseGranularity; i++)
			{
				float angle = ((float)i / ellipseGranularity) * 360 * Mathf.Deg2Rad;
				orbitVertices[i].x = orbitRadii.x * Mathf.Sin(angle); 
				orbitVertices[i].y = orbitRadii.y * Mathf.Cos(angle); 
			}

			for(int i = 0; i < ellipseGranularity - 1; i++)
			{
				Gizmos.DrawLine(orbitVertices[i], orbitVertices[i + 1]);
			}
			Gizmos.DrawLine(orbitVertices[0], orbitVertices[ellipseGranularity]);
		}
	}
}
