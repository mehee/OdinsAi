using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour {

	// Use this for initialization

	private Image image;
	private Experience experience;

	void Start ()
	 {
		image = GetComponent<Image> ();
		experience = GetComponentInParent<Experience>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		image.fillAmount = Mathf.Lerp(image.fillAmount,((float)	experience.getCurrentExperience()/experience.getNextLvlExp()),0.05f);
		
	}
}

