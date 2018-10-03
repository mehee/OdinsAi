﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI_old : MonoBehaviour {

	private static InventoryUI_old instance;
	public static InventoryUI_old MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InventoryUI_old>();
            }

            return instance;
        }
    }

	public GameObject inventory;
	private Image ReceivedItem;
	private Image[] invContent = new Image[60];
	private int slotCounter = 0;
	private Image[] allImages;
	private Image[] itemImages = new Image[60];
	private int fieldcount = 0;

	[SerializeField]
	private GameObject tooltip;

	// Use this for initialization
	void Start ()
	{
		inventory.SetActive(false);
		allImages = GetComponentsInChildren<Image>();
		foreach(Image tmp in allImages)
		{
			if(tmp.tag == "invItem")
			{
				itemImages[fieldcount] = tmp;
				fieldcount++;
			}
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown("Inventory"))
		{
			ShowInventory();
		}
	}

	public void AddItem(Image item)
	{
		ReceivedItem = item;
		if(slotCounter < 60)
		{
			invContent[slotCounter] = ReceivedItem;
			Debug.Log("added " + ReceivedItem + " to Slot " + slotCounter);
			slotCounter++;
			return;
		}
		else Debug.Log("Inventar voll");
	}
	public void ShowInventory()
	{
		inventory.SetActive(!inventory.activeSelf);
		DisplayItems();
	}

	void DisplayItems()
	{
		// Show ITEMS 
	}

	public void ShowTooltip(Vector3 position)
	{
		tooltip.SetActive(true);
		tooltip.transform.position = position;
	}
	public void HideTooltip()
	{
		tooltip.SetActive(false);
	}
}