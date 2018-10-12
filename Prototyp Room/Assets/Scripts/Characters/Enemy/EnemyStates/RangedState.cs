using AbilitySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedState : IState {

    private EnemyBehaviour parent;

    private Vector2 direction;
    private EnemyAbility abilityInstance;

    public void Enter(EnemyBehaviour parent)
    {
        this.parent = parent;
        Vector2 direction = (parent.Target.position - parent.transform.position).normalized;
        //vars = parent.Vars;
        abilityInstance = parent.AbilityInstance;
        abilityInstance.direction = direction;
        abilityInstance.Activate();
        parent.ChangeState(new IdleState());


    }

    public void Exit()
    {
       
    }


    public void Update()
    {

        
            
    }
}
