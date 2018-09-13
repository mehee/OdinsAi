﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AbilitySystem;

public class Cooldown : MonoBehaviour 
{
	private Image[] allImages;
	private Image[] cooldownImages = new Image[7];
	private Ability[] abilities;
	private int activeAbilities;
	private int fieldcount = 0;
	private Wrath wrath;

	// Use this for initialization
	void Start () {
		allImages = GetComponentsInChildren<Image>();
		foreach(Image cooldown_image in allImages)
		{
			if(cooldown_image.tag == "cooldown")
			{
				cooldownImages[fieldcount] = cooldown_image;
				fieldcount++;
			}
		}
		abilities = transform.root.GetComponentsInChildren<Ability>();
		activeAbilities = abilities.Length;
		for(int i = activeAbilities; i < cooldownImages.Length; i++)
		{
			cooldownImages[i].fillAmount = 1f;
		}
		wrath = GetComponentInParent<Wrath>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		for(int i = 0; i < activeAbilities; i++)
		{
			float remaining = abilities[i].Cooldown.Remaining / abilities[i].Cooldown.Duration;
			cooldownImages[i].fillAmount = remaining;
		}
	}
}