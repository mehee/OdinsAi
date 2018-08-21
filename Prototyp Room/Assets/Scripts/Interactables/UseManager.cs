using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseManager : MonoBehaviour {

	//Insert the guiInteractText witch should apear when on Trigger
	[SerializeField] public GameObject guiInteractText;
	
	//CanvasGroup of lootUI
	[SerializeField] public GameObject lootUI;
	private CanvasGroup lootUICanvasGrp;

	//CanvasGroup of InventoryUI
	[SerializeField] public GameObject inventoryUI;
	private CanvasGroup inventoryCanvasGrp;

	

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
			lootUICanvasGrp = lootUI.GetComponent<CanvasGroup>();
		if(inventoryUI != null)
			inventoryCanvasGrp = inventoryUI.GetComponent<CanvasGroup>();
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
				OpenClose();
			}
			
			if(inventoryUI != null)
				OpenClose();

			if(target != null)
				ChangePlayerPosition();
		}
		
	}

	private void OpenClose()
	{
		inventoryCanvasGrp.alpha = inventoryCanvasGrp.alpha > 0 ? 0:1;
		inventoryCanvasGrp.blocksRaycasts = inventoryCanvasGrp.blocksRaycasts == true ? false : true;
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
