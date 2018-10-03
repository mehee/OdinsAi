using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMenu : MonoBehaviour {

	// ----- SINGLETON

		private static CharacterMenu instance;

		public static CharacterMenu MyInstance
		{
			get
			{
				if(instance == null)
				{
					instance = GameObject.FindObjectOfType<CharacterMenu>();
				}
				return instance;
			}
		}

	// -----

	[SerializeField]
	private CanvasGroup characterMenu;


	
	public void OpenClose()
	{
		characterMenu.alpha = characterMenu.alpha > 0 ? 0 : 1;
		characterMenu.blocksRaycasts = characterMenu.blocksRaycasts == true ? false : true;
	}

}
