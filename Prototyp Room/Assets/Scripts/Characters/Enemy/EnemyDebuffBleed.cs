using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDebuffBleed : MonoBehaviour {

	Image image;
	void Start () 
	{
	image = GetComponent<Image>();	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Bleed bl = GetComponentInParent<Enemy>().GetComponentInChildren<Bleed>();
		if(bl!=null)
		{
			image.enabled = true;
			image.fillAmount = bl.lifeTime.Remaining/bl.lifeTime.Remaining;
		}
		else
		image.enabled=false;
		
	
	}
}
