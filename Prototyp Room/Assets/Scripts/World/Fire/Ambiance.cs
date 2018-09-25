using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambiance : MonoBehaviour {

	new public Light light;
	public float minIntensity;
	public float maxIntensity;
	

	// Array of random values for the intensity.
	private float[] smoothing = new float[20];

	void Start()
	{
		//light = light.GetComponent<Light> ();
		for(int i = 0 ; i < smoothing.Length ; i++)
		{
			smoothing[i] = 0.0f;
		}
	}

	void Update () 
	{
		float sum = 0.0f;
		// Shift values in the table so that the new one is at the
		// end and the older one is deleted.
		for(int i = 1 ; i < smoothing.Length ; i++)
		{
			smoothing[i-1] = smoothing[i];
			sum += smoothing[i-1];
		}
		// Add the new value at the end of the array.
		smoothing[smoothing.Length -1] = Random.Range (minIntensity, maxIntensity);
		sum+= smoothing[smoothing.Length -1];

		// Compute the average of the array and assign it to the light intensity.
		light.intensity = sum / smoothing.Length;
	}

}
