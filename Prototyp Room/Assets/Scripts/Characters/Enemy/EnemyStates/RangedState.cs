using AbilitySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedState : IState {

    private EnemyBehaviour parent;

    private Vector2 direction;
    private Ability ability;
    private VariousEnemyVars vars;
    private Ability abilityInstance;
    private float cd;
    


    public void Enter(EnemyBehaviour parent)
    {
        this.parent = parent;
        Vector2 direction = (parent.Target.position - parent.transform.position).normalized;
        vars = parent.Vars;
        ability = vars.ability;
        abilityInstance = ability.CreateInstance(parent.Enemy);
        abilityInstance.transform.SetParent(parent.transform);
        abilityInstance.direction = direction;
        
        cd = 0.04f;
     

    }

    public void Exit()
    {
       
    }


    public void Update()
    {
        abilityInstance.Activate();
        cd -= Time.deltaTime;
        
        if(cd <= 0)
        {
            parent.ChangeState(new IdleState());
        }
            
    }

    private Vector2 getVectorBehindPlayer(float multiplyer)
    {
        Vector2 direction = (parent.Target.position - parent.transform.position).normalized;
        Vector2 parentTargetVector2 = new Vector2(parent.Target.position.x, parent.Target.position.y);
        Vector2 vectorBehindPlayer = parentTargetVector2 + direction * multiplyer;
        return vectorBehindPlayer;
    }
}
