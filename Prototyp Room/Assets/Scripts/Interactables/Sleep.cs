using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour {

	public GameObject guiOpenText;

	[SerializeField] private string triggerName;
	[SerializeField] private Animator transitionAnimator;

	//helpers
	private bool isOnTrigger = false;

	void Awake()
	{
		guiOpenText.SetActive(false);
	}

	void Update () 
	{
		if(isOnTrigger && guiOpenText.activeInHierarchy == true && Input.GetButtonDown("Use"))
		{
			StartSleeping();
		}
	}

	void StartSleeping()
	{
		transitionAnimator.SetTrigger(triggerName);
		//it can only used every second time. have to reset it 
		
		//stop Moving
		
		//healing
		
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			isOnTrigger = true;
			guiOpenText.SetActive(true);
		}

	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			isOnTrigger = false;
			guiOpenText.SetActive(false);
		}
	}
}
