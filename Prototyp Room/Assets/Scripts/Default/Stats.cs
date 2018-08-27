using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Stats
{
    [Tooltip("Wert bestimmen, der pro Lvl draufaddiert wird")]
    [SerializeField]
    private float hpMod;

    [SerializeField]
    private float strMod;

    [SerializeField]
    private float armMod;

    [SerializeField]
    private float intMod;

    private int health = 1;
    private int intelligence = 1;
    private int strength = 1;
    private int armor = 1;

    private float currentValue;

    //Getting MaxValue of for exp Health
    public float MyMaxValue { get; set; }

    public void UpdateStats(uint lvl)
    {
        health = Mathf.FloorToInt(hpMod*(int)lvl);
        strength = Mathf.FloorToInt(strMod*(int)lvl);
        armor = Mathf.FloorToInt(armMod*(int)lvl);
        intelligence = Mathf.FloorToInt(intMod*(int)lvl);
    }
    
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