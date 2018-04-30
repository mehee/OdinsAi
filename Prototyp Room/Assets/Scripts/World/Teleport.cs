using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour 
{
	public GameObject guiObject;
	public GameObject target;

	private GameObject player;
	private bool playerIsOnTrigger = false;

	void Start()
	{
		guiObject.SetActive(false);
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Update()
	{
		if(playerIsOnTrigger && guiObject.activeInHierarchy == true && Input.GetButtonDown("Use") )
		{
			player.transform.position = target.transform.position;
		}
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			guiObject.SetActive(true);			
			playerIsOnTrigger = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			guiObject.SetActive(false);			
			playerIsOnTrigger = false;
		}
	}

}
