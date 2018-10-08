using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthText : MonoBehaviour {

	private Text text;
	private Health health;

	private float tmp;

	void Start () 
	{
		text = GetComponent<Text> ();
		health = FindObjectOfType<Player>().GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		tmp = (health.Value/health.Maximum) * 100;
		text.text =health.Value + "/" + health.Maximum;// tmp+ " %";
	}
}
