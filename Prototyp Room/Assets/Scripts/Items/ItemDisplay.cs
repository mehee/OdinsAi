using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplay : MonoBehaviour {

	//make an ItemObject with all parameters needed
	public Item itemPrefab;

		void Start()
		{
			Display();
		}
		public void Display()
		{
			foreach (ItemEntry item in ItemManager.im.itemDatabase.items)
			{
				Item newItem = Instantiate(itemPrefab) as Item;
				// newItem.transform.SetParent(transform,false);

				//set Values in Text of Item
				newItem.DisplayValues(item);
			}
		}
}
