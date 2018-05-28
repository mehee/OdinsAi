using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {

	public GameObject guiOpenText;
	//Change Position
	public GameObject target;

	//fading Animation
	[SerializeField] private Animator transitionAnimator;
	//sprite Opening Animation
	private Animator openingAnimation;

	private GameObject player;

	//helpers
	private bool isOnTrigger = false;

	void Awake()
	{
		guiOpenText.SetActive(false);
	}

	void Start () 
	{
		openingAnimation = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");		
	}
	
	void Update () 
	{
		if(isOnTrigger && guiOpenText.activeInHierarchy == true && Input.GetButtonDown("Use"))
		{
			openingAnimation.SetBool("isOpen",true);
			StartCoroutine(EnterHouse());
		}
	}

	IEnumerator EnterHouse()
	{
		//fading start
		yield return new WaitForSeconds(1.0f);
		transitionAnimator.SetTrigger("enterHouse");
		openingAnimation.SetBool("isOpen",false);
		//switch pos
		yield return new WaitForSeconds(1.0f);
		ChangePlayerPosition();
	}

	void ChangePlayerPosition()
	{
		player.transform.position = target.transform.position;
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
