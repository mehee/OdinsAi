using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
	
public class Interactable : MonoBehaviour, IPointerClickHandler
{	
	private GameObject pressedSlot;
	private Image[] pressedSlotImages;
	private Image selectedItem;
	private InventoryUI inventoryScript;
	void Start()
	{
		inventoryScript = GameObject.FindObjectOfType(typeof(InventoryUI)) as InventoryUI;
	}
	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right)
		{
			pressedSlot = eventData.pointerPress;
			SendToInventory();
			Destroy(selectedItem);
		//	Debug.Log(selectedItem);
		//	selectedItem.fillAmount = 0f;
		//	Debug.Log(slotUsage[6]);
		}
	}
	private void SendToInventory()
	{
		pressedSlotImages = pressedSlot.GetComponentsInChildren<Image>();
		foreach (Image tmp in pressedSlotImages)
		{
			if (tmp.name == "Item")
			{
				selectedItem = tmp;
			}
		}
		if(selectedItem != null)
		{
			inventoryScript.AddItem(selectedItem);
		}
		else Debug.Log("Clicked slot is empty");
	}
}
