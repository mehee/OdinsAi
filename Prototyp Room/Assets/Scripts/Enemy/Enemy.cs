using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {

    private EnemyBehaviour enemyBehaviour;
    private Stats stats;
    [SerializeField]
    private float attackRange;

    public Enemy(string name, uint currentLvl) : base(name, currentLvl)
    {
        attackRange = 2;

        
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
        throw new NotImplementedException();
    }
}
