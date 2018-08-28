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
            float distance = Vector2.Distance(parent.Target.position, parent.transform.position);
            Vector2 retreatVector = (parent.transform.position - parent.Target.position).normalized;
            parent.Movement.Move(retreatVector);
            parent.Animator.Walk(-retreatVector);

            parent.AttackCD -= Time.deltaTime;
            if (parent.AttackCD <= 0)
            {
                        parent.ChangeState(new AttackState());   
            }
        }
        else
        {
            parent.ChangeState(new RetreatState());
        }
    }
}
