using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Player : Character
{

	private static Player instance;

    ExperienceBar experienceBar;
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

	/** Determines how much extra experience
		is needed for next level-up. */
	[SerializeField] float levelUpFactor = 1.5f;

	[SerializeField] int spellPointsPerLvl;

	[SerializeField] int statPointsPerLvl;
	[HideInInspector] public Health health;

	int spellPoints = 1;
	int statPoints = 0;

    int lastFrameHpStat;

	void Start()
	{
		health = GetComponent<Health> ();
		health.Maximum += stats.Health * 10;
        experienceBar = GetComponentInChildren<ExperienceBar>();
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

    public int StatPoints
    {
        get
        {
            return statPoints;
        }

        set
        {
            statPoints = value;
        }
    }

    public void GainExp(uint amount)
	{
		experience += amount;
        
		if(experience >= expToNextLevel)
		{
			LevelUp();
			expToNextLevel = (uint)(expToNextLevel*levelUpFactor);
            experience = expToNextLevel-experience;
            
		}
        
	}

    //Ueberarbeiten
    public override void Die()
	{
        health.Value = 1.0f;
	//	GetComponent<Health>().Reset();
	//	transform.position = Vector2.zero;
	}

	public void LevelUp()
	{
		level++;
		statPoints += statPointsPerLvl;
		spellPoints += spellPointsPerLvl;
		
        hpValueReset();
        StatTextScript.MyInstance.UpdateStatsText();
	}
    public void hpValueReset()
    {
        health.Maximum = stats.Health * 10;
        health.Value = health.Maximum;
    }
    public void hpMaxReset()
    {
        health.Maximum = stats.Health * 10;

        if(health.Value > health.Maximum)
        {  
            health.Value = health.Maximum;
        }
    }

    void Update()
    {
        if(lastFrameHpStat!=stats.Health)
        hpMaxReset();
        
        lastFrameHpStat=stats.Health;
        
    }
  }
