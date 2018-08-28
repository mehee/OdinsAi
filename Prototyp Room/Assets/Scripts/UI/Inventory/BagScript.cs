using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagScript : MonoBehaviour 
{
	[SerializeField] 
	private GameObject slotPrefab;
	private CanvasGroup canvasGroup;

	//List of slots
	private List<SlotScript> slots = new List<SlotScript>();

	public bool IsOpen
	{
		get { return canvasGroup.alpha > 0;}
	}

	public List<SlotScript> MySlots
	{
		get { return slots;}
	}
	
	private void Awake()
	{
		canvasGroup = GetComponent<CanvasGroup>();
	}

	public void AddSlots(int slotCount)
	{
		for (int i = 0; i < slotCount; i++)
		{
			SlotScript slot = Instantiate(slotPrefab,transform).GetComponent<SlotScript>();
			//adding all Slots in slot
			slots.Add(slot);
		}
	}

	public bool AddItem(Item item)
	{
		//running through all slots belonging to this Bag
		foreach (SlotScript slot in slots)
		{
			if(slot.IsEmpty)
			{
				slot.AddItem(item);
				return true;
			}
		}
		return false;
	}

	public void OpenClose()
	{
		canvasGroup.alpha = canvasGroup.alpha > 0 ? 0 : 1;
		canvasGroup.blocksRaycasts = canvasGroup.blocksRaycasts == true ? false : true;
	}
}
