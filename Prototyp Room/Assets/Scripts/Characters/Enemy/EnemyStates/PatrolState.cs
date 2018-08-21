using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IState
{
    private EnemyBehaviour parent;

    public Transform[] moveSpots;
    private int randomSpot;

    public void Enter(EnemyBehaviour parent)
    {
        this.parent = parent;
        randomSpot = Random.Range(0, moveSpots.Length);
    }



    public void Exit()
    {

    }

   
	
	// Update is called once per frame
	public void Update () {

        parent.transform.position = Vector2.MoveTowards(parent.transform.position, moveSpots[randomSpot].position, parent.Movement.MovementSpeed * Time.deltaTime);
          
	}
}
