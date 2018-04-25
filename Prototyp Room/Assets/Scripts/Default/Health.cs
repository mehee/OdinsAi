using System.Collections;
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
		player.subtractHealthBy(value);
	
		if(player.getCurrentHealth()<=0)
			death.die();
		
	}


	
}
