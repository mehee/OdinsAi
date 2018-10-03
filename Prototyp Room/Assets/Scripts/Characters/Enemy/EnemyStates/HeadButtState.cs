﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadButtState : IState
{

    private EnemyBehaviour parent;

    private Vector2 headButtTarget;
    private float chargeSpeed;
    private Health playerHealth;
    private float distance;
    private Collider2D enemyCollider;
    private bool hitted;

    public void Enter(EnemyBehaviour parent)
    {
        this.parent = parent;
        headButtTarget = getVectorBehindPlayer(2);
        chargeSpeed = 10;
        playerHealth = parent.Target.GetComponent<Health>();
        enemyCollider = parent.GetComponent<BoxCollider2D>();
        hitted = false;
    }

    public void Exit()
    {

    }

    // Use this for initialization
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        parent.transform.position = Vector2.MoveTowards(parent.transform.position, headButtTarget, Time.deltaTime * chargeSpeed);

        if (enemyCollider.IsTouchingLayers(9) && hitted == false)
        {
            playerHealth.Reduce(parent.AttackDamage);
            hitted = true;
            //Debug.Log("Gotcha Headbutter!");
        }
        if (Vector2.Distance(parent.transform.position, headButtTarget) < 1)
        {
            parent.ChangeState(new EvadeState());
        }
    }

    private Vector2 getVectorBehindPlayer(float multiplyer)
    {
        Vector2 direction = (parent.Target.position - parent.transform.position).normalized;
        Vector2 parentTargetVector2 = new Vector2(parent.Target.position.x, parent.Target.position.y);
        Vector2 vectorBehindPlayer = parentTargetVector2 + direction * multiplyer;
        return vectorBehindPlayer;
    }
}