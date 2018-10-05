using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSkillBook : MonoBehaviour {

	private static CanvasSkillBook instance;

	public static CanvasSkillBook MyInstance
	{
		get 
		{
			if(instance == null)
			{
				instance = FindObjectOfType<CanvasSkillBook>();
			}
			return instance;
		}	
	}


	// Use this for initialization
	public GameObject spellBook;

	private CanvasGroup canvasGroup;

	void Start()
	{
		canvasGroup = this.GetComponent<CanvasGroup>();
	}

	public void OpenClose()
	{
		canvasGroup.alpha = canvasGroup.alpha > 0 ? 0:1;
		canvasGroup.blocksRaycasts = canvasGroup.blocksRaycasts == true ? false : true;
	}
}
