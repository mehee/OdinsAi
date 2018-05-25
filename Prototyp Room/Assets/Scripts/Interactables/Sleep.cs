using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour {

	public GameObject guiOpenText;
	public GameObject spawnPoint;

	[SerializeField] private string triggerName;
	[SerializeField] private Animator transitionAnimator;
	private GameObject player;

	//helpers
	private bool isOnTrigger = false;

	void Awake()
	{
		guiOpenText.SetActive(false);
		player = GameObject.FindGameObjectWithTag("Player");
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
		// finish this
		transitionAnimator.SetTrigger(triggerName);
		//it can only be used every second time. have to reset it 
		
		//stop Moving
		StartCoroutine(resetPosition());
		//healing wounds and replanish Ressources
		player.GetComponent<Health>().Reset();
		player.GetComponent<Wrath>().Reset(); // should be called Ressource not Wrath
	}

	IEnumerator resetPosition()
	{
		yield return new WaitForSeconds(5.0f);
		player.transform.position = spawnPoint.transform.position;

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
