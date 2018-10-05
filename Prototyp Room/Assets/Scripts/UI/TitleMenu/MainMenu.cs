using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // SceneQueue aktuelle Position (Menü) + 1 = Game
	}

	public void ExitGame()
	{
		Debug.Log("EXIT PRESSED");
		Application.Quit();
	}
	
}
