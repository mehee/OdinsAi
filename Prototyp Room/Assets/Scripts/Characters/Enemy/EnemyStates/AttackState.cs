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
        //Debug.Log("I'm in Attack State Now");
        if (parent.Target != null)
        {
            float distance = Vector2.Distance(parent.Target.position, parent.transform.position);
            parent.Movement.Move(Vector2.zero);

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
                        if (parent.IsHeadbutt)
                        {
                            //Debug.Log("Change to headbutt");
                            parent.ChangeState(new HeadButtState());
                        }
                        else if(parent.IsRanged)
                        {
                            //Debug.Log("Change to RangedState");
                            parent.ChangeState(new RangedState());
                        }
                        else if(parent.IsBoss)
                        {
                           // Debug.Log("Change to bossState");
                            parent.ChangeState(new BossState());
                        }
                        else
                        {
                            //for ranged attack not good
                            playerHealth.Reduce(parent.AttackDamage);
                        }

                    }
                }

            }
            else if ((parent.IsRanged || parent.IsHeadbutt) && distance <= parent.EvadeDistance)
            {
                //Debug.Log("Change State from Attack to Evade!");
                parent.ChangeState(new EvadeState());
            }
            else if (distance > parent.AttackRange )
            {
               //Debug.Log("Change from Attack to Follow");
                parent.ChangeState(new FollowState());
            }
            else
            {
                //Debug.Log("From Attack to Idle");
                parent.ChangeState(new IdleState());
            }
        }
        else
        {
            parent.ChangeState(new RetreatState());
        }
    }



}
