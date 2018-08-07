using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    private Enemy enemy;
    private Transform target;
    private Movement movement;
    private IState currentState;
    private AnimationManager animator;
    private Vector2 defaultDirection;

    [SerializeField]
    private float attackRange;
    [SerializeField]
    private float autoAttackCooldown;
    private float autoAttackCDtmp;
    [SerializeField]
    private float autoAttackDamage;
    [SerializeField]
    private float autoAttackAnimationLenght;
    private float autoAttackAnimatiomTMP;

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

    public float AutoAttackCDtmp
    {
        get
        {
            return autoAttackCDtmp;
        }

        set
        {
            autoAttackCDtmp = value;
        }
    }

    public float AutoAttackCooldown
    {
        get
        {
            return autoAttackCooldown;
        }

        set
        {
            autoAttackCooldown = value;
        }
    }

    public float AutoAttackDamage
    {
        get
        {
            return autoAttackDamage;
        }

        set
        {
            autoAttackDamage = value;
        }
    }

    public Vector2 DefaultDirection
    {
        get
        {
            return defaultDirection;
        }

        set
        {
            defaultDirection = value;
        }
    }

    public AnimationManager Animator
    {
        get
        {
            return animator;
        }

        set
        {
            animator = value;
        }
    }
    public float AutoAttackAnimationLenght
    {
        get
        {
            return autoAttackAnimationLenght;
        }

        set
        {
            autoAttackAnimationLenght = value;
        }
    }

    public float AutoAttackAnimatiomTMP
    {
        get
        {
            return autoAttackAnimatiomTMP;
        }

        set
        {
            autoAttackAnimatiomTMP = value;
        }
    }

    // Use this for initialization
    void Start()
    {

        enemy = GetComponent<Enemy>();
        Animator = GetComponent<AnimationManager>();
        ChangeState(new IdleState());
        movement = GetComponent<Movement>();
        myStartPosition = enemy.transform.position;
        autoAttackCDtmp = autoAttackCooldown;
        defaultDirection = Vector2.down;
        AutoAttackAnimatiomTMP = autoAttackAnimationLenght;
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
            Animator.Walk( target.transform.position - enemy.transform.position);
        }
        else if(currentState is EvadeState)
        {
            Animator.Walk(myStartPosition - enemy.transform.position);
        }
        else if(currentState is AttackState)
        {
            
            Animator.Attack((Target.transform.position - enemy.transform.position ).normalized);
        }
    }
   
}
