﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagButton : MonoBehaviour 
{
	private Bag bag;

	[SerializeField]
	private Sprite full, empty;

	public Bag MyBag
	{
		get {return bag;}
		set 
		{
			if(value != null)
				GetComponent<Image>().sprite = full;
			else
				GetComponent<Image>().sprite = empty;

			bag = value;
		}
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
