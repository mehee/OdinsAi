using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown 
{
	public float StartTime { get; set; }
	public float RemainingTime { get; private set; }
	public bool Finished { get; private set; }

	const float epsilon = 0.00001f;

	public CountDown(float startTime)
	{
		if(startTime < 0)
			Debug.LogError("StartTime is negative though it should not be.");
		StartTime = startTime;
		Start();
	}
	
	public void ReduceRemainingTime(float seconds)
	{
		if(!Finished)
		{
			RemainingTime -= Mathf.Abs(seconds);
			if(RemainingTime <= (0 + epsilon))
				Finished = true;
		}
	}

	public void Start()
	{
		RemainingTime = StartTime;
		Finished = false;
	}
}
