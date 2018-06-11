using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodlustFill : MonoBehaviour 
{
	private Image image;
	private Bloodlust bloodlust;

	void Start ()
	 {
		bloodlust = transform.root.GetComponent<Bloodlust>();
		image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		image.fillAmount =  Mathf.Lerp(image.fillAmount,(float)bloodlust.Value/bloodlust.Maximum,0.05f);
	}
}
