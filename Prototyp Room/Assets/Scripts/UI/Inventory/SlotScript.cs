﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class SlotScript : MonoBehaviour, IPointerClickHandler, IClickable
{
	//Icon of Slot, changed later with icon of Item
	[SerializeField] 
	private Image icon;

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
		set{ icon = value;}
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
		icon.sprite = item.MyIcon; //set Icon from Item to sprite 
		icon.color = Color.white;
		item.MySlot = this;
		return true;
	}

	public void RemoveItem(Item item)
	{
		if(!IsEmpty)
		{
			items.Pop();
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

	public void OnPointerClick(PointerEventData eventData)
	{
		if(eventData.button == PointerEventData.InputButton.Right)
		{
			UseItem();
		}
	}


}
