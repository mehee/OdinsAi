using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// ----- SINGLETON
		private static MainMenu instance;

		public static MainMenu MyInstance
		{
			get
			{
				if(instance == null)
				{
					instance = GameObject.FindObjectOfType<MainMenu>();
				}
				return instance;
			}
		}
	// -----

	[SerializeField]
	private GameObject menu;

	public void PlayGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // SceneQueue aktuelle Position (Menü) + 1 = Game
	}

	public void ExitGame()
	{
		Debug.Log("EXIT PRESSED");
		Application.Quit();
	}

	public void CloseMenu()
	{
		this.GetComponent<CanvasGroup>().alpha = 0.0f;
		this.GetComponent<CanvasGroup>().blocksRaycasts = false;
	}
	
}
