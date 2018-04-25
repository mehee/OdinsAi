using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class AttackState : IState
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
       if(parent.Target != null)
        {
            float distance = Vector2.Distance(parent.Target.position, parent.transform.position);

            
            if(distance >= parent.AttackRange)
            {
                parent.ChangeState(new FollowState());
            }
        }
        else
        {
            parent.ChangeState(new IdleState());
        }
    }

   
    
}
