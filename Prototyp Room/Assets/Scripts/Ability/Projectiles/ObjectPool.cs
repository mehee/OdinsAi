using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	[SerializeField] PoolObject prefab;
	[SerializeField] int poolSize;
	int remainingPoolObjects;
	List<PoolObject> instances = new List<PoolObject>();
	int indexToDispatchFrom;

	public IList<PoolObject> Instances
	{
		get
		{
			return instances.AsReadOnly();
		}
	}
	void Start()
	{
		for(int i = 0; i < poolSize; i++)
		{	
			var instance = Instantiate(prefab);
			instance.owner = this;
			instances.Add(instance);
		}

		remainingPoolObjects = poolSize;

		if(instances.Count != poolSize)
			Debug.LogError("Amount of instances does not match pool size.");
	}

	/** Activates an available PoolObject and
		gives back a reference to it. Careful: Returns
		null if no objects are available. */
	public PoolObject Dispatch()
	{
		foreach(PoolObject instance in instances)
		{
			if(!instance.isActiveAndEnabled)
			{
				instance.SetActive(true);
				remainingPoolObjects--;
				return instance;
			}
		}
		return null;
	}

	/** Returns a pool object back to the pool. */
	public void Retrieve(PoolObject poolObject)
	{
		poolObject.SetActive(false);
		remainingPoolObjects++;
	}

	public bool IsEmpty()
	{
		if(remainingPoolObjects == 0)
		{
			return true;
		}

		return false;
	}
}