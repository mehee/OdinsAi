using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseManager : MonoBehaviour {

	//Insert the guiInteractText witch should apear when on Trigger
	[SerializeField] public GameObject guiInteractText;
	//Show the CanvasObj, if their is one
	[SerializeField] public GameObject lootUI;
	[SerializeField] public GameObject inventoryUI;
	//target to Spawn if necessary
	[SerializeField] private GameObject target;

	// name of the String to switch State in the Animator
	public string transitionParameterName;

	//if an Animation should be activated, Calls his own Animator to trigger it
	private Animator animator;
	//to check if GameObject with Tag Player is on Trigger
	private bool playerIsOnTrigger = false;

	private GameObject player;

	void Awake()
	{
		guiInteractText.SetActive(false);

		if(lootUI != null)
			lootUI.SetActive(false);
		if(inventoryUI != null)
			inventoryUI.SetActive(false);
	}

	void Start()
	{
		animator = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if(playerIsOnTrigger && guiInteractText.activeInHierarchy && Input.GetButtonDown("Use"))
		{
			if(animator != null)
				animator.SetBool(transitionParameterName, true);

			if(lootUI != null)
			{
				//inventory.GetComponent<InventoryUI>().ShowInventory();
				lootUI.SetActive(!lootUI.activeSelf);
			}
			
			if(inventoryUI != null)
				inventoryUI.SetActive(!inventoryUI.activeSelf);

			if(target != null)
				ChangePlayerPosition();
		}
		
	}

	void ChangePlayerPosition()
	{
		player.transform.position = target.transform.position;
	}

	/* Have to rework Hole Chest system/Die system
	If enemy dies,Chest initiated. This has no prefabs set.... DONT KNOW HOW
	public GameObject test;
	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("Entered Collider");
		
		Debug.Log("Test: " + test);
		test.GetComponent<UseManager>().guiInteractText = GameObject.Find("ItemdropPanel");
		Debug.Log("TestAfter: " + test);
		
		
	
	//	guiInteractText = GameObject.Find("Loot_Chest");
	//	lootUI = GameObject.Find("ItemdropPanel");
	//	inventoryUI = GameObject.Find("Inventory");
	}
	 */

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			guiInteractText.SetActive(true);			
			playerIsOnTrigger = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			guiInteractText.SetActive(false);			
			playerIsOnTrigger = false;
			
			if(lootUI != null)
				lootUI.SetActive(false);

			if(inventoryUI != null)
				inventoryUI.SetActive(false);
		}
	}
}
