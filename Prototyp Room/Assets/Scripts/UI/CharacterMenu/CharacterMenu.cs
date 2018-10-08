using
 System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMenu : MonoBehaviour 
{
	private static CharacterMenu instance;

	public static CharacterMenu MyInstance
	{
		get
		{
			if(instance == null)
			{
				instance = GameObject.FindObjectOfType<CharacterMenu>();
			}
			return instance;
		}
	}


	//Reference 
	[SerializeField]
	private CharacterItemSlot head, chest, legs, boots, ring, runeStone, trinket, mainHand, offHand;

	[SerializeField]
	private CanvasGroup characterMenu;
	[SerializeField]
	private Player player;

	//For Reference to the Selected Button if Clicked 
	public CharacterItemSlot MySelectedButton {get;set;}

	//CloseButton use this Methode
	public void OpenClose()
	{
		characterMenu.alpha = characterMenu.alpha > 0 ? 0 : 1;
		characterMenu.blocksRaycasts = characterMenu.blocksRaycasts == true ? false : true;
	}

	///<summary> place Armor on the correct Slot in CharacterMenu</summary>
	public void EquipArmor(Armor armor)
	{
		player.stats.Armor += armor.MyArmor;
		player.stats.Health += armor.MyStamina;
		player.stats.Strength += armor.MyStrength;
		player.stats.Intelligence += armor.MyIntellect;

		switch(armor.MyArmorType)
		{
			case ArmorType.Head:
				head.EquipItem(armor);
				break;
			case ArmorType.Chest:
				chest.EquipItem(armor);
				break;
			case ArmorType.Legs:
				legs.EquipItem(armor);
				break;
			case ArmorType.Boots:
				boots.EquipItem(armor);
				break;
			case ArmorType.Ring:
				ring.EquipItem(armor);
				break;
			case ArmorType.Runestone:
				runeStone.EquipItem(armor);
				break;
			case ArmorType.Trinket:
				trinket.EquipItem(armor);
				break;
			case ArmorType.MainHand:
				mainHand.EquipItem(armor);
				break;
			case ArmorType.Offhand:
				offHand.EquipItem(armor);
				break;
		}
		StatTextScript.MyInstance.UpdateStatsText();
	}
	///<summary> 
	///Just Update the Stats by substracting the Stats of the Item
	///<param name="armor"> Armor get Values for substracting </param> 
	///</summary>
	public void StatsDequipArmor(Armor armor)
	{
		player.stats.Armor -= armor.MyArmor;
		player.stats.Health -= armor.MyStamina;
		player.stats.Strength -= armor.MyStrength;
		player.stats.Intelligence -= armor.MyIntellect;
		StatTextScript.MyInstance.UpdateStatsText();
	}
}
