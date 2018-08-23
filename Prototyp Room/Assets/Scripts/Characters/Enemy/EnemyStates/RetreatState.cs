using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetreatState : IState
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
            parent.Animator.Walk(retreatVector);
            parent.AttackCD -= Time.deltaTime;
            if (parent.AttackCD <= 0)
            {

                parent.AttackAnimationLenght -= Time.deltaTime;
                if (parent.AttackAnimationLenght <= 0)
                {

                    parent.AttackCD = parent.AttackCDtmp;
                    parent.AttackAnimationLenght = parent.AttackAnimatiomTMP;
                    if (distance <= parent.AttackRange)
                    {
                        parent.ChangeState(new AttackState());
                    }
                }

            }
        }
        else
        {
            parent.ChangeState(new EvadeState());
        }
    }
}
