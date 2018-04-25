using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrath : MonoBehaviour {

	PlayerScript playerScript;
	Player player;
	Death death;
	void Start () 
	{
		playerScript = GetComponent<PlayerScript> ();
		death = GetComponent<Death> ();
		player = playerScript.getPlayer();
	}
	
	public void subtractWrathBy(float value)
	{	
		if(player.getCurrentWrath() > value)
			player.subtractWrathBy(value);
		else
			Debug.Log("Wrath zu niedrig.");
	}	
}
