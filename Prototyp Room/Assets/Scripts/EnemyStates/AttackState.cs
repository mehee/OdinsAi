using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class AttackState : IState
{
    private EnemyBehaviour parent;
    private Health playerHealth;
    public void Enter(EnemyBehaviour parent)
    {
        this.parent = parent;
        playerHealth = parent.Target.GetComponent<Health>();
    }

    public void Exit()
    {
       
    }

    public void Update()
    {
       if(parent.Target != null)
        {
            float distance = Vector2.Distance(parent.Target.position, parent.transform.position);
            playerHealth.subtractHealthBy(1);

            if (distance >= parent.AttackRange)
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
