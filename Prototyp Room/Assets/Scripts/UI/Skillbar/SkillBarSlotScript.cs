﻿using UnityEngine;
using UnityEngine.UI;
using AbilitySystem;
using UnityEngine.EventSystems;

public enum WhichSlot{slot1, slot2, slot3, slot4,slot5}
public class SkillBarSlotScript : MonoBehaviour//, IPointerEnterHandler, IPointerExitHandler
{
	// Use this for initialization
	private Image icon;

	public WhichSlot slot;
	[SerializeField]
	protected Player player;

	protected AbilityKit abilityKit;

    void Start () 
	{
		icon = GetComponent<Image>();
		abilityKit = player.GetComponent<AbilityKit>();
		UpdateSlots();
	}

	void Update()
	{
		//Besser nur bei Skillung
		UpdateSlots();
	}

	public void UpdateSlots()
	{
		switch (slot)
		{
			case WhichSlot.slot1:
				icon.sprite = abilityKit.MyAbilities[0].icon;
				break;
			case WhichSlot.slot2:
				icon.sprite = abilityKit.MyAbilities[1].icon;
				break;
			case WhichSlot.slot3:
				icon.sprite = abilityKit.MyAbilities[2].icon;
				break;
			case WhichSlot.slot4:
				icon.sprite = abilityKit.MyAbilities[3].icon;
				break;
				case WhichSlot.slot5:
				icon.sprite = abilityKit.MyAbilities[4].icon;
				break;
		}	
	}
	
}