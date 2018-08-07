using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMarkers : MonoBehaviour {

private Ability abilityScript;
	[SerializeField] private GameObject[] emptyParentObjects;
	[SerializeField] int AmountOfAllSkills;
	private Image[] frontMarkerImgs;
	private int frontImgCount = 0;
	[SerializeField] private float speed; // HARDCODE! Ability Script holen und speed für Abilitys aus Methode ziehen 
	// Use this for initialization

	[SerializeField] Animator enemy;
	void Start ()
	{
		enemy = GetComponentInParent<Animator>();

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
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(enemy.GetBool("isAttacking")) //&& Ist der Skill readyforactivate? Weg finden den richtigen Skill zu counten
		{
			StartCoroutine(fillMarker(0, speed));
			//StartCoroutine(scaleMarker(0));
		}

	}

	IEnumerator scaleMarker(int skill)
	{
		emptyParentObjects[skill].SetActive(true);
		var scale = new Vector3(1.0f, 1.0f, 1.0f);
	
		if(frontMarkerImgs[skill].transform.localScale.x < scale.x)//max 1.0f
		{
			Debug.Log("Start SCALING");
			Debug.Log(frontMarkerImgs[skill].transform.localScale);
			frontMarkerImgs[skill].transform.localScale += new Vector3(0.5f,0.5f,0.5f) * Time.deltaTime;
			// frontMarkerImgs[skill].transform.localScale = new Vector3(Mathf.Lerp(0.01f,1.0f,Time.deltaTime*fillspeed),Mathf.Lerp(0.01f,1.0f,Time.deltaTime*fillspeed),0.0f);
			
			yield return null;
		}
		yield return new WaitForSeconds(0.25f);
		emptyParentObjects[skill].SetActive(false);
		yield break;
				  
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
