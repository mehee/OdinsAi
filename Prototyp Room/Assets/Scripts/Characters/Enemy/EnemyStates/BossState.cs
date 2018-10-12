using AbilitySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossState : IState
{
    private EnemyBehaviour parent;

    private Vector2 direction;
    private EnemyAbility abilityInstance;
    private int numOfAbilities;
    private int currentAbility;




    public void Enter(EnemyBehaviour parent)
    {
        numOfAbilities = parent.BossAbillites.Length;
        currentAbility = (int)Random.Range(0, numOfAbilities);

        //Debug.Log("enter boss");
        this.parent = parent;
        Vector2 direction = (parent.Target.position - parent.transform.position).normalized;

        abilityInstance = parent.BossAbilityInstance;
        abilityInstance.direction = direction;
        abilityInstance.Activate();
        parent.setAbility(currentAbility);
        parent.ChangeState(new IdleState());


    }

    public void Exit()
    {

    }


    public void Update()
    {



    }
}
