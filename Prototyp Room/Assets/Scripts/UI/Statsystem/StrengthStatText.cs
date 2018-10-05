using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrengthStatText : MonoBehaviour {

	
	[SerializeField]
	private Player player;
	[SerializeField]
	private Text text;


	// Update is called once per frame
	void Update () 
	{	
		text.text = "Strenght:\t" + player.stats.Strength;
		
	}
}
