using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	[SerializeField] PoolObject prefab;
	[SerializeField] int poolSize;
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
			instance.SetActive(false);
			instances.Add(instance);
		}

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
				return instance;
			}
		}

		return null;
	}

	public void Retrieve(PoolObject poolObject)
	{
		poolObject.SetActive(false);
	}
}