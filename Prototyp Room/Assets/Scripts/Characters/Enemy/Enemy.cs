using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character 
{
    //LootStuff. DELETE ME LATER
    public GameObject chest;
    private bool isDead = false;
    //END: LootStuff


    private EnemyBehaviour enemyBehaviour;
    private float currentHealth;
    [SerializeField] private float attackRange;
    [SerializeField] uint experienceReward;

    [HideInInspector] Health health;

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

    public bool IsLootable{get;set;}

    public void Start()
    {
        chest.SetActive(false);
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

        isDead = true;
        if(isDead)
        {
            chest.transform.position = this.transform.position;
            chest.SetActive(true);
        }


        IsLootable = true;        
        if(IsLootable)
        {
            //Erzeug eine neue Truhe an der Stelle an der der Gegener stirb
            //var newChest = Instantiate(chest,gameObject.transform.position,Quaternion.identity);
        }
    }
}
