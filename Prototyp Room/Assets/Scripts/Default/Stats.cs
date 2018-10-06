using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    private int health = 10;
    private int intelligence = 0;
    private int strength = 0;
    private int armor = 0;
    
    private float currentValue;

    //Getting MaxValue of for exp Health
    public float MyMaxValue { get; set; }
    
    /*just added for Update Health,Mana etc */
     public float MyCurrentValue
    {
        get
        {
            return currentValue;
        }

        set
        {
            if (value > MyMaxValue)//Makes sure that we don't get too much health
            {
                currentValue = MyMaxValue;
            }
            else if (value < 0) //Makes sure that we don't get health below 0
            {
                currentValue = 0;
            }
            else //Makes sure that we set the current value withing the bounds of 0 to max health
            {
                currentValue = value;
            }
        }
    }

    public int Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    public int Strength
    {
        get
        {
            return strength;
        }

        set
        {
            strength = value;
        }
    }

    public int Armor
    {
        get
        {
            return armor;
        }

        set
        {
            armor = value;
        }
    }

    public int Intelligence
    {
        get
        {
            return intelligence;
        }

        set
        {
            intelligence = value;
        }
    }
}