using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour 
{
	public GameObject guiObject;
	public string levelToLoad;
	private bool playerIsOnTrigger = false;

	void Start()
	{
	//	guiObject.SetActive(false);
	}

	void Update()
	{
		if(playerIsOnTrigger && guiObject.activeInHierarchy == true && Input.GetButtonDown("Use") )
		{
			SceneManager.LoadScene(levelToLoad);
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
