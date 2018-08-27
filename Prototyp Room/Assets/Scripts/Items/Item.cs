using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : ScriptableObject
{
	[SerializeField] private Sprite icon;
	[SerializeField] private int stackSize;

	//reference to Slot
	private SlotScript slot;


	public Sprite MyIcon
	{
		get{return icon;}
	}
	
	public int StackSize
	{
		get{return stackSize;}
	}

	public SlotScript MySlot
	{
		get {return slot;}
		set {slot = value;}
	}

	public void Remove()
	{
		if(MySlot != null)
		{
			MySlot.RemoveItem(this);
		}
	}


	/*FINISH ME FIRST 
	MyIcons gemacht werden und Reference dazu
	und Slots etc
	 */
	/* OLD eventuell DELETE

	public Text name, quality, type, strength, intelligence, vitality;

	//displays the Values in the ItemCanvas
	public void DisplayValues(ItemEntry item)
	{
		name.text = item.name;
		quality.text = item.quality.ToString();
		type.text = item.type.ToString();
		strength.text = "Strength:\t" + item.strength.ToString();
		intelligence.text = "Intelligence:\t" + item.intelligence.ToString();
	
		vitality.text = "Vitality:\t" + item.vitality.ToString();

		switch (item.quality)
		{	
			case ItemQuality.Uncommon: 
				quality.color = new Color(1.0f,0.0f,0.0f); // green
				break;
			case ItemQuality.Rare: 
				quality.color = new Color(0.0f,0.0f,1.0f); // blue
				break;
			case ItemQuality.Epic: 
				quality.color = new Color(0.517f, 0.0f, 0.658f); // violet
				break;
			case ItemQuality.Legendary: 
				quality.color = new Color(0.878f, 0.529f, 0.0f); //gold
				break;
			default:
				quality.color = quality.color; // white
				break;		
		}
 
	}

	public string GetDescription()
	{
		return "Im an Item";
	}

 	*/

}
