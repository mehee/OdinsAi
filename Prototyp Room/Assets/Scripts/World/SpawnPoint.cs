using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {
	
	public int spawnPointNumber;

	void OnTriggerStay2D()
	{
		if(Input.GetButtonDown("Use"))
		{	
			Debug.Log("SpawnPoint Class called. spawnPointNumber= " + spawnPointNumber);
		//	SceneManagerScript.instance.LoadScene(spawnPointNumber);
		}
	}
	 
	
}
