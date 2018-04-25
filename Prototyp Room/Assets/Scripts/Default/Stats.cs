using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
	private int health;
    private int strenght;
    private int armor;
    private int intelligence;

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

    public int Strenght
    {
        get
        {
            return strenght;
        }

        set
        {
            strenght = value;
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

    public int getHealth()
	{
		return Health;
	}

	public void setHealth(int value)
	{
		this.Health = value;
	}

	
	public int getStrenght()
	{
		return Strenght;
	}

	public void setStrenght(int value)
	{
		this.Strenght = value;
	}

	
	public int getArmor()
	{
		return Armor;
	}

	public void setArmor(int value)
	{
		this.Armor = value;
	}

	
	public int getIntelligence()
	{
		return Intelligence;
	}

	public void setIntelligence(int value)
	{
		this.Intelligence = value;
	}


}
