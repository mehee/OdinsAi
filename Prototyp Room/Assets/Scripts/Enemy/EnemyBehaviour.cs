using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    private Enemy enemy;
    private Transform target;
    private Movement movement;
    private IState currentState;
    private float attackRange;
    public Transform Target
    {
        get
        {
            return target;
        }

        set
        {
            target = value;
        }
    }

    public Enemy Enemy
    {
        get
        {
            return enemy;
        }

        set
        {
            enemy = value;
        }
    }

    public Movement Movement
    {
        get
        {
            return movement;
        }

        set
        {
            movement = value;
        }
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

    // Use this for initialization
    void Start()
    {

        enemy = new Enemy("hugo", 1);
        ChangeState(new IdleState());
        AttackRange = enemy.AttackRange;
        movement = GetComponent<Movement>();
    }
    // Update is called once per frame
    void Update()
    {
        currentState.Update();
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter(this);
    }
   
}
