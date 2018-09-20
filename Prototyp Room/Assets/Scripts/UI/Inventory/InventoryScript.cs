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
	private SlotScript fromSlot;

	public SlotScript FromSlot
    {
        get { return fromSlot;}

        set
        {
            fromSlot = value;

            if (value != null)
            {
                fromSlot.MyIcon.color = Color.grey;
            }
        }
    }

	// --------- just for debugging
	[SerializeField]
	private Item[] items;

	public bool CanAddBag {get {return bags.Count < 5;} }

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.J))
		{
			Bag bag = (Bag)Instantiate(items[0]);
			bag.Initialize();
			bag.Use();
		}
		if(Input.GetKeyDown(KeyCode.K))
		{
			Bag bag = (Bag)Instantiate(items[0]);
			bag.Initialize();
			AddItem(bag);
		}
		if(Input.GetKeyDown(KeyCode.L))
		{
			HealthPotion potion = (HealthPotion)Instantiate(items[1]);
			AddItem(potion);
		}
		if(Input.GetKeyDown(KeyCode.H))
		{
			AddItem((Armor)Instantiate(items[2]));
			AddItem((Armor)Instantiate(items[3]));
			AddItem((Armor)Instantiate(items[4]));
			AddItem((Weapon)Instantiate(items[5]));
		}

	}
	// -------------

	void Awake()
	{
		Bag bag = (Bag)Instantiate(items[0]);
		bag.Initialize();
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

	
	public bool AddItem(Item item)
	{
		// try to place in Stack. if so do, if not -> PlaceInEmpty()
		if(item.MyStackSize > 0)
		{
			if(PlaceInStack(item))
				return true;
		}
		
		return PlaceInEmpty(item);
	}

	//running through all slots belonging to this Bag
	private bool PlaceInEmpty(Item item)
	{
		foreach (Bag bag in bags)
		{
			if(bag.MyBagScript.AddItem(item))
				return true;
		}
		//Inventory is full
		return false;
	}


	//run through all bags, then all slots and check if the Item is Stackable
	private bool PlaceInStack(Item item)
	{
		foreach (Bag bag in bags) 
		{
			foreach (SlotScript slots in bag.MyBagScript.MySlots)
			{
				if(slots.StackItem(item))
					return true;
			}
		}

		return false;
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
