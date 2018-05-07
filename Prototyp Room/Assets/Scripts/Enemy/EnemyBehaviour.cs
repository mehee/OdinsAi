using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    private Enemy enemy;
    private Transform target;
    private Movement movement;
    private IState currentState;

    [SerializeField]
    private float attackRange;

    private Vector3 myStartPos;
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

    public Vector3 MyStartPosition
    {
        get
        {
            return myStartPos;
        }

        set
        {
            myStartPos = value;
        }
    }

    // Use this for initialization
    void Start()
    {

        enemy = GetComponent<Enemy>();
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
