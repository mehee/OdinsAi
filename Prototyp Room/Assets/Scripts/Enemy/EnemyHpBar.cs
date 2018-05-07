using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHpBar : MonoBehaviour 
{
	private Image image;
	Health health;


	void Start ()
	{
		image = GetComponent<Image> ();
		health = transform.parent.parent.GetComponent<Health>();		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		image.fillAmount =  Mathf.Lerp(image.fillAmount, 
			(float) health.Value / health.Maximum, 0.05f);
	}
}
