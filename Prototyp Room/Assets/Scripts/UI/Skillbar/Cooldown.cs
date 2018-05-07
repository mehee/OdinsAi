using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour {
	private Image[] allImages;
	private Image[] cooldownImages = new Image[7];
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
		Debug.Log(cooldownImages.Length);
		Debug.Log(allImages.Length);
		wrath = GetComponentInParent<Wrath>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			if(wrath.Value >= 50f) // anstelle der 50f auf WrathUsage des Skills referenzieren
			{
				Debug.Log("Skill 1 used.");
				cooldownImages[0].fillAmount = Mathf.Lerp(1.00f,0.00f,0.05f); // anstelle der 0.05f auf CooldownLerpSpeed des Skills referenzieren
				//wrath.subtractWrathBy(50); // anstelle der 50 auf WrathUsage des Skills referenzieren
			}
		}

		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			if(wrath.Value >= 50f)
			{
				Debug.Log("Skill 2 used.");
				cooldownImages[1].fillAmount = Mathf.Lerp(1f,0f,0.05f);
				//wrath.subtractWrathBy(50);
			}
		}

		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			if(wrath.Value >= 50f)
			{
				Debug.Log("Skill 3 used.");
				cooldownImages[2].fillAmount = Mathf.Lerp(1f,0f,0.05f);
				//wrath.subtractWrathBy(50);
			}
		}

		if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			if(wrath.Value >= 50f)
			{
				Debug.Log("Skill 4 used.");
				cooldownImages[3].fillAmount = Mathf.Lerp(1f,0f,0.05f);
				//wrath.subtractWrathBy(50);
			}
		}

		if(Input.GetKeyDown(KeyCode.Alpha5))
		{
			if(wrath.Value >= 50f)
			{
				Debug.Log("Skill 5 used.");
				cooldownImages[4].fillAmount = Mathf.Lerp(1f,0f,0.05f);
				//wrath.subtractWrathBy(50);
			}
		}

		if(Input.GetKeyDown(KeyCode.Q))
		{
			if(wrath.Value >= 50f)
			{
				Debug.Log("Skill 6 used.");
				cooldownImages[5].fillAmount = Mathf.Lerp(1f,0f,0.05f);
				//wrath.subtractWrathBy(50);
			}
		}

		if(Input.GetKeyDown(KeyCode.E))
		{
			if(wrath.Value >= 50f)
			{
				Debug.Log("Skill 7 used.");
				cooldownImages[6].fillAmount = Mathf.Lerp(1f,0f,0.05f);
				//wrath.subtractWrathBy(50);
			}
		}

	}
}
