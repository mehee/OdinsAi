using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour 
{
	public static SpawnManager instance = null;
	
	//Spawnpoints
	//[HideInInspector] 
	public int currentSpawnPointNumber;
	public GameObject [] spawnPointArray;

	private GameObject player;
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

	}

	void Start ()
	{
		//spawnPointArray = GameObject.FindGameObjectsWithTag("SpawnPoints");
		Debug.Log("spawnPointArray length = " + spawnPointArray.Length);
	}
	
	//Hier ansetzen. OnEnable bzw OnLevelLoaded ... wird nicht ausgeführt.
	void OnEnable()
	{
		spawnPointArray = GameObject.FindGameObjectsWithTag("SpawnPoints");
		Debug.Log("spawnPointArray length Changed = " + spawnPointArray.Length);
		
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
		Debug.Log("current Spawnpoint Number changed to = " + currentSpawnPointNumber);
		
	}

}
