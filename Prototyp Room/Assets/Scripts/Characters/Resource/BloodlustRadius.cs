using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodlustRadius : MonoBehaviour 
{
	List<Collider2D> bleedingEnemies;

	public int GetAmountOfBleedingEnemies()
	{
		return bleedingEnemies.Count;
	}

	// Use this for initialization
	void Start () 
	{
		bleedingEnemies = new List<Collider2D>();
		bleedingEnemies.Capacity = 30;	
	}

	void Update()
	{
		for(int i = bleedingEnemies.Count - 1; i >= 0; i--)
		{
			if(!bleedingEnemies[i])
			{
				bleedingEnemies.RemoveAt(i);
				continue;
			}
			if(!bleedingEnemies[i].GetComponentInChildren<Bleed>())
				bleedingEnemies.RemoveAt(i);
		}
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag == "Enemy")
		{
			if(!bleedingEnemies.Contains(other) && other.GetComponentInChildren<Bleed>())
			{
				bleedingEnemies.Add(other);
			}
		}
	}


}
