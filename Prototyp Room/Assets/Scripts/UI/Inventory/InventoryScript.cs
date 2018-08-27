using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour 
{

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

	[SerializeField]
	private BagButton[] bagButtons;

	private List<Bag> bags = new List<Bag>(); // List of all Bags in Inventory

	//just for debugging
	[SerializeField]
	private Item[] items;

	public bool CanAddBag {get {return bags.Count < 5;} }

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.J))
		{
			Bag bag = (Bag)Instantiate(items[0]);
			bag.Initialize(20);
			bag.Use();
		}
		if(Input.GetKeyDown(KeyCode.K))
		{
			Bag bag = (Bag)Instantiate(items[0]);
			bag.Initialize(20);
			AddItem(bag);
		}

	}

	void Awake()
	{
		Bag bag = (Bag)Instantiate(items[0]);
		bag.Initialize(20);
		bag.Use();
	}

	public void AddBag(Bag bag)
	{
		foreach (BagButton bagButton in bagButtons)
		{
			if(bagButton.MyBag == null)
			{
				bagButton.MyBag = bag;
				bags.Add(bag);
				break;
			}
		}
	}

	
	public void AddItem(Item item)
	{
		//running through all slots belonging to this Bag
		foreach (Bag bag in bags)
		{
			if(bag.MyBagScript.AddItem(item))
			{
				return;
			}
		}
	}

	public void OpenClose()
	{
		bool closedBag = bags.Find(x => !x.MyBagScript.IsOpen);
		//if closed bag == true, then open all closed bags
		//if closed bag == flase, then close all open bags

		foreach (Bag bag in bags)
		{
			if(bag.MyBagScript.IsOpen != closedBag)
			{
				bag.MyBagScript.OpenClose();
			}
		}
	}

}
