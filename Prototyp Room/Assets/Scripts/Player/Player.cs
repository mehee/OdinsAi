using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Player : Character
{

	private float resource;
	private float currentHealth;
	private float currentWrath;
	private Stats stats;

	public Player(String name,uint currentLvl) : base(name,currentLvl)
	{
		stats = new Stats();
		setStats(currentLvl);

		setMaxHealth(stats.getHealth()*100);
		currentHealth = this.getMaxHealth();

		setMaxWrath(stats.getWrath()*100);
		currentWrath = this.getMaxWrath();

		this.resource = stats.getIntelligence()*100;
	}
    public override void setStats(uint currentLvl)
    {
		stats.setHealth(2*(int)currentLvl);
		stats.setWrath(2*(int)currentLvl);
		stats.setArmor(1*(int)currentLvl);
		stats.setStrength(2*(int)currentLvl);
		stats.setIntelligence(1*(int)currentLvl);
    }
	public float getCurrentHealth()
	{
		return currentHealth;
	}
	public void subtractHealthBy(float value)
	{
		this.currentHealth-= value;
	}
	public float getCurrentWrath()
	{
		return currentWrath;
	}
	public void subtractWrathBy(float value)
	{
		this.currentWrath -= value;
	}
	public void lvlUp()
	{
		this.LevelUp();
		this.update();
	}
    public void update()
    {
        setStats(this.getCurrentLvl());

        setMaxHealth(stats.getHealth() * 100);
        currentHealth = this.getMaxHealth();

		setMaxWrath(stats.getWrath() * 100);
        currentWrath = this.getMaxWrath();

        this.resource = stats.getIntelligence() * 100;
    }

}
