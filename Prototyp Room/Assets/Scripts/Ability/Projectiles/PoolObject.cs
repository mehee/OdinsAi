using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Inheriting from this class enables it
	to be pooled by an ObjectPool. */
public class PoolObject : MonoBehaviour
{	
	// The object pool containing this object.
	public ObjectPool owner;

	/** Set to false to deactivate the game object
		this component is attached to. */
	public void SetActive(bool active)
	{
		gameObject.SetActive(active);
	}
}
