using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats
{
	private int health;
	private int wrath;
    private int strength;
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
	public int getWrath()
	{
		return wrath;
	}
	public void setWrath(int value)
	{
		this.wrath = value;
	}
	public int getStrength()
	{
		return strength;
	}
	public void setStrength(int value)
	{
		this.strength = value;
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
