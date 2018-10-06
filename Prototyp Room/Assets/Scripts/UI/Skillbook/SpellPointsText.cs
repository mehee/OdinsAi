using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellPointsText : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	private Text text;
	[SerializeField]
	private Player player;
	
	// Update is called once per frame
	void Update () 
	{
		text.text = "Spellpoints: " + player.SpellPoints;
	}
}
