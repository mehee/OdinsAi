using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    private EnemyBehaviour parent;

    private Transform[] moveSpots;
    private int currentSpot;
    private float waitTime;
    private float tmpWaitTime;


    public void Enter(EnemyBehaviour parent)
    {
        this.parent = parent;
        moveSpots = parent.MoveSpots;
       // randomSpot = Random.Range(0, moveSpots.Length);
        parent.currentMoveSpot = currentSpot;
        //Hardcoded TAKE CARE!
        waitTime = tmpWaitTime = 1;
    }



    public void Exit()
    {

    }

   
	
	// Update is called once per frame
	public void Update () {
        
        parent.transform.position = Vector2.MoveTowards(parent.transform.position, moveSpots[currentSpot].position, parent.Movement.MovementSpeed * Time.deltaTime);
        parent.Animator.Walk(  moveSpots[currentSpot].transform.position - parent.transform.position );

        if (parent.Target != null)
        {
            parent.ChangeState(new FollowState());
        }
        else if(Vector2.Distance(parent.transform.position, moveSpots[currentSpot].position) < 0.2f)
        {
            if(tmpWaitTime <= 0)
            {
                currentSpot = (currentSpot + 1) % moveSpots.Length ; 
                tmpWaitTime = waitTime;
            }
            else
            {
                tmpWaitTime -= Time.deltaTime;
            }
        }
	}
}
