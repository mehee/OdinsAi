using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour {

	// Use this for initialization

	private Image image;
	private Player player;

	void Start ()
	 {
		image = GetComponent<Image> ();
		player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	public void Update () 
	{
		Debug.Log(player.Experience/player.ExpToNextLevel);
		Debug.Log(player.Experience);	
		image.fillAmount = Mathf.Lerp(image.fillAmount,((float)	player.Experience/(float)player.ExpToNextLevel),0.05f);
		
	}
}

