
using UnityEngine;

public class InventoryUi : MonoBehaviour {

	public Transform itemsParent;
	public GameObject inventoryUI;

	// Use this for initialization
	void Start () {
		inventoryUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Inventory"))
		{
			inventoryUI.SetActive(!inventoryUI.activeSelf);
		}
	}


}
