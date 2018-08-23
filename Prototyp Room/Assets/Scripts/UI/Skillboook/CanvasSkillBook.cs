using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasSkillBook : MonoBehaviour {

	// Use this for initialization
	public GameObject spellBook;
	void Start () 
	{
		//spellBook = GetComponent<Canvas>();
		spellBook.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		
			if(Input.GetButtonDown("Spellbook"))
			{
			spellBook.gameObject.SetActive(!spellBook.gameObject.activeSelf);
			}
		
	}
	
}
