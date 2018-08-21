using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenuScript : MonoBehaviour {

	private CanvasGroup canvasGroup;

	void Awake () {
		canvasGroup = GetComponent<CanvasGroup>();
	}

	private void OpenClose()
	{
		canvasGroup.alpha = canvasGroup.alpha > 0 ? 0:1;
		canvasGroup.blocksRaycasts = canvasGroup.blocksRaycasts == true ? false : true;
	}

	void Update()
	{
		if(Input.GetButtonDown("Inventory"))
		{
			OpenClose();
		}
	}

}
