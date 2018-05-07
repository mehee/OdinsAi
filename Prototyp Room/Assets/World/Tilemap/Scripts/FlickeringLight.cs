using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringLight : MonoBehaviour {

	public float timeOn = 0.1f;
	public float timeOf = 0.5f;

	private float changeTime = 0.0f;
	public Light light;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {

		if (Time.time > changeTime)
		{
			light.enabled = !light.enabled;

			if (light.enabled) {
				changeTime = Time.time + timeOn;
			} else
				changeTime = Time.time + timeOf;
		}

	}
}
