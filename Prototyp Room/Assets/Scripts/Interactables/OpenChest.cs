using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenChest : MonoBehaviour {

	
	public GameObject guiOpenText;
	public GameObject canvasLootUi;

	private Animator openingAnimation;
	private bool playerIsOnTrigger = false;

	void Awake () 
	{
		guiOpenText.SetActive(false);
		canvasLootUi.SetActive(false);
	}

	void Start()
	{
		openingAnimation = GetComponent<Animator>();

		//should fill itself with the right Object
		//guiOpenText = player.GetComponentInChildrenWithTheStupdName("Loot_Chest");
		//guiOpenText = player.GetComponentInChildren<>();
		//canvasLootUi = player.GetComponentInChildren<GameObject>();
	}

	void Update()
	{
		if(playerIsOnTrigger &&	guiOpenText.activeInHierarchy && Input.GetButtonDown("Use") )
		{
			canvasLootUi.SetActive(!canvasLootUi.activeSelf);
			openingAnimation.SetBool("isOpen",true);
		}

	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			guiOpenText.SetActive(true);			
			playerIsOnTrigger = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			guiOpenText.SetActive(false);			
			canvasLootUi.SetActive(false);
			playerIsOnTrigger = false;
		}
	}
}
