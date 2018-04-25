using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Character
{
    [SerializeField]
    private string name;
    private float maxHealth;
    private uint currentLvl=1;
   


    public Character(string name, uint currentLvl)
    {
        name = this.name;
        currentLvl = this.currentLvl;

    }

    public abstract void setStats(uint currentLvl);

    public virtual float getMaxHealth()
    {
        return maxHealth;
    }

     public virtual void setMaxHealth(float value)
    {
        this.maxHealth= value;
    }


     public virtual void LevelUp()
    {
        this.currentLvl++;
    }

    public virtual uint getCurrentLvl()
    {
        return currentLvl;
    }








}
