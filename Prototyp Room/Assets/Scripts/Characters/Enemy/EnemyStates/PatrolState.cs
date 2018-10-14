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
    private bool isWaiting;


    public void Enter(EnemyBehaviour parent)
    {
        this.parent = parent;
        moveSpots = parent.MoveSpots;
       // randomSpot = Random.Range(0, moveSpots.Length);
        parent.currentMoveSpot = currentSpot;
        //Hardcoded TAKE CARE!
        waitTime = tmpWaitTime = 0;
        isWaiting = false;
    }



    public void Exit()
    {

    }

   
	
	// Update is called once per frame
	public void Update () {

        if (parent.IsRanged || parent.IsBoss)
        {
            parent.Animator.setAwakeingTrue();
        }

        parent.transform.position = Vector2.MoveTowards(parent.transform.position, moveSpots[currentSpot].position, parent.Movement.MovementSpeed * Time.deltaTime);
        parent.Animator.Walk(  moveSpots[currentSpot].transform.position - parent.transform.position );
        if(isWaiting)
        {
            parent.Animator.Stay(parent.DefaultDirection);

        }
        if (parent.Target != null)
        {
            parent.ChangeState(new FollowState());
        }
        else if(Vector2.Distance(parent.transform.position, moveSpots[currentSpot].position) < 0.2f)
        {
            if(tmpWaitTime <= 0)
            {
                isWaiting = false;
                currentSpot = (currentSpot + 1) % moveSpots.Length ; 
                tmpWaitTime = waitTime;
            }
            else
            {
                isWaiting = true;
                tmpWaitTime -= Time.deltaTime;
            }
        }
	}
}
