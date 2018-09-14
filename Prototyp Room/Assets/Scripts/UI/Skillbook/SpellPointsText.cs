using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellPointsText : MonoBehaviour {

	// Use this for initialization
	Text text;
	Player player;
	void Start () 
	{
		text = GetComponent<Text>();
		player = GetComponentInParent<Player>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		text.text = "Spellpoints: " + player.SpellPoints;
	}
}
