using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

	[SerializeField]
	private ArmorType armorType;

	private Armor equipedArmor;

	[SerializeField]
	private Image icon;
	[SerializeField]
	private Image backGround;
	[SerializeField]
	private Player player;

	public Armor MyEquipedArmor
	{
		get{return equipedArmor;}
	}

	// ---- Equip and Dequip items 
	/**Equiping Item to CharacterItemSlot. Remove it from BagSlot */
	public void EquipItem(Armor armor)
	{
		//remove it from BagSlot
		armor.Remove();

		//if their is allready an item on the slot we have to swap
		if(equipedArmor != null)
		{
			if(equipedArmor != armor)
			{
				armor.MySlot.AddItem(equipedArmor);
			}
			UIManager.MyInstance.RefreshTooltip(equipedArmor);
		}
		else 
		{
			UIManager.MyInstance.HideTooltip();
		}
	
		icon.enabled = true;
		icon.sprite = armor.MyIcon;
		this.equipedArmor = armor;
		//Background Enablen with Quality
		backGround.sprite = armor.MyBackground;
		backGround.color = armor.getColor();

		CharacterMenu.MyInstance.RefreshStats();
	}

	/**Dequiping Item from CharacterItemSlot to BagSlot */
	public void DequipItem(Armor armor)
	{
		icon.color = Color.white;
		icon.enabled = false;
		//Set Background to origin....
		backGround.enabled = false;
		backGround.color = Color.white;

		//Dequip in emptySlot
		InventoryScript.MyInstance.AddItem(armor);
		equipedArmor = null;
	}
	//DELETE ME LATER
	//Refresh Stats
	private void RefreshStats(Armor armor)
	{
		player.stats.Armor += armor.MyArmor;
		player.stats.Health += armor.MyStamina;
		player.stats.Strength += armor.MyStrength;
		player.stats.Intelligence += armor.MyIntellect;
		
		if(equipedArmor != null && equipedArmor != armor)
		{
			//Swap and refresh armor Minus Old. + NewArmor
			player.stats.Armor -= equipedArmor.MyArmor;
			player.stats.Health -= equipedArmor.MyStamina;
			player.stats.Strength -= equipedArmor.MyStrength;
			player.stats.Intelligence -= equipedArmor.MyIntellect;
		}
	}

	// -------- Click Handlers

	//Click on Item in Slots To place them in Character Menu Slots
	public void OnPointerClick(PointerEventData eventData)
	{
		//Dequip Item on Rightclick
		if(eventData.button == PointerEventData.InputButton.Right)
		{
			if(equipedArmor != null)
			{
				CharacterMenu.MyInstance.MySelectedButton = this; //reference to the item clicked
				DequipItem(equipedArmor);
			}
		}
	}
	 
	// ------ Tooltip stuff
	// if mouse is over the Item SHOW tooltip and HIDE Tooltip
	public void OnPointerEnter(PointerEventData eventData)
	{
		if(equipedArmor != null)
		{
			UIManager.MyInstance.ShowTooltip(transform.position, equipedArmor);
		}
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		UIManager.MyInstance.HideTooltip();
	}
}
