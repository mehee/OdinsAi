using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour {

	//public GameObject guiObject;
	public static SceneManagerScript Instance = null;
	public int currentSpawnPointNumber;
	public GameObject [] spawnPointArray;
//public string sceneToLoad;

	private GameObject player;
	///private bool playerIsOnTrigger = false;
	
	void Awake () 
	{
		if(Instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}

		if(player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player");
		}	

		if(spawnPointArray.Length == 0)
		{
			spawnPointArray = GameObject.FindGameObjectsWithTag("SpawnPoints");
		}
	}

	void Start()
	{
			
	}

	/*
	void Update(int spawnPointNumber)
	{
		if(playerIsOnTrigger && guiObject.activeInHierarchy == true && Input.GetButtonDown("Use") )
		{
			SceneManager.LoadScene(sceneToLoad);
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
	 */


	void OnLevelWasLoaded()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		spawnPointArray = GameObject.FindGameObjectsWithTag("SpawnPoints");

		//Change here for working with Gameobjekts, not integer
		for (int i = 0; i < spawnPointArray.Length; i++)
		{
			if(spawnPointArray[i].GetComponent<SpawnPoint>().spawnPointNumber == currentSpawnPointNumber)
			{
				player.transform.position = spawnPointArray[i].transform.position;
			}
		}
	}

	
	public void LoadScene(int spawnPointNumber)
	{
		currentSpawnPointNumber = spawnPointNumber;

	/*
		if(playerIsOnTrigger && guiObject.activeInHierarchy == true) // && Input.GetButtonDown("Use") 
		{
			SceneManager.LoadScene(sceneToLoad);
		}
	 */
		
		if(Application.loadedLevel == 0)
		{
			SceneManager.LoadScene(1);
		}
		else if(Application.loadedLevel == 1)
		{
			SceneManager.LoadScene(0);
		}
		
	}
	 
}
