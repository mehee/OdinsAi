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

	private List<Bag> bags = new List<Bag>();

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

}
