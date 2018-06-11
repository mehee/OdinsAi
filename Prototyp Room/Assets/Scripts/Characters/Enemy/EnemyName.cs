using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyName : MonoBehaviour {

	// Use this for initialization
	Text text;
	void Start () 
	{
		text = GetComponent<Text> ();

		text.text = GetComponentInParent<Enemy>().characterName;
	}
	

}
