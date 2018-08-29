using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotBackground : MonoBehaviour
{
	private Image background;

	public void Update()
	{
		setColor();
	}

	public void setColor()
	{
		switch (Item)
		{	
			case Quality.Common:

                break;
            case Quality.Uncommon:
                color = "#00ff00ff";
                break;
            case Quality.Rare:
                color = "#0000ffff";
                break;
            case Quality.Legendary:
                color = "#800080ff";
                break;
		
		}
	}





}
