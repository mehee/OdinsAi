using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Quality {Common, Uncommon, Rare, Epic, Legendary}

public abstract class Item : ScriptableObject, IMoveable
{
	[SerializeField] private Sprite icon;
	[SerializeField] private Sprite background;
	[SerializeField] private int stackSize;
	private Color backgroundColor;

	[SerializeField] private Quality quality;
	[SerializeField] private string titel;

	//reference to Slot
	private SlotScript slot;

	public Sprite MyIcon
	{
		get {return icon;}
		set {icon = value;}
	}
	
	public Sprite MyBackground
	{
		get {return background;}
		set {background = value;}
	}

	public Color MyBackgroundColor
	{
		get {return backgroundColor;}
	}

	public int MyStackSize
	{
		get {return stackSize;}
	}

	public SlotScript MySlot
	{
		get {return slot;}
		set {slot = value;}
	}

	public Quality MyQuality
	{
		get {return quality;}
	}


	public void Remove()
	{
		if(MySlot != null)
		{
			MySlot.RemoveItem(this);
		}
	}

/*
	public virtual string GetDescription()
    {
        string color = string.Empty;

        switch (quality)
        {
            case Quality.Common:
                color = "#d6d6d6";
                break;
            case Quality.Uncommon:
                color = "#00ff00ff";
                break;
            case Quality.Rare:
                color = "#0000ffff";
                break;
            case Quality.Epic:
                color = "#800080ff";
                break;
        }

        return string.Format("<color={0}>{1}</color>", color, titel);
    }
 */

	public Color getColor()
	{
		switch (quality)
		{
			case Quality.Common: 
				backgroundColor = new Color(1,1,1,1); // white
				break;
			case Quality.Uncommon: 
				backgroundColor = new Color(0.0f,1.0f,0.0f); // green
				break;
			case Quality.Rare: 
				backgroundColor = new Color(0.0f,0.0f,1.0f); // blue
				break;
			case Quality.Epic: 
				backgroundColor = new Color(0.517f, 0.0f, 0.658f); // violet
				break;
			case Quality.Legendary: 
				backgroundColor = new Color(0.878f, 0.529f, 0.0f, 1.0f); //gold
				break;
		}
		return backgroundColor;
	}

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
