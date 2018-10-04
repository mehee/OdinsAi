using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntStatText : MonoBehaviour {


	Player player;
	Text text;
	void Start () 
	{
		player = GetComponentInParent<Player>();
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () 
	{	
		text.text = "Intelligence: " + player.stats.Intelligence;
		
	}
}
