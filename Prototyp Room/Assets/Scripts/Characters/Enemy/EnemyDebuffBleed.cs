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
		Bleed bl = GetComponentInParent<Bleed>();
		if(bl!=null)
		{
			Debug.Log("Succes");
		}
		
	
	}
}
