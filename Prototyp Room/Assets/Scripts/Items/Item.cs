using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : ScriptableObject, IMoveable, IDescribable
{
	[SerializeField] private Sprite icon;
	[SerializeField] private Sprite background;
	[SerializeField] private int stackSize;
	private Color backgroundColor;

	[SerializeField] private string titel;
	[SerializeField] private Quality quality;

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

	public string MyTitle
	{
		get{return titel;}
	}


	public void Remove()
	{
		if(MySlot != null)
		{
			MySlot.RemoveItem(this);
		}
	}


	public virtual string GetDescription() //overridable
    {
        return string.Format("<color={0}>{1}</color>", QualityColors.MyColors[quality], titel); // {0} will be replaced with color, {1} with title
    }


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

}
