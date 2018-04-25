using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrathText : MonoBehaviour {

	private PlayerScript playerScript;
	private Text text;
	private Player player;

	void Start () 
	{
		text = GetComponent<Text> ();
		playerScript = GetComponentInParent<PlayerScript> ();
		player = playerScript.getPlayer();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = player.getCurrentWrath() + "/" + player.getMaxWrath();
	}
}
