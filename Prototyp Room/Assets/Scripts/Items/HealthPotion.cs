using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthPotion", menuName = "Items/Potion", order = 1)]
public class HealthPotion : Item, IUseable 
{
	//[SerializeField]private int health;

	public void Use()
	{
		/*
		//just usable if player have lost Health
		if(Player.MyInstance.MyHealth.MyCurrentValue < Player.MyInstance.MyHealth.MyMaxValue)
		{
			Remove();
		//	Player.MyInstance.MyHealth.MyCurrentValue += health;
		}
		 */
		
		
		
	}
}
