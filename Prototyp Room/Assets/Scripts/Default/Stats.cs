using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
	private int health;
    private int strenght;
    private int armor;
    private int intelligence;


	public int getHealth()
	{
		return health;
	}

	public void setHealth(int value)
	{
		this.health = value;
	}

	
	public int getStrenght()
	{
		return strenght;
	}

	public void setStrenght(int value)
	{
		this.strenght = value;
	}

	
	public int getArmor()
	{
		return armor;
	}

	public void setArmor(int value)
	{
		this.armor = value;
	}

	
	public int getIntelligence()
	{
		return intelligence;
	}

	public void setIntelligence(int value)
	{
		this.intelligence = value;
	}


}
