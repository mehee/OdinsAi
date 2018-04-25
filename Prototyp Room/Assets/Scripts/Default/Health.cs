﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	PlayerScript playerScript;
	Player player;
	Death death;
	void Start () 
	{
		playerScript = GetComponent<PlayerScript> ();
		death = GetComponent<Death> ();
		player = playerScript.getPlayer();
	}
	
	public void subtractHealthBy(float value)
	{
		if(player.getCurrentHealth() > value)
			player.subtractHealthBy(value);
		else
			Debug.Log("Health zu niedrig. Spieler tot.");
	}


	
}
