using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wrathpool : MonoBehaviour {

	// Use this for initialization

	private Image image;
	private Wrath wrath;

	void Start ()
	 {
		wrath = FindObjectOfType<Player>().GetComponent<Wrath>();
		image = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		image.fillAmount =  Mathf.Lerp(image.fillAmount,(float)wrath.Value/wrath.Maximum,0.05f);
	}
}
