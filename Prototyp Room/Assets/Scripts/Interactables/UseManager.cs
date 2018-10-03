using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UseManager : MonoBehaviour {

	//Insert the guiInteractText witch should apear when on Trigger
	[SerializeField] public GameObject guiInteractText;
	
	//target to Spawn if necessary
	[SerializeField] private GameObject target;

	//Loottable for the Object. is now bind on the Chest not the enemy, thats not good
	[SerializeField] private LootTable lootTable;

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
			//start the animation of the chest
			if(animator != null)
			{
				animator.SetBool(transitionParameterName, true);
			}
			
			lootTable.ShowLoot();

			//switch position with enemy 
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
		}
	}
}
