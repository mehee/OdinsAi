using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class IdleState : IState
{
    private EnemyBehaviour parent;

    public void Enter(EnemyBehaviour parent)
    {
        this.parent = parent;
    }

    public void Exit()
    {
        
    
    }

    public void Update()
    {
        parent.Animator.Stay(parent.Movement.Direction);
        //change into follow state if player is close
        if (parent.Target != null)
        {
            float distance = Vector2.Distance(parent.Target.position, parent.transform.position);
            if (distance >= parent.AttackRange)
            {
                parent.ChangeState(new FollowState());
            }
            // parent.ChangeState(new FollowState());
            else
            {
                parent.AutoAttackCooldown -= Time.deltaTime;
                if (parent.AutoAttackCooldown <= 0)
                {
                    parent.ChangeState(new AttackState());
                }
            }



        }
    }
}

