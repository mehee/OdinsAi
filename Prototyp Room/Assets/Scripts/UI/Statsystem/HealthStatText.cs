using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthStatText : MonoBehaviour
{

	// Use this for initialization
	[SerializeField]
	private Player player;
	[SerializeField]
	private Text text;
	
	// Update is called once per frame
	void Update () 
	{	
		text.text = "Health: " + player.stats.Health;	
	}

	public void UpdateStatsText()
	{

	}
}

