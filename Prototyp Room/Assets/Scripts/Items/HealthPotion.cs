using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthPotion", menuName = "Items/Potion", order = 1)]
public class HealthPotion : Item, IUseable 
{
	[SerializeField]
	private int health;

	public void Use()
	{
		//just usable if player have lost Health
		if(Player.MyInstance.MyHealth.MyCurrentValue < Player.MyInstance.MyHealth.MyMaxValue)
		{
			Remove();
			Player.MyInstance.MyHealth.MyCurrentValue += health;
		}
			
	}

	public override string GetDescription()
	{
		//base gets the Titel in color
		return base.GetDescription() + string.Format("\nUse: Restores <color=#00ff00ff>{0}</color> health", health); 
	}
}
