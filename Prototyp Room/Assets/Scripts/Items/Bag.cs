using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Bag",menuName = "Items/Bags", order = 1)]
public class Bag : Item, IUseable
{
	//Quality quality;
	private int slots;
	[SerializeField] private GameObject bagPrefab;

	//property
	public BagScript MyBagScript {get; set;}

	public int Slots
	{
		get {return slots;}
	}

	public void Initialize()
	{
		SetBagSize();
	}

	public void Use()
	{
		if(InventoryScript.MyInstance.CanAddBag)
		{
			Remove();
			MyBagScript = Instantiate(bagPrefab,InventoryScript.MyInstance.transform).GetComponent<BagScript>();
			MyBagScript.AddSlots(slots);

			InventoryScript.MyInstance.AddBag(this);
		}
	}

	public void SetBagSize()
	{
		switch (MyQuality)
		{
			case Quality.Common: slots = 12;
				break;
			case Quality.Uncommon: slots = 14;
				break;
			case Quality.Rare: slots = 16;
				break;
			case Quality.Epic: slots = 18;
				break;
			case Quality.Legendary: slots = 20;
				break;
			default: slots = 12;
				break;
		}
	}
}
