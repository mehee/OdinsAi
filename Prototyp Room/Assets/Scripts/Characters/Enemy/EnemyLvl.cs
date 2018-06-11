using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLvl : MonoBehaviour {

	Text text;
	void Start () 
	{
		text = GetComponent<Text> ();

		text.text = System.Convert.ToString(GetComponentInParent<Enemy>().level);
	}
}
