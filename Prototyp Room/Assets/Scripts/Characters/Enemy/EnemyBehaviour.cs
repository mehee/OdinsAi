using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    private Enemy enemy;
    private Transform target;
    private Movement movement;
    private IState currentState;
    private AnimationManager animator;

    [SerializeField]
    private float attackRange;

    private Vector3 myStartPosition;
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
            return myStartPosition;
        }

        set
        {
            myStartPosition = value;
        }
    }

    // Use this for initialization
    void Start()
    {

        enemy = GetComponent<Enemy>();
        animator = GetComponent<AnimationManager>();
        ChangeState(new IdleState());
        AttackRange = enemy.AttackRange;
        movement = GetComponent<Movement>();
        myStartPosition = enemy.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        currentState.Update();
        animateEnemy();
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

    public void animateEnemy()
    {
        if(currentState is FollowState)
        {
            animator.Walk( target.transform.position - enemy.transform.position);
        }
        else if(currentState is EvadeState)
        {
            animator.Walk(myStartPosition - enemy.transform.position);
        }
        else if(currentState is AttackState)
        {
            
            animator.Attack((Target.transform.position - enemy.transform.position ).normalized);
        }
    }
   
}
