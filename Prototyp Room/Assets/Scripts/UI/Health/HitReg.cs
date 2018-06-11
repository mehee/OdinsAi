using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitReg : MonoBehaviour {

	[SerializeField] private GameObject bloodObj;
	private Image bloodImg;
	private Color bloodCol;
	private float scale;
	// Use this for initialization
	void Start () {
		scale = 1f;
		bloodImg = bloodObj.GetComponent<Image>();
		bloodCol = bloodImg.color;
		bloodCol.a = 0f;
		bloodImg.color = bloodCol;
		bloodObj.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Use"))
		{
			Debug.Log(bloodCol.a);
			bloodObj.SetActive(true);
			StartCoroutine(fadeBlood(scale));
		}
	}
	IEnumerator fadeBlood(float scale)
	{	
    	while (bloodCol.a < scale)
		{
			bloodCol.a += 4f*Time.deltaTime;
			bloodImg.color = bloodCol;
			Debug.Log(bloodCol.a);
			yield return null;
    	}
		yield return new WaitForSeconds(3f);
		while (bloodCol.a >= 0f)
		{
			bloodCol.a -= 0.25f*Time.deltaTime;
			bloodImg.color = bloodCol;
			Debug.Log(bloodCol.a);
			yield return null;
    	}
		Debug.Log("done");
		bloodObj.SetActive(false); // auch noch vorher faden
		yield break;
	}
}
