using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour 
{
	public GameObject guiObject;
	public GameObject target;
	public Animator transitionAnim;

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
			transitionAnim.SetTrigger("enter");
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
