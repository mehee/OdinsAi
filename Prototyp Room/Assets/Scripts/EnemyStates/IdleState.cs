using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


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
        //change into follow state if player is close
        if (parent.Target != null)
        {
            parent.ChangeState(new FollowState()); 

        }
    }
}

