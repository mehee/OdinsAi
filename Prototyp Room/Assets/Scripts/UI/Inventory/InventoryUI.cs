using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

	public GameObject inventory;

	// Use this for initialization
	void Start ()
	{
		inventory.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown("Inventory"))
		{
			inventory.SetActive(!inventory.activeSelf);
		}
	}

	void UpdateUI ()
	{
		Debug.Log("Updating UI");
	}
}
