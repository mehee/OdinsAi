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

	//Can Add 5 Bags
	public bool CanAddBag {get {return bags.Count < 5;} }

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.J))
		{
			Bag bag = (Bag)Instantiate(items[11]);
			bag.Initialize();
			bag.Use();
		}
		if(Input.GetKeyDown(KeyCode.K))
		{
			Bag bag = (Bag)Instantiate(items[11]);
			bag.Initialize();
			AddItem(bag);
		}
		if(Input.GetKeyDown(KeyCode.L))
		{
			HealthPotion potion = (HealthPotion)Instantiate(items[12]);
			AddItem(potion);
		}
		if(Input.GetKeyDown(KeyCode.H))
		{
			AddItem((Armor)Instantiate(items[6]));
			AddItem((Armor)Instantiate(items[7]));
			AddItem((Armor)Instantiate(items[8]));
			AddItem((Armor)Instantiate(items[9]));
			AddItem((Armor)Instantiate(items[10]));
		}

	}
	// -------------

	void Awake()
	{
		Bag bag = (Bag)Instantiate(items[11]);
		bag.Initialize();
		bag.Use();

		//StartItems
		Armor tmp = (Armor)Instantiate(items[0]);
		Armor tmp1 = (Armor)Instantiate(items[1]);
		Armor tmp2 = (Armor)Instantiate(items[2]);
		Armor tmp3 = (Armor)Instantiate(items[3]);
		Armor tmp4 = (Armor)Instantiate(items[4]);
		Armor tmp5 = (Armor)Instantiate(items[5]);

		CharacterMenu.MyInstance.EquipArmor(tmp);
		CharacterMenu.MyInstance.EquipArmor(tmp1);
		CharacterMenu.MyInstance.EquipArmor(tmp2);
		CharacterMenu.MyInstance.EquipArmor(tmp3);
		CharacterMenu.MyInstance.EquipArmor(tmp4);
		CharacterMenu.MyInstance.EquipArmor(tmp5);
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

	///<summary> try to place in Stack. if so do, if not -> PlaceInEmpty()</summary>
	public bool AddItem(Item item)
	{
		if(item.MyStackSize > 0)
		{
			if(PlaceInStack(item))
				return true;
		}
		
		return PlaceInEmpty(item);
	}

	///<summary>running through all slots belonging to this Bag</summary>
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


	///<summary>run through all bags, then all slots and check if the Item is Stackable</summary>
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
