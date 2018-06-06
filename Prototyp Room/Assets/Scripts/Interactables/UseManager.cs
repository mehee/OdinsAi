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
				lootUI.SetActive(!lootUI.activeSelf);
			
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
