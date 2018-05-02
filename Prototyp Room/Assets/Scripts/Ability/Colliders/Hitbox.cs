using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour 
{
	[SerializeField][Tooltip("The name of the layer that can be hit.")]
	string layerName;

	[SerializeField]
	Color color = new Color(255, 0, 0, 65);

	[SerializeField]
	int maxTargetAmount;

	LayerMask mask;
	ContactFilter2D contactFilter;
	BoxCollider2D[] attachedColliders;
	Collider2D[] overlaps;

	void Awake()
	{
		mask = new LayerMask();
		mask.value = LayerMask.NameToLayer(layerName);
		contactFilter = new ContactFilter2D();
		contactFilter.SetLayerMask(mask);

		attachedColliders = gameObject.
			GetComponentsInChildren<BoxCollider2D>() 
			as BoxCollider2D[];
		
		overlaps = new Collider2D[maxTargetAmount];
	}

	 void OnDrawGizmos()
	{

		attachedColliders = gameObject.
			GetComponentsInChildren<BoxCollider2D>() 
			as BoxCollider2D[];
		
		Gizmos.color = color;
		
		foreach(BoxCollider2D collider in attachedColliders)
		{
			Gizmos.DrawCube(collider.bounds.center,
				collider.bounds.extents * 2);
		}
	}

	public List<GameObject> QueryTargets()
	{
		int targetListLength = attachedColliders.Length * maxTargetAmount;
		var targets = new List<GameObject>(targetListLength);
		foreach(BoxCollider2D collider in attachedColliders)
		{
			collider.OverlapCollider(contactFilter, overlaps);
			foreach(Collider2D overlap in overlaps)
			{
				targets.Add(overlap.gameObject);
			}
		}

		return targets;
	}
}
