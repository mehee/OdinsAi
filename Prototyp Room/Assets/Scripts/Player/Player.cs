using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Player : Character
{
	[SerializeField]
	int expToNextLevel;
	[SerializeField]
	int experience = 0;
	[SerializeField]
	/** Determines how much extra experience
		is needed for next level-up. */
	float levelUpFactor = 0.1f;

    public int ExpToNextLevel
    {
        get { return expToNextLevel; }
        private set { expToNextLevel = value; }
    }

    public int Experience
    {
        get { return experience; }
        private set { experience = value; }
    }

    public override void Die()
	{
		GetComponent<Health>().Reset();
		transform.position = Vector2.zero;
	}

	public void GainExp(int amount)
	{
		experience += amount;
		if(experience >= expToNextLevel)
		{
			LevelUp();
			experience -= expToNextLevel;
			expToNextLevel = Mathf.FloorToInt(
				expToNextLevel * levelUpFactor);
		}
	}

	void LevelUp()
	{
		level++;
	}
}
