using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadButtState : IState {

    private EnemyBehaviour parent;

    private Vector2 direction;
    private Vector2 target;
    private float chargeSpeed;
    private Health playerHealth;
    private float distance;
    private float pauseTimer;

    public void Enter(EnemyBehaviour parent)
    {
        this.parent = parent;
        // direction = (parent.Target.position - parent.transform.position).normalized;
        target = parent.Target.transform.position;
        chargeSpeed = 10;
        pauseTimer = 1;
        playerHealth = parent.Target.GetComponent<Health>();

    }

    public void Exit()
    {
        
    }

    // Use this for initialization
    public void Start () {
        
    }
	
	// Update is called once per frame
    //not good implementation
	public void Update () {
        pauseTimer -= Time.deltaTime;
        parent.transform.position = Vector2.MoveTowards(parent.transform.position, target, Time.deltaTime * chargeSpeed);
         distance = Vector2.Distance(parent.transform.position, parent.Target.position);
        if((distance)< 1)
        {
            playerHealth.Reduce(parent.AttackDamage);
            if(pauseTimer <= 0)
            {
                parent.ChangeState(new FollowState());
            }
          
        }
    }

    
}
