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
            parent.Movement.Move(Vector2.zero);

            parent.AttackCD -= Time.deltaTime;
            if(parent.AttackCD <= 0)
            {

                parent.AttackAnimationLenght -= Time.deltaTime;
                if (parent.AttackAnimationLenght <= 0)
                {
                    
                    parent.AttackCD = parent.AttackCDtmp;
                    parent.AttackAnimationLenght = parent.AttackAnimatiomTMP;
                    if (distance <= parent.AttackRange) 
                    {
                        if(parent.IsHeadbutt)
                        {
                            Debug.Log("CHange to headbutt");
                            parent.ChangeState(new HeadButtState());
                        }
                        else
                        {
                            //for ranged attack not good
                            playerHealth.Reduce(parent.AttackDamage);
                        }
                       
                    }
                }

            }
            else if((parent.IsRanged || parent.IsHeadbutt) && distance <= parent.EvadeDistance)
            {
                Debug.Log("Retreat!");
                parent.ChangeState(new EvadeState());
            }
            else if (distance > parent.AttackRange && !parent.IsRanged)
            {
                Debug.Log("Change from Attack to Follow");
                parent.ChangeState(new FollowState());
            }
            else
            {
                parent.ChangeState(new IdleState());
            }
        }
        else
        {
            parent.ChangeState(new IdleState());
        }
    }

   
    
}
