using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadButtState : IState
{

    private EnemyBehaviour parent;

    private Vector2 headButtTarget;
    private float chargeSpeed;
    private float chargeTime;
    private Health playerHealth;
    private float distance;
    private BoxCollider2D enemyCollider;
    private bool hitted;
    private AnimationManager animator;
    private bool isCharging;
    private VariousEnemyVars vars;
    private Vector2 direction;

    public void Enter(EnemyBehaviour parent)
    {
        this.parent = parent;
        vars = parent.Vars;
       
        playerHealth = parent.Target.GetComponent<Health>();
        enemyCollider = parent.GetComponent<BoxCollider2D>();
        animator = parent.GetComponent<AnimationManager>();
        hitted = false;
        //3 hardcoded variables change to dynamic
        headButtTarget = getVectorBehindPlayer(vars.overChargeDistance);
        chargeSpeed = vars.chargeSpeed;
        chargeTime = vars.chargeTime;
         direction = (parent.Target.position - parent.transform.position).normalized;

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
        
        parent.Movement.Move(Vector2.zero);
        animator.Charge(direction);
        chargeTime -= Time.deltaTime;
        if(chargeTime <= 0)
        {
            animator.setChargeFalse();
            animator.Attack(direction);
           
            parent.transform.position = Vector2.MoveTowards(parent.transform.position, headButtTarget, Time.deltaTime * chargeSpeed);

           
                if (Vector2.Distance(parent.transform.position, parent.Target.position) < 1 && hitted == false)
                {
                playerHealth.Reduce(parent.AttackDamage);
                hitted = true;
                 //Debug.Log("Gotcha Headbutter!");
            }
            if (Vector2.Distance(parent.transform.position, headButtTarget) < 1)
            {
                parent.ChangeState(new IdleState());
            }
        }

        
    }

    private Vector2 getVectorBehindPlayer(float multiplyer)
    {
        Vector2 direction1 = (parent.Target.position - parent.transform.position).normalized;
        Vector2 parentTargetVector2 = new Vector2(parent.Target.position.x, parent.Target.position.y);
        Vector2 vectorBehindPlayer = parentTargetVector2 + direction1 * multiplyer;
        return vectorBehindPlayer;
    }
}
