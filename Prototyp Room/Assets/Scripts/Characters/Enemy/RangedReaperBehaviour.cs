using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedReaperBehavo : IState {

    private EnemyBehaviour parent;

    private Vector2 direction;
    private VariousEnemyVars vars;
    private Ability ability;

    public void Enter(EnemyBehaviour parent)
    {
        this.parent = parent;
        vars = parent.Vars;
        ability = vars.ability;
        direction = (parent.Target.position - parent.transform.position).normalized;

    }

    public void Exit()
    {
        
    }

    // Use this for initialization
    public  void Start () {
       
	}
	
	// Update is called once per frame
	public void Update () {
		
	}

  
}
