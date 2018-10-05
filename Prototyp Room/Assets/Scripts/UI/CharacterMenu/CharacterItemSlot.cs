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

	// ---- Equip and Dequip items 
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

		//clear item on hand
		// HandScript.MyInstance.DeleteItem();
	}

	public void DequipItem(Armor armor)
	{
		icon.color = Color.white;
		icon.enabled = false;

		// have to add Item to an empty SlotScript.AddItem(armor);

		equipedArmor = null;
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
