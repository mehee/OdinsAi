using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterItemSlot : MonoBehaviour, IPointerClickHandler
{

	[SerializeField]
	private ArmorType armorType;

	private Armor armor;

	[SerializeField]
	private Image icon;

	public void OnPointerClick(PointerEventData eventData)
	{
		if(eventData.button == PointerEventData.InputButton.Right)
		{
			//Get the Item underneath the Mouse
			Armor tmp = (Armor) HandScript.MyInstance.MyMoveable;

			if(tmp.MyArmorType == this.armorType)
			{
				EquipItem(tmp);
			}
			// if(HandScript.MyInstance.MyMoveable is Armor)
			// {
			// }
		}
	}

	public void EquipItem(Armor armor)
	{
		icon.enabled = true;
		icon.sprite = armor.MyIcon;
		this.armor = armor;

		//clear item on hand
		HandScript.MyInstance.DeleteItem();
	}
}
