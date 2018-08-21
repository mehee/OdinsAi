using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Inheriting from this class enables it
	to be pooled by an ObjectPool. */
public class PoolObject : MonoBehaviour
{
	public ObjectPool owner;

	public void SetActive(bool active)
	{
		gameObject.SetActive(active);
	}
}
