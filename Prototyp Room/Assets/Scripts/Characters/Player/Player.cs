using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Player : Character
{

	private static Player instance;

    public static Player MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<Player>();
            }

            return instance;
        }
    }
	
	[SerializeField]
	uint expToNextLevel;
	[SerializeField]
	uint experience = 0;
	[SerializeField]
	/** Determines how much extra experience
		is needed for next level-up. */
	float levelUpFactor = 0.1f;

	Health health;

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
