using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WrathText : MonoBehaviour 
{
	private Text text;
	private Wrath wrath;

	void Start () 
	{
		wrath = FindObjectOfType<Player>().GetComponent<Wrath>();
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = wrath.Value + "/" + wrath.Maximum;
	}
}
