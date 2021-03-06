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

	/** Determines how much extra experience
		is needed for next level-up. */
	[SerializeField] float levelUpFactor = 1.5f;

	[SerializeField] int spellPointsPerLvl;

	[SerializeField] int statPointsPerLvl;
	[HideInInspector] public Health health;
    [SerializeField]
    private GameObject graveYard;

	int spellPoints = 1;
	int statPoints = 0;

    int lastFrameHpStat;

	void Start()
	{
		health = GetComponent<Health> ();
		health.Maximum += stats.Health * 10;
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

    
    public override void Die()
	{
		GetComponent<Health>().Reset();
		transform.position = graveYard.transform.position;
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
