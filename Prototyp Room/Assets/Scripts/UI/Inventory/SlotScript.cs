using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SlotScript : MonoBehaviour, IPointerClickHandler, IClickable, IPointerEnterHandler, IPointerExitHandler
{
	//Icon of Slot, changed later with icon of Item
	[SerializeField] 
	private Image icon;
	[SerializeField]
	private Image background;

	//Stack of items on Slot - own generic class ObserverableStack
	private ObservableStack<Item> items = new ObservableStack<Item>();

	//StackSize text if stackable Item
	[SerializeField]
	private Text stackSize;

	// -------- Properties for Getter and setter
	public bool IsEmpty
	{
		get {return items.Count == 0;}
	}

	public Item MyItem
	{
		get 
		{
			if(!IsEmpty)
			{
				return items.Peek(); // Peek return Item on Top of Stack
			}
			return null;
		}
	}

	public Image MyIcon
	{
		get {return icon;} 
		set {icon = value;}
	}

	public Image MyBackground
	{
		get {return icon;} 
		set {icon = value;}
	}

	public int MyCount
	{
		get{return items.Count;}
	}

	public Text MyStackText
	{
		get {return stackSize;} 
	}


	// --------- Unity Std

	private void Awake()
	{
		//everytime we call push, pop, clear, we call UpdateSlot
		items.OnPop += new UpdateStackEvent(UpdateSlot);
		items.OnPush += new UpdateStackEvent(UpdateSlot);
		items.OnClear += new UpdateStackEvent(UpdateSlot);

		
	}

	// --------- Funktions for Slots
	public bool AddItem(Item item)
	{
		items.Push(item);
		//set Icon from Item to sprite
		icon.sprite = item.MyIcon;  
		icon.color = Color.white;
		//set Background from Item to sprite
		background.sprite = item.MyBackground;
		background.color = item.getColor();

		item.MySlot = this;
		return true;
	}

	public void RemoveItem(Item item)
	{
		if(!IsEmpty)
		{
			items.Pop();
			background.color = new Color(0,0,0,0); // keine sinnvolle Lösung. der Background sollte EIGENTLICH mit dem Item wieder popen
		}
	}

	public void Clear()
    {
        if (items.Count > 0)
        {
            //InventoryScript.MyInstance.OnItemCountChanged(items.Pop());
            items.Clear();
        }
    }

	public void UseItem()
	{
		if(MyItem is IUseable)
		{
			(MyItem as IUseable).Use();
		}
	}

	public bool StackItem(Item item)
	{
		//if their is an item, with the same name and the amount is less then the stackSize
		if(!IsEmpty && item.name == MyItem.name && items.Count < MyItem.MyStackSize)
		{
			items.Push(item);
			item.MySlot = this;
			return true;
		}
		return false;
	}

	private void UpdateSlot()
	{
		UIManager.MyInstance.UpdateStackSize(this);
	}

	//what happen if the slot is clicked
	public void OnPointerClick(PointerEventData eventData)
	{
		//left mouse button
		if(eventData.button == PointerEventData.InputButton.Left)
		{
			//Pickup an IMoveable
			Debug.Log("Moveable clicked");
			HandScript.MyInstance.TakeMoveable(MyItem as IMoveable);
		}
		//right mouse button
		if(eventData.button == PointerEventData.InputButton.Right)
		{
			Debug.Log("Use Potion clicked");
			UseItem();
		}
	}

	//----- Tooltips

	public void OnPointerEnter(PointerEventData eventData)
	{
		if(!IsEmpty)
		{
			UIManager.MyInstance.ShowTooltip(transform.position, MyItem);
		}
		
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		UIManager.MyInstance.HideTooltip();
	}


}
