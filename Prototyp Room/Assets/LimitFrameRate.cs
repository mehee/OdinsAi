using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitFrameRate : MonoBehaviour
{
	public int targetFrameRate = 60;

	// Use this for initialization
	void Start () 
	{
		Application.targetFrameRate = targetFrameRate;	
	}
}
