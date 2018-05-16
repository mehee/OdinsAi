using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootUI : MonoBehaviour {

	public GameObject lootUI;

	// Use this for initialization
	void Start ()
	{
		lootUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown("LootUI"))
		{
			lootUI.SetActive(!lootUI.activeSelf);
		}
	}

	void UpdateUI ()
	{
		Debug.Log("Updating UI");
	}
}
