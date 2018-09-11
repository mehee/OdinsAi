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
	[SerializeField] float levelUpFactor = 0.1f;

	[SerializeField] int spellPointsPerLvl=1;

	[HideInInspector] public Health health;

	int spellPoints = 0;

	void Start()
	{
		healthStats = GetComponent<Health> ();
		healthStats.Maximum +=stats.Health * 10;
		healthStats.Reset();
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

    public int SpellPoints
    {
        get
        {
            return spellPoints;
        }

        set
        {
            spellPoints = value;
        }
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
		spellPoints += spellPointsPerLvl;
		health.Maximum += stats.Health * 100;
	}
}
