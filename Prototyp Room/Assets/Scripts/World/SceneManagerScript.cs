using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour 
{
	public static SceneManagerScript instance = null;
	public GameObject guiObject;
	//Index of the Scene to Load from Buildsettings
	public int sceneToLoadIndex;
	
	//Spawnpoints
	public int currentSpawnPointNumber;
	public GameObject [] spawnPointArray;

		
	private Scene sceneToLoad;
	private GameObject player;
	//checking if Player is on ColliderTrigger
	private bool playerIsOnTrigger = false;
	//checking if scene allready existes
	private bool sceneLoaded = false;

	void Awake()
	{
		if(instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			DontDestroyOnLoad(gameObject);
			instance = this;
		}
		
		if(player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player");
		}
	}

	void Start()
	{
		if(guiObject != null)
		{
			guiObject.SetActive(false);
		}
	}

	public void Update()
	{	
		if(playerIsOnTrigger && guiObject.activeInHierarchy == true && Input.GetButtonDown("Use"))
		{	
			//HAVE TO REWORK THIS. can start the same scene over and over, without running ChangeScene() methode again.
			/*
			sceneLoaded = true;
			Debug.Log(sceneLoaded);	
		 	*/
			StartCoroutine(ChangeScene());
		}
	}

	IEnumerator ChangeScene()
	{
		SceneManager.LoadScene(sceneToLoadIndex, LoadSceneMode.Additive);
		sceneToLoad = SceneManager.GetSceneByBuildIndex(sceneToLoadIndex);
		//move PlayerObj to new Scene
		SceneManager.MoveGameObjectToScene(player,sceneToLoad);
				
		yield return null;	
			
		SceneManager.UnloadSceneAsync(sceneToLoadIndex -1);
		guiObject.SetActive(false);	
	}

	
	void OnLevelWasLoaded()
	{
		spawnPointArray = GameObject.FindGameObjectsWithTag("SpawnPoints");
		
		for (int i = 0; i < spawnPointArray.Length; i++)
		{
			if(spawnPointArray[i].GetComponent<SpawnPoint>().spawnPointNumber == currentSpawnPointNumber)
			{
				player.transform.position = spawnPointArray[i].transform.position;
			}
		}
	}

	// Triggers
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
	// END: Triggers
}
