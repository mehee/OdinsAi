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
        if(parent.IsRanged||parent.IsBoss)
        {
            parent.Animator.setAwakeingFalse();
        }
        //change into follow state if player is close
        if (parent.Target != null)
        {
            float distance = Vector2.Distance(parent.Target.position, parent.transform.position);
            if (parent.IsRanged||parent.IsBoss)
            {
                parent.Animator.setAwakeingTrue();
            }

           
            if(distance <= parent.EvadeDistance)
            {
                parent.ChangeState(new EvadeState());
            }
            if (distance >= parent.AttackRange)
            {
               
                parent.ChangeState(new FollowState());
            }
            // parent.ChangeState(new FollowState());
            else
            {
                parent.AttackCD -= Time.deltaTime;
                if (parent.AttackCD <= 0)
                {
                    parent.ChangeState(new AttackState());
                }
            }
        }
        //Patroling if moveSpots are available
         else if (parent.MoveSpots.Length > 0)
        {
            parent.ChangeState(new PatrolState());
        }
    }
}

