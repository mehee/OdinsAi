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
    private float strMod=1;

    [SerializeField]
    private float armMod;
    [SerializeField]
    private float intMod;
    private int baseHealth=1;
    private int baseIntelligence=1;
    private int baseStrenght=1;
    private int baseArmor=1;



    public void UpdateStats(uint lvl)
    {
        baseHealth = Mathf.FloorToInt(hpMod*(int)lvl);
        baseStrenght = Mathf.FloorToInt(strMod*(int)lvl);
        baseArmor = Mathf.FloorToInt(armMod*(int)lvl);
        baseIntelligence = Mathf.FloorToInt(intMod*(int)lvl);
    }
  

    public int BaseHealth
    {
        get
        {
            return baseHealth;
        }

        set
        {
            baseHealth = value;
        }
    }

    public int BaseStrenght
    {
        get
        {
            return baseStrenght;
        }

        set
        {
            baseStrenght = value;
        }
    }

    public int BaseArmor
    {
        get
        {
            return baseArmor;
        }

        set
        {
            baseArmor = value;
        }
    }

    public int BaseIntelligence
    {
        get
        {
            return baseIntelligence;
        }

        set
        {
            baseIntelligence = value;
        }
    }
}