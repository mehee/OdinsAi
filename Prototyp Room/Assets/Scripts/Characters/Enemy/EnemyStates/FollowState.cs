using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class FollowState : IState
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
            //Debug.Log(parent.Target.position);
            // parent.transform.position = Vector2.MoveTowards(parent.transform.position, parent.Target.position, parent.Movement.MovementSpeed * Time.deltaTime);
            parent.Movement.Move((parent.Target.position - parent.transform.position).normalized);
            float distance = Vector2.Distance(parent.Target.position, parent.transform.position);

            parent.AttackCD -= Time.deltaTime;
            if (parent.AttackCD <= 0)
            {
                parent.AttackAnimationLenght = parent.AttackAnimatiomTMP;
                if (distance <= parent.AttackRange)
                {
                    parent.Movement.Move(Vector2.zero);
                    parent.ChangeState(new AttackState());
                }
            }

        }
        else
        {
            parent.ChangeState(new EvadeState());
        }

    }
}
