using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeState : IState
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
        if (parent.Target != null)
        {
            Vector2 retreatVector = (parent.transform.position - parent.Target.position).normalized;
            parent.Movement.Move(retreatVector);
            parent.Animator.Walk(-retreatVector);

            parent.AttackCD -= Time.deltaTime;
            if (parent.AttackCD <= 0)
            {
               // Debug.Log("Change From Evade to Attack");

                parent.ChangeState(new AttackState());   
            }
            if(Vector2.Distance(parent.transform.position , parent.Target.position) >= parent.EvadeDistance )
            {
                parent.Movement.Move(Vector2.zero);
            }
        }
        else
        {
            //Debug.Log("Change From Evade to Retreat");
            parent.ChangeState(new RetreatState());
        }
    }
}
