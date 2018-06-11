using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodlustValue : MonoBehaviour 
{
	private Text text;
	private Bloodlust bloodlust;

	void Start () 
	{
		bloodlust = transform.root.GetComponent<Bloodlust>();
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = bloodlust.Value + "/" + bloodlust.Maximum;
	}
}
