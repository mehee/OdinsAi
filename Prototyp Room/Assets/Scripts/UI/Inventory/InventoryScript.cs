using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour {


	private static InventoryScript instance;

	public static InventoryScript MyInstance
	{
		get 
		{
			if(instance == null)
			{
				instance = FindObjectOfType<InventoryScript>();
			}
			return instance;
		}	
	}

	//just for debugging
	[SerializeField]
	private Item[] items;

	void Awake()
	{
		Bag bag = (Bag)Instantiate(items[0]);
		bag.Initialize(60);
		bag.Use();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
