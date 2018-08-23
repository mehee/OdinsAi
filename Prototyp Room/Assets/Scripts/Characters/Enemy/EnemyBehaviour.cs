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
    public int currentMoveSpot = 0;

    [SerializeField]
    private bool isRanged;
    [SerializeField]
    private float retreatDistance;
    [SerializeField]
    private Transform[] moveSpots;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private float attackCD;
    private float attackCDtmp;
    [SerializeField]
    private float attackDamage;
    [SerializeField]
    private float attackAnimationLenght;
    private float attackAnimatiomTMP;
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

    public float AttackCDtmp
    {
        get
        {
            return attackCDtmp;
        }

        set
        {
            attackCDtmp = value;
        }
    }

    public float AttackCD
    {
        get
        {
            return attackCD;
        }

        set
        {
            attackCD = value;
        }
    }

    public float AttackDamage
    {
        get
        {
            return attackDamage;
        }

        set
        {
            attackDamage = value;
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

    public float AttackAnimationLenght
    {
        get
        {
            return attackAnimationLenght;
        }

        set
        {
            attackAnimationLenght = value;
        }
    }

    public float AttackAnimatiomTMP
    {
        get
        {
            return attackAnimatiomTMP;
        }

        set
        {
            attackAnimatiomTMP = value;
        }
    }

    public Transform[] MoveSpots
    {
        get
        {
            return moveSpots;
        }

        set
        {
            moveSpots = value;
        }
    }

    public bool IsRanged
    {
        get
        {
            return isRanged;
        }

        set
        {
            isRanged = value;
        }
    }

    public float RetreatDistance
    {
        get
        {
            return retreatDistance;
        }

        set
        {
            retreatDistance = value;
        }
    }


    // Use this for initialization
    public virtual void Start()
    {
        
        enemy = GetComponent<Enemy>();
        Animator = GetComponent<AnimationManager>();
        ChangeState(new IdleState());
        movement = GetComponent<Movement>();
        myStartPosition = enemy.transform.position;
        attackCDtmp = attackCD;
        defaultDirection = Vector2.down;
        AttackAnimatiomTMP = attackAnimationLenght;

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
            movement.Direction = Vector2.zero;
            movement.Direction = (myStartPosition - enemy.transform.position).normalized;
        }
        else if(currentState is AttackState)
        {
            
            Animator.Attack((Target.transform.position - enemy.transform.position ).normalized);
            movement.Direction = Vector2.zero;
            movement.Direction = (Target.transform.position - enemy.transform.position).normalized;

        }
        else if(currentState is IdleState)
        {
            Animator.Stay(movement.Direction);
            //tried to follow Player position for looking around like mona lisa
           // Animator.Stay((Target.transform.position - enemy.transform.position).normalized);
        }
       /* else if (currentState is PatrolState)
        {
            Animator.Walk(moveSpots[currentMoveSpot].transform.position - enemy.transform.position);
        }
        */
    }
   
}
