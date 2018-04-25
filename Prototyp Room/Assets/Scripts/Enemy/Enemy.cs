using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

    private EnemyBehaviour enemyBehaviour;
    private Stats stats;
    private float currentHealth;
    [SerializeField]
    private float attackRange;

    public Enemy(string name, uint currentLvl) : base(name, currentLvl)
    {
        attackRange = 2;
        stats = new Stats();
        setStats(currentLvl);
        setMaxHealth(stats.getHealth() * 100);
        currentHealth = this.getMaxHealth();


    }



    public float AttackRange
    {
        get
        {
            return attackRange;
        }

        set
        {
            attackRange = value;
        }
    }




    public override void setStats(uint currentLvl)
    {
        stats.setHealth(2 * (int)currentLvl);
        stats.setArmor(1 * (int)currentLvl);
        stats.setStrenght(2 * (int)currentLvl);
        stats.setIntelligence(1 * (int)currentLvl);
    }


    public void subtractHealthBy(float value)
    {
        this.currentHealth -= value;
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }

}
