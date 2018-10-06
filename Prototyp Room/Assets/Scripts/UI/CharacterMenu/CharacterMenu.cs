using
 System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMenu : MonoBehaviour 
{
	// ----- SINGLETON
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
	// -----

	//Reference 
	[SerializeField]
	private CharacterItemSlot head, chest, legs, boots, ring, runeStone, trinket, mainHand, offHand;

	[SerializeField]
	private CanvasGroup characterMenu;
	[SerializeField]
	private Player player;

	private CharacterItemSlot[] equipedItems;

	//private List<CharacterItemSlot> eItems = new List<CharacterItemSlot>();

	//For Reference to the Selected Button if Clicked 
	public CharacterItemSlot MySelectedButton {get;set;}

	//CloseButton use this Methode
	public void OpenClose()
	{
		characterMenu.alpha = characterMenu.alpha > 0 ? 0 : 1;
		characterMenu.blocksRaycasts = characterMenu.blocksRaycasts == true ? false : true;
	}


	//Set the Stats correct
	public void RefreshStats()
	{	
		equipedItems = new[] {head, chest, legs, boots, ring, runeStone, trinket, mainHand, offHand};
        // Debug.Log(head.MyEquipedArmor.MyArmor);

        //Go Through Array of equiped Items and get the Amount of Stats
        foreach (CharacterItemSlot item in equipedItems)
		{
            if (item != null)
 			{
				Debug.Log(item.MyEquipedArmor.MyArmor);
			}
			else
			{
				Debug.LogError("FELD IST LEER");
			}
		}
	}

	///<summary> place Armor on the correct Slot in CharacterMenu</summary>
	public void EquipArmor(Armor armor)
	{
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
	}
}
