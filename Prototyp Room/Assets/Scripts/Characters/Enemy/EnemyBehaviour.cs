using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AbilitySystem;

public class EnemyBehaviour : MonoBehaviour {

    private Enemy enemy;
    private Transform target;
    private Movement movement;
    private IState currentState;
    private AnimationManager animator;
    private Vector2 defaultDirection;
    public int currentMoveSpot = 0;
    private VariousEnemyVars vars;

    private EnemyAbility ability;
    private EnemyAbility abilityInstance;

    private BossVars bossVars;
    private EnemyAbility[] bossAbillites;
    private EnemyAbility bossAbilityInstance;

    private DemonAbility demonAbility;
    



    [SerializeField]
    private bool isRanged;
    [SerializeField]
    private bool isHeadbutt;
    [SerializeField]
    private bool isBoss;
    [SerializeField]
    private float evadeDistance;
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

    public float EvadeDistance
    {
        get
        {
            return evadeDistance;
        }

        set
        {
            evadeDistance = value;
        }
    }

    public bool IsHeadbutt
    {
        get
        {
            return isHeadbutt;
        }

        set
        {
            isHeadbutt = value;
        }
    }

    public VariousEnemyVars Vars
    {
        get
        {
            return vars;
        }

        set
        {
            vars = value;
        }
    }

    public EnemyAbility Ability
    {
        get
        {
            return ability;
        }

        set
        {
            ability = value;
        }
    }

    public EnemyAbility AbilityInstance
    {
        get
        {
            return abilityInstance;
        }

        set
        {
            abilityInstance = value;
        }
    }

    public BossVars BossVars
    {
        get
        {
            return bossVars;
        }

        set
        {
            bossVars = value;
        }
    }

    public EnemyAbility[] BossAbillites
    {
        get
        {
            return bossAbillites;
        }

        set
        {
            bossAbillites = value;
        }
    }

    public EnemyAbility BossAbilityInstance
    {
        get
        {
            return bossAbilityInstance;
        }

        set
        {
            bossAbilityInstance = value;
        }
    }

    public bool IsBoss
    {
        get
        {
            return isBoss;
        }

        set
        {
            isBoss = value;
        }
    }






    // Use this for initialization
    public virtual void Start()
    {
        
        enemy = GetComponent<Enemy>();
        Animator = GetComponent<AnimationManager>();
        ChangeState(new IdleState());
        movement = GetComponent<Movement>();
        myStartPosition = this.transform.position;
        attackCDtmp = attackCD;
        defaultDirection = Vector2.down;
        AttackAnimatiomTMP = attackAnimationLenght;
       



        if (isRanged)
        {
            demonAbility = GetComponent<DemonAbility>();
            ability = demonAbility.Ability;
            AbilityInstance = Ability.CreateInstance(enemy) as EnemyAbility;
            AbilityInstance.transform.SetParent(this.transform);
        }
        else if(isHeadbutt)
        {
            vars = GetComponent<VariousEnemyVars>();
        }
        else if(isBoss)
        {
           // Debug.Log("yes i am the boss");

            BossVars = GetComponent<BossVars>();
            BossAbillites = BossVars.ability;
            for (int i = 0; i < 2; i++)
            {
                BossAbilityInstance = BossAbillites[i].CreateInstance(enemy) as EnemyAbility;
                BossAbilityInstance.transform.SetParent(this.transform);
            }
            setAbility(0);
        }



    }

    public void setAbility(int abilitySlot)
    {
        BossAbilityInstance = BossAbillites[abilitySlot].CreateInstance(enemy) as EnemyAbility;
        BossAbilityInstance.transform.SetParent(this.transform);
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
        else if(currentState is RetreatState)
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
    }
   
}
