using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Player : Character
{
	[SerializeField] uint expToNextLevel;
	[SerializeField] uint experience = 0;
	/** Determines how much extra experience
		is needed for next level-up. */
	[SerializeField] float levelUpFactor = 0.1f;

	[HideInInspector] public Health health;

	void Start()
	{
		health = GetComponent<Health> ();
		health.Maximum +=stats.Health * 10;
		health.Reset();
	}
	
    public uint ExpToNextLevel
    {
        get { return expToNextLevel; }
        private set { expToNextLevel = value; }
    }

    public uint Experience
    {
        get { return experience; }
        private set { experience = value; }
    }

	public void GainExp(uint amount)
	{
		experience += amount;
		if(experience >= expToNextLevel)
		{
			LevelUp();
			experience -= expToNextLevel;
			expToNextLevel = (uint)Mathf.FloorToInt(
				expToNextLevel * levelUpFactor);
		}
	}
    public override void Die()
	{
		GetComponent<Health>().Reset();
		transform.position = Vector2.zero;
	}

	void LevelUp()
	{
		level++;
		stats.UpdateStats(level);
		health.Maximum += stats.Health * 100;
	}
}
