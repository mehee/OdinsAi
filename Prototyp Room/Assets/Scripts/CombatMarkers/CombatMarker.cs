using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AbilitySystem;

public class CombatMarker : MonoBehaviour {
	private Ability abilityScript;
	[SerializeField] private GameObject[] emptyParentObjects;
	[SerializeField] int AmountOfAllSkills;
	private Image[] frontMarkerImgs;
	private int frontImgCount = 0;
	[SerializeField] private float speed; // HARDCODE! Ability Script holen und speed für Abilitys aus Methode ziehen 
	// Use this for initialization
	void Start ()
	{
		abilityScript = GameObject.FindObjectOfType(typeof(Ability)) as Ability;

		frontMarkerImgs = new Image[AmountOfAllSkills];

		foreach(GameObject tmpParents in emptyParentObjects)
		{
			tmpParents.SetActive(false);
			foreach(Image tmpImage in tmpParents.GetComponentsInChildren<Image>())
			{
				if(tmpImage.tag == "combatMarkerFront")
				{
					frontMarkerImgs[frontImgCount] = tmpImage;
					frontImgCount++;
				}
			}
		}

		frontMarkerImgs[2].fillAmount = 1f; // HARDCODE! Noch die Anzahl der Dashes dynamisch beziehen
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown("Ability1")) //&& Ist der Skill readyforactivate? Weg finden den richtigen Skill zu counten
		{
	StartCoroutine(fillMarker(0, speed));
		}

		if(Input.GetButtonDown("Ability2")) //&& Ist der Skill readyforactivate? Weg finden den richtigen Skill zu counten
		{
			StartCoroutine(fillMarker(1, speed));
			// Fade in und Fillamount anhand von Spelltime
		}

		//Dash Markers noch langsam outfaden, wenn nicht in gewisser Zeit genutzt
		if(Input.GetButtonDown("Jump")) //&& Ist der Skill readyforactivate? Weg finden den richtigen Skill zu counten
		{
			StartCoroutine(substractMarkerAmount(2));
			// Fade in und Fillamount anhand von Spelltime
		}
	}
	IEnumerator fillMarker(int skill, float speed)
	{	
		emptyParentObjects[skill].SetActive(true);
		frontMarkerImgs[skill].fillAmount = 0f;
    	while (frontMarkerImgs[skill].fillAmount < 1.0f)
		{
			frontMarkerImgs[skill].fillAmount += speed*Time.deltaTime;
			yield return null;
    	}
		yield return new WaitForSeconds(0.25f);
		emptyParentObjects[skill].SetActive(false);
		// Flag setzen, dass casttime fertig ist und skill gefeuert werden kann
		yield break;
	}

	IEnumerator substractMarkerAmount(int skill)
	{
		emptyParentObjects[skill].SetActive(true);
		frontMarkerImgs[skill].fillAmount -= 0.35f;
		yield return new WaitForSeconds(0.5f);
		emptyParentObjects[skill].SetActive(false);
	}
}
