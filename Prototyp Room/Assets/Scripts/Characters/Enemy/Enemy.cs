using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character 
{
    private EnemyBehaviour enemyBehaviour;
    private float currentHealth;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    uint experienceReward;

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

    public void Update()
    {
        Player player = FindObjectOfType<Player>();
        Vector2 distance = player.transform.position - transform.position;
    }

    public override void Die()
    {
        Player player = FindObjectOfType<Player>();
        player.GainExp((uint)experienceReward);
        Destroy(gameObject);
    }
}
