using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour {

	private PlayerScript playerScript;
	private Text text;
	private Player player;

	void Start () 
	{
		text = GetComponent<Text> ();
		playerScript = GetComponentInParent<PlayerScript> ();
		player = playerScript.Player;
	}
	
	// Update is called once per frame
	void Update () {
		text.text= player.CurrentHealth + "/" + player.getMaxHealth();
	}
}
