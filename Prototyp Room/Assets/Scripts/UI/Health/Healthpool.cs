using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthpool : MonoBehaviour {

	// Use this for initialization

	private Image image;
	private PlayerScript playerScript;
	private Player player;

	void Start ()
	 {
		image = GetComponent<Image> ();
		playerScript = GetComponentInParent<PlayerScript> ();
		player = playerScript.getPlayer();
	}
	
	// Update is called once per frame
	void Update () 
	{
		image.fillAmount =  Mathf.Lerp(image.fillAmount,(float)player.getCurrentHealth()/player.getMaxHealth(),0.05f);
	}
}
