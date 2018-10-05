using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmorStatText : MonoBehaviour {

	[SerializeField]
	private Player player;
	[SerializeField]
	private Text text;


	// Update is called once per frame
	void Update () 
	{	
		text.text = "Armor:\t" + player.stats.Armor;
	}


}
