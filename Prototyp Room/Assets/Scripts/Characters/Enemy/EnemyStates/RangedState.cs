using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedState : IState {

    private EnemyBehaviour parent;

    private Vector2 direction;
    private Ability ability;
    private VariousEnemyVars vars;
    

    public void Enter(EnemyBehaviour parent)
    {
        this.parent = parent;
        Vector2 direction = (parent.Target.position - parent.transform.position).normalized;
        vars = parent.Vars;
        ability = vars.ability;
    }

    public void Exit()
    {
       
    }

    // Use this for initialization
    void Start () {
		
	}
	
	

    public void Update()
    {
        
    }

    private Vector2 getVectorBehindPlayer(float multiplyer)
    {
        Vector2 direction = (parent.Target.position - parent.transform.position).normalized;
        Vector2 parentTargetVector2 = new Vector2(parent.Target.position.x, parent.Target.position.y);
        Vector2 vectorBehindPlayer = parentTargetVector2 + direction * multiplyer;
        return vectorBehindPlayer;
    }
}
