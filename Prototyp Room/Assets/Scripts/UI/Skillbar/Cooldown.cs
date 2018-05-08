using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
				Debug.Log("Added " + cooldown_image + " to Array at " + fieldcount);
				fieldcount++;
			}
		}
		abilities = transform.root.GetComponentsInChildren<Ability>();
		activeAbilities = abilities.Length;
		for(int i = activeAbilities; i < cooldownImages.Length; i++)
		{
			cooldownImages[i].fillAmount = 1f;
		}
		Debug.Log(cooldownImages.Length);
		Debug.Log(allImages.Length);
		wrath = GetComponentInParent<Wrath>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		for(int i = 0; i < activeAbilities; i++)
		{
			float remaining = abilities[i].CooldownTimer / abilities[i].Cooldown;
			cooldownImages[i].fillAmount = remaining;
		}
	}
}